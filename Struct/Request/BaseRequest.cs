// <copyright file="BaseRequest.cs">
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
    /// <see href="https://github.com/SteelSeries/gamesense-sdk"/>
    /// </summary>
    public struct BaseRequest
    {
        /// <summary>
        /// Gets or sets the game-name.
        /// </summary>
        public string Game { get; set; }

        /// <summary>
        /// Gets or sets the displayed game-name.
        /// </summary>
        public string GameDisplayName { get; set; }

        /// <summary>
        /// Gets or sets the developer-name.
        /// </summary>
        public string Developer { get; set; }

        /// <summary>
        /// Gets or sets the min-value.
        /// </summary>
        public int MinValue { get; set; }

        /// <summary>
        /// Gets or sets the max-value.
        /// </summary>
        public int MaxValue { get; set; }

        /// <summary>
        /// Gets or sets the icon-id.
        /// </summary>
        public int IconId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the value is optional.
        /// </summary>
        public bool ValueOptional { get; set; }

        /// <summary>
        /// Gets or sets the handlers.
        /// </summary>
        public Handler[] Handlers { get; set; }

        /// <summary>
        /// Gets or sets the event name.
        /// </summary>
        public string Event { get; set; }

        /// <summary>
        /// Gets or sets an array with events.
        /// </summary>
        public EventBinder[] Events { get; set; }
    }
}
