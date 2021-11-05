// <copyright file="CoreProps.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace GameSense.Struct
{
    /// <summary>
    /// <see href="https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/sending-game-events.md#server-discovery"/>
    /// </summary>
    public struct CoreProps
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public string Address { get; set; }
    }
}