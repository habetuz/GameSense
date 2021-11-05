// <copyright file="KeyboardColor.cs">
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
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// An <see cref="KeyboardAnimator"/> that generates one color.
    /// </summary>
    public class KeyboardColor : KeyboardAnimator
    {
        /// <summary>
        /// The logger of the <see cref="KeyboardColor"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Animator/KeyboardColor",
            LogDebug = false,
            LogInfo = true,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// The frame <see cref="NextFrame(KeyboardFrame)"/> returns.
        /// </summary>
        private KeyboardFrame frame;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardColor"/> class.
        /// </summary>
        /// <param name="color">The color</param>
        public KeyboardColor(int[] color)
        {
            this.frame = new KeyboardFrame();
            for (int i = 0; i < this.frame.Bitmap.Length; i++)
            {
                this.frame.Bitmap[i] = color;
            }
        }

        /// <summary>
        /// Generates the next <see cref="KeyboardFrame"/> of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom <see cref="KeyboardFrame"/> the method will add its own <see cref="KeyboardFrame"/> on.</param>
        /// <returns>the next <see cref="KeyboardFrame"/></returns>
        public override KeyboardFrame NextFrame(KeyboardFrame bottomLayer)
        {
            return this.frame;
        }
    }
}