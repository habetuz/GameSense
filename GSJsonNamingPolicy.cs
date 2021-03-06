// <copyright file="GSJsonNamingPolicy.cs">
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
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text.Json;
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// A <see cref="System.Text.Json.JsonNamingPolicy"/> for the game sense API.
    /// </summary>
    internal class GSJsonNamingPolicy : JsonNamingPolicy
    {
        /// <summary>
        /// Dictionary containing the .Net names of fields and the json equivalent for the game sense engine.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed.")]
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

        /// <summary>
        /// The logger for the <see cref="GSJsonNamingPolicy"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/GSJsonNamingPolicy",
            LogDebug = false,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
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
                Logger.Log("Converting " + name + " to " + DotNetGSPairs[name], LogType.Debug);
                return DotNetGSPairs[name];
            }
            catch
            {
                return name.ToLower();
            }
        }
    }
}