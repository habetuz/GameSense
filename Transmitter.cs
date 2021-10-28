// <copyright file="Transmitter.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace GameSense
{
    using GameSense.Struct;
    using GameSense.Struct.Request;
    using SharpLog;
    using SharpLog.Output;
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Timers;

    /// <summary>
    /// Responsible for communication between GameSense and the GameSense Engine.
    /// </summary>
    public static class Transmitter
    {
        private static readonly MassLogger Logger = new MassLogger(30 * 60000)
        {
            Ident = "GameSense/Transmitter",
            LogDebug = false,
            InfoLogText = "Transitions",
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        private static readonly HttpClient Client = new HttpClient();

        private static readonly JsonSerializerOptions SerializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = false
        };

        private static readonly Timer restartTimer = new Timer(5000);

        private static readonly Queue<Tuple<BaseRequest, string>> pendingRequests = new Queue<Tuple<BaseRequest, string>>();

        private static string Adress;

        static Transmitter()
        {
            Logger.Log("Starting...", LogType.Info, true);
            restartTimer.Elapsed += Start;
            Start();
        }

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
                Adress = coreProps.Address;

                // Try to reach the server to check if the server is actually running.
                HttpResponseMessage response = await Client.GetAsync("http://" + Adress + "/");

                Logger.Log("GameSense server runs on " + Adress, LogType.Info, true);

                if (restartTimer.Enabled)
                {
                    restartTimer.Stop();
                    Logger.Log("Finally ready! Sending " + pendingRequests.Count + " remaining requests.", LogType.Info, true);
                    while(pendingRequests.Count > 0)
                    {
                        Logger.Log(pendingRequests.Count);
                        Tuple<BaseRequest, string> requestTuple = pendingRequests.Dequeue();
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
                else if(ex is HttpRequestException)
                {
                    Logger.Log("The Engine is not running. Start the SteelSeries Engine.", LogType.Error);
                }
                else
                {
                    Logger.Log("coreProps.json could not be deserialized. Restart the SteelSeries Engine.", LogType.Error);
                }
                restartTimer.Start();
            }
        }

        /// <summary>
        /// Sends a <see cref="BaseRequest"/> to the game sense engine.
        /// </summary>
        /// <param name="request">The request to be send</param>
        /// <param name="endpoint">The endpoint where the request should be send</param>
        public static async void Send(BaseRequest request, string endpoint, bool important = true)
        {
            if(restartTimer.Enabled)
            {
                if(important)
                {
                    pendingRequests.Enqueue(new Tuple<BaseRequest, string>(request, endpoint));
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

            //Logger.Log(JsonSerializer.Serialize<BaseRequest>(request, new JsonSerializerOptions { PropertyNamingPolicy = new GSJsonNamingPolicy(), WriteIndented = true }));

            try
            {
                ////Logger.Log("Sending a request to endpoint " + endpoint + "...", Logger.Type.Info);
                HttpResponseMessage response = await Client.PostAsync("http://" + Adress + "/" + endpoint, payload);

                if (response.IsSuccessStatusCode)
                {
                    Logger.Log("/" + endpoint, LogType.Info);
                }
                else
                {
                    Logger.Log("Request to endpoint '" + endpoint + "' failed! Status: " + response.StatusCode + " | Content: " + await response.Content.ReadAsStringAsync(), LogType.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.Log("Request to endpoint '" + endpoint + "' failed! The engine could be off line. Try to restart the Engine.", LogType.Error);
                if(important)
                {
                    pendingRequests.Enqueue(new Tuple<BaseRequest, string>(request, endpoint));
                }
                restartTimer.Start();
            }
        }
    }
}
