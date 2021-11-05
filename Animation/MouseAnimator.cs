// <copyright file="MouseAnimator.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace GameSense.Animation
{
    using System.Collections.Generic;

    /// <summary>
    /// Abstract class for mouse animations.
    /// </summary>
    public abstract class MouseAnimator
    {
        /// <summary>
        /// Generates the next frame as dictionary of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom layer the animator should render on top.</param>
        /// <returns>The next frame.</returns>
        public abstract Dictionary<MouseZone, int> NextFrame(Dictionary<MouseZone, int> bottomLayer);
    }
}