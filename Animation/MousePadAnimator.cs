// <copyright file="MousePadAnimator.cs">
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
    /// 
    /// Abstract class for mouse pad animations.
    /// </summary>
    public abstract class MousePadAnimator
    {
        public abstract int[][] NextFrame(int[][] bottomLayer);
    }
}
