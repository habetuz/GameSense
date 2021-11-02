// <copyright file="KeyboardGradient.cs">
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
    using SharpLog;
    using SharpLog.Output;
    using System.Collections.Generic;

    /// <summary>
    /// An <see cref="KeyboardAnimator"/> that generates one color.
    /// </summary>
    public class KeyboardColor : KeyboardAnimator
    {
        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Animator/KeyboardColor",
            LogDebug = false,
            LogInfo = true,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        private KeyboardFrame Frame;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardColor"/> class.
        /// </summary>
        /// <param name="color">The color</param>
        public KeyboardColor(int[] color)
        {
            this.Frame = new KeyboardFrame();
            for(int i = 0; i < Frame.Bitmap.Length; i++)
            {
                Frame.Bitmap[i] = color;
            }
        }

        public override KeyboardFrame NextFrame(KeyboardFrame bottomLayer)
        {
            return Frame;
        }
    }
}
