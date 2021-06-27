// <copyright file="Color.cs">
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
    /// A struct representing a color.
    /// </summary>
    public struct Color
    {
        /// <summary>
        /// Gets or sets the red value of the color (0-255).
        /// </summary>
        public int Red { get; set; }

        /// <summary>
        /// Gets or sets the green value of the color (0-255).
        /// </summary>
        public int Green { get; set; }

        /// <summary>
        /// Gets or sets the blue value of the color (0-255).
        /// </summary>
        public int Blue { get; set; }
    }
}
