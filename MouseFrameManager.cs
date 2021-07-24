// <copyright file="MouseFrameManager.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameSense
{
    using Animation;

    static class MouseFrameManager
    {
        public static IMouseAnimator Animator { get; set; }

        public static Dictionary<MouseZone, int> Generate()
        {
            if (Animator == null) return null;

            return Animator.NextFrame(null);
        }
    }
}
