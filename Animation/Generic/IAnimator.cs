// <copyright file="MousePadAnimator.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace GameSense.Animation.Generic
{
    public interface IAnimator
    {
        int[] NextFrame(int[] bottomLayer, int numberOfZones);
    }
}
