// <copyright file="RequestData.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace GameSense.Struct.Request
{
    /// <summary>
    /// <see href="https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/json-handlers-full-keyboard-lighting.md"/>
    /// </summary>
    public struct EventData
    {
        /// <summary>
        /// Gets or sets the frame
        /// </summary>
        public KeyboardFrame Frame { get; set; }

        public int Value { get; set; }
    }
}
