// <copyright file="ColorHandler.cs">
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
    public struct ColorHandler
    {
        /// <summary>
        /// Gets or sets a <see cref="ColorHandlerGradient"/> as color handler.
        /// </summary>
        public ColorHandlerGradient Gradient { get; set; }
    }
}
