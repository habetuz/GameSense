// <copyright file="MouseFrameManager.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>




namespace GameSense 
{ 
    using System.Collections.Generic;
    using Animation;

    static class MouseFrameManager
    {

        public static MouseAnimator Background { get; set; } = new MouseValue(0);

        public static Dictionary<MouseZone, int> Generate()
        {
            return Background.NextFrame(null);
        }
    }
}
