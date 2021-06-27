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
    using System;
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using GameSense.Struct;
    using GameSense.Struct.Request;
    using SharpLog;

    /// <summary>
    /// Class responsible for the communication to the game sense engine.
    /// </summary>
    public class Transmitter
    {
        private static readonly MassLogger Logger = new MassLogger(300000)
        {
            Ident = "GameSense/Transmitter",
            LogDebug = false,
            InfoLogText = "Transitions"
        };

        private static readonly HttpClient Client = new HttpClient();

        private static readonly JsonSerializerOptions SerializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };

        private static readonly string Adress;

        static Transmitter()
        {
            Logger.Log("Starting...", LoggerType.Info, true);
            try
            {
                string file = System.IO.File.ReadAllText("C:/ProgramData/SteelSeries/SteelSeries Engine 3/coreProps.json");
                CoreProps coreProps = JsonSerializer.Deserialize<CoreProps>(
                    file,
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });
                Adress = coreProps.Address;
                Logger.Log("GameSense server is running on " + Adress, LoggerType.Info, true);
                Logger.Log("Ready!", LoggerType.Info, true);
            }
            catch (Exception ex)
            {
                if (ex is System.IO.DirectoryNotFoundException || ex is System.IO.FileNotFoundException)
                {
                    Logger.Log("coreProps.json could not be found. Maybe the SteelSeries Engine is not running.", LoggerType.Error);
                }
                else
                {
                    Logger.Log("coreProps.json cannot be deserialized", LoggerType.Error);
                }

                throw ex;
            }
        }

        /// <summary>
        /// Sends a <see cref="Request"/> to the game sense engine.
        /// </summary>
        /// <param name="request">The request to send.</param>
        /// <param name="endpoint">The endpoint where the request needs to be send.</param>
        public static async void Send(BaseRequest request, string endpoint)
        {
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

            Logger.Log(JsonSerializer.Serialize<BaseRequest>(request, new JsonSerializerOptions { PropertyNamingPolicy = new GSJsonNamingPolicy(), WriteIndented = true }));

            try
            {
                ////Logger.Log("Sending a request to endpoint " + endpoint + "...", Logger.Type.Info);
                HttpResponseMessage response = await Client.PostAsync("http://" + Adress + "/" + endpoint, payload);

                if (response.IsSuccessStatusCode)
                {
                    Logger.Log("/" + endpoint, LoggerType.Info);
                }
                else
                {
                    Logger.Log("BaseRequest to endpoint '" + endpoint + "' failed! Status: " + response.StatusCode + " | Content: " + await response.Content.ReadAsStringAsync(), LoggerType.Warning);
                }
            }
            catch (Exception ex)
            {
                //Logger.Log("BaseRequest to endpoint '" + endpoint + "' failed!\n" + ex.ToString(), LoggerType.Error);
                //throw ex;
            }
        }
    }
}
