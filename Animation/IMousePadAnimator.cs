// <copyright file="IMousePadAnimator.cs">
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
    /// <summary>
    /// Interface for mouse pad animations.
    /// </summary>
    public interface IMousePadAnimator
    {
        int[][] NextFrame(int[][] bottomLayer);
    }
}
