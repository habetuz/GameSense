// <copyright file="GSJsonNamingPolicy.cs">
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
    using System.Collections.Generic;
    using System.Text.Json;
    using SharpLog;

    /// <summary>
    /// A <see cref="System.Text.Json.JsonNamingPolicy"/> for the game sense API.
    /// </summary>
    static class GSJsonNamingPolicy : JsonNamingPolicy
    {
        private static readonly Dictionary<string, string> DotNetGSPairs =
            new Dictionary<string, string>
            {
                { "GameDisplayName",    "game_display_name" },
                { "MinValue",           "min_value" },
                { "MaxValue",           "max_value" },
                { "IconId",             "icon_id" },
                { "ValueOptional",      "value_optional" },
                { "DeviceType",         "device-type" },
            };

        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/GSJsonNamingPolicy",
            LogDebug = false
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="GSJsonNamingPolicy"/> class.
        /// </summary>
        public GSJsonNamingPolicy()
        {
        }

        /// <summary>
        /// Converts the given .net object name to the JSON object name using either <see cref="DotNetGSPairs"/> or <see cref="System.String.ToLower"/>
        /// </summary>
        /// <param name="name">the .net object name</param>
        /// <returns>the to JSON object converted name</returns>
        public override string ConvertName(string name)
        {
            try
            {
                Logger.Log("Converting " + name + " to " + DotNetGSPairs[name]);
                return DotNetGSPairs[name];
            }
            catch
            {
                return name.ToLower();
            }
        }
    }
}