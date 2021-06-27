// <copyright file="Handler.cs">
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
    /// <see href="https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/writing-handlers-in-json.md"/>
    /// </summary>
    public struct Handler
    {
        /// <summary>
        /// Gets or sets the device type.
        /// </summary>
        public string DeviceType { get; set; }

        /// <summary>
        /// Gets or sets the zone of the <see cref="DeviceType"/>.
        /// </summary>
        public string Zone { get; set; }

        /// <summary>
        /// Gets or sets the device mode.
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="ColorHandler"/>.
        /// </summary>
        public ColorHandler Color { get; set; }
    }
}
