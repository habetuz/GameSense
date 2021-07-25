// <copyright file="EventBinder.cs">
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
    /// <see href="https://github.com/SteelSeries/gamesense-sdk/blob/83127ca35a108a3bab3fb3273e4e9c3c2a8ff9ac/doc/api/sending-game-events.md#sending-multiple-event-updates-in-one-request"/>
    /// </summary>
    public struct EventBinder
    {
        /// <summary>
        /// Gets or sets the event.
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// Gets or sets the request-data.
        /// </summary>
        public EventData Data { get; set; }
    }
}
