// <copyright file="MouseValue.cs">
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
    /// A <see cref="MouseAnimator"/> that returns one constant value.
    /// </summary>
    public class MouseValue : MouseAnimator
    {
        /// <summary>
        /// The logger of the <see cref="MouseValue"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger()
        {
            Ident = "GameSense/Animator/MosueColor",
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// Dictionary with the frame <see cref="NextFrame(Dictionary{MouseZone, int})"/> returns.
        /// </summary>
        private Dictionary<MouseZone, int> frame = new Dictionary<MouseZone, int>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseValue"/> class.
        /// </summary>
        /// <param name="value">The value the animator should return</param>
        public MouseValue(int value)
        {
            foreach (MouseZone zone in Enum.GetValues(typeof(MouseZone)))
            {
                this.frame.Add(zone, value);
            }
        }

        /// <summary>
        /// Generates the next frame as dictionary of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom layer the animator should render on top.</param>
        /// <returns>The next frame.</returns>
        public override Dictionary<MouseZone, int> NextFrame(Dictionary<MouseZone, int> bottomLayer)
        {
            return this.frame;
        }
    }
}