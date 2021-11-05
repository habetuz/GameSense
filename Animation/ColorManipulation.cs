// <copyright file="ColorManipulation.cs">
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
    using System;
    using System.Collections.Generic;
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// Helper class for combining and manipulating colors.
    /// </summary>
    public static class ColorManipulation
    {
        /// <summary>
        /// Logger of the <see cref="ColorManipulation"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger()
        {
            Ident = "ColorManipulation",
            LogDebug = true,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// Combines one bottom color with a translucent top color.
        /// </summary>
        /// <param name="bottom">The bottom color (RGB format)</param>
        /// <param name="top">The top color (RGB format)</param>
        /// <param name="transparency">The transparency of the top color (0-100)</param>
        /// <returns>The combined color (RGB format)</returns>
        public static int[] Combine(int[] bottom, int[] top, int transparency)
        {
            return new int[]
            {
                bottom[0] + (int)Math.Round((double)(top[0] - bottom[0]) * ((double)transparency / 100.0)),
                bottom[1] + (int)Math.Round((double)(top[1] - bottom[1]) * ((double)transparency / 100.0)),
                bottom[2] + (int)Math.Round((double)(top[2] - bottom[2]) * ((double)transparency / 100.0))
            };
        }
    }
}