// <copyright file="MouseFrameManager.cs">
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
    using Animation;

    /// <summary>
    /// Frame manager responsible for all <see cref="MouseAnimator"/>
    /// </summary>
    internal static class MouseFrameManager
    {
        /// <summary>
        /// Gets or sets <see cref="MouseAnimator"/> the frame manager should use as background.
        /// </summary>
        public static MouseAnimator Background { get; set; } = new MouseValue(0);

        /// <summary>
        /// Generates the next frame using <see cref="MouseAnimator.NextFrame(Dictionary{MouseZone, int})"/>.
        /// </summary>
        /// <returns>Returns the next frame.</returns>
        public static Dictionary<MouseZone, int> Generate()
        {
            return Background.NextFrame(null);
        }
    }
}