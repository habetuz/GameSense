// <copyright file="IMouseAnimator.cs">
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
    /// Interface for mouse animations.
    /// </summary>
    public interface IMouseAnimator
    { 
        Dictionary<MouseZone, int> NextFrame(Dictionary<MouseZone, int> bottomLayer);
    }
}
