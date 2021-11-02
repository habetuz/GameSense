// <copyright file="MouseAnimator.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace GameSense.Animation
{
    using System.Collections.Generic;

    /// <summary>
    /// Abstract class for mouse animations.
    /// </summary>
    public abstract class MouseAnimator
    { 
        public abstract Dictionary<MouseZone, int> NextFrame(Dictionary<MouseZone, int> bottomLayer);
    }
}
