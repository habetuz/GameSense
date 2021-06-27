// <copyright file="ColorHandlerGradient.cs">
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
    /// <see href="https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/json-handlers-color.md"/>
    /// </summary>
    public struct ColorHandlerGradient
    {
        /// <summary>
        /// Gets or sets the color at the value 0.
        /// </summary>
        public Color Zero { get; set; }

        /// <summary>
        /// Gets or sets the color at the value 100.
        /// </summary>
        public Color Hundred { get; set; }
    }
}
