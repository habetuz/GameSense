// <copyright file="Transmitter.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace GameSense
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Timers;
    using GameSense.Struct;
    using GameSense.Struct.Request;
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// Responsible for communication between GameSense and the GameSense Engine.
    /// </summary>
    public static class Transmitter
    {
        /// <summary>
        /// The logger for the <see cref="Transmitter"/> class.
        /// </summary>
        private static readonly MassLogger Logger = new MassLogger(30 * 60000)
        {
            Ident = "GameSense/Transmitter",
            LogDebug = false,
            InfoLogText = "Transitions",
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// Instance of a <see cref="HttpClient"/> of the <see cref="Transmitter"/>.
        /// </summary>
        private static readonly HttpClient Client = new HttpClient();

        /// <summary>
        /// Timer that tries again periodically when an error occurs.
        /// </summary>
        private static readonly Timer RestartTimer = new Timer(5000);

        /// <summary>
        /// Gets filled while the transmitter has no connection to the game sense engine so that those request can get processed on reconnection.
        /// </summary>
        private static readonly Queue<Tuple<BaseRequest, string>> PendingRequests = new Queue<Tuple<BaseRequest, string>>();

        /// <summary>
        /// The server address of the game sense engine.
        /// </summary>
        private static string adress;

        /// <summary>
        /// Initializes static members of the <see cref="Transmitter"/> class.
        /// </summary>
        static Transmitter()
        {
            Logger.Log("Starting...", LogType.Info, true);
            RestartTimer.Elapsed += Start;
            Start();
        }

        /// <summary>
        /// Sends a <see cref="BaseRequest"/> to the game sense engine.
        /// </summary>
        /// <param name="request">The request to be send</param>
        /// <param name="endpoint">The endpoint where the request should be send</param>
        /// <param name="important">If true, the request will get send after reconnection when the transmitter has no connection to the game sense engine.</param>
        public static async void Send(BaseRequest request, string endpoint, bool important = true)
        {
            if (RestartTimer.Enabled)
            {
                if (important)
                {
                    PendingRequests.Enqueue(new Tuple<BaseRequest, string>(request, endpoint));
                }

                return;
            }
            ////Logger.Log("Data: " + request.Game + " | " + request.Handlers.Length + " | " + request.Handlers[0].DeviceType);
            HttpContent payload =
                new StringContent(
                    JsonSerializer.Serialize<BaseRequest>(
                        request,
                        new JsonSerializerOptions
                        {
                            PropertyNamingPolicy = new GSJsonNamingPolicy(),
                            WriteIndented = false,
                        }),
                    Encoding.UTF8,
                    "application/json");

            Logger.Log(JsonSerializer.Serialize(request, new JsonSerializerOptions { PropertyNamingPolicy = new GSJsonNamingPolicy(), WriteIndented = true }));

            try
            {
                ////Logger.Log("Sending a request to endpoint " + endpoint + "...", Logger.Type.Info);
                HttpResponseMessage response = await Client.PostAsync("http://" + adress + "/" + endpoint, payload);

                if (response.IsSuccessStatusCode)
                {
                    Logger.Log("/" + endpoint, LogType.Info);
                }
                else
                {
                    Logger.Log(
                            "Request to endpoint '" + endpoint + "' failed!" +
                          "\nStatus: " + response.StatusCode +
                        "\n\nResponse:\n" + await response.Content.ReadAsStringAsync() +
                        "\n\nRequest:\n" + JsonSerializer.Serialize(
                            request,
                            new JsonSerializerOptions
                            {
                                PropertyNamingPolicy = new GSJsonNamingPolicy(),
                                WriteIndented = true
                            }),
                            LogType.Error);
                }
            }
            catch
            {
                Logger.Log("Request to endpoint '" + endpoint + "' failed! The engine could be offline. Try to restart the Engine.", LogType.Error);
                if (important)
                {
                    PendingRequests.Enqueue(new Tuple<BaseRequest, string>(request, endpoint));
                }

                RestartTimer.Start();
            }
        }

        /// <summary>
        /// Starts the transmitter and connects it to the game sense engine.
        /// </summary>
        /// <param name="sender">The parameter is not used.</param>
        /// <param name="e">The parameter is not used.</param>
        private static async void Start(object sender = null, ElapsedEventArgs e = null)
        {
            try
            {
                // Get Engine address from the coreProps.json file.
                string file = System.IO.File.ReadAllText("C:/ProgramData/SteelSeries/SteelSeries Engine 3/coreProps.json");
                CoreProps coreProps = JsonSerializer.Deserialize<CoreProps>(
                    file,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                adress = coreProps.Address;

                // Try to reach the server to check if the server is actually running.
                HttpResponseMessage response = await Client.GetAsync("http://" + adress + "/");

                Logger.Log("GameSense server runs on " + adress, LogType.Info, true);

                if (RestartTimer.Enabled)
                {
                    RestartTimer.Stop();
                    Logger.Log("Finally ready! Sending " + PendingRequests.Count + " remaining requests.", LogType.Info, true);
                    while (PendingRequests.Count > 0)
                    {
                        Logger.Log(PendingRequests.Count);
                        Tuple<BaseRequest, string> requestTuple = PendingRequests.Dequeue();
                        Send(requestTuple.Item1, requestTuple.Item2);
                    }
                }
                else
                {
                    Logger.Log("Ready!", LogType.Info, true);
                }
            }
            catch (Exception ex)
            {
                if (ex is System.IO.DirectoryNotFoundException || ex is System.IO.FileNotFoundException)
                {
                    Logger.Log("coreProps.json could not be found under C:/ProgramData/SteelSeries/SteelSeries Engine 3/coreProps.json. Maybe the SteelSeries Engine is not running.", LogType.Error);
                }
                else if (ex is HttpRequestException)
                {
                    Logger.Log("The Engine is not running. Start the SteelSeries Engine.", LogType.Error);
                }
                else
                {
                    Logger.Log("coreProps.json could not be deserialized. Restart the SteelSeries Engine.", LogType.Error);
                }

                RestartTimer.Start();
            }
        }
    }
}