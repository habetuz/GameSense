// <copyright file="KeyFade.cs">
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
    /// An <see cref="KeyAnimator"/> that animates a fading color for keys
    /// </summary>
    public class KeyFade : KeyAnimator
    {
        /// <summary>
        /// Logger of the <see cref="KeyFade"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger()
        {
            Ident = "KeyFade",
            LogDebug = false,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// Amount of <see cref="KeyAnimator.NextFrame(KeyboardFrame)"/> calls the key needs to fade out.
        /// </summary>
        private int fadeDuration = 60;

        /// <summary>
        /// The current transparency of the color.
        /// </summary>
        private int transparency = 100;

        /// <summary>
        /// The color to fade out.
        /// </summary>
        private int[] color = new int[] { 255, 255, 255 };

        /// <summary>
        /// Sets amount of <see cref="KeyAnimator.NextFrame(KeyboardFrame)"/> calls the key needs to fade out. Time dependents on the <see cref="GameSense.Controller.FrameLength"/>. Default: 100.
        /// </summary>
        public int FadeDuration
        {
            set
            {
                this.fadeDuration = value;
            }
        }

        /// <summary>
        /// Sets the color that should fade away. Default: 255(R)|255(G)|255(B)
        /// </summary>
        public int[] Color
        {
            set { this.color = value; }
        }

        /// <summary>
        /// Creates a copy of itself.
        /// </summary>
        /// <returns>The copy.</returns>
        public override KeyAnimator Copy()
        {
            return new KeyFade()
            {
                FadeDuration = this.fadeDuration,
                Color = this.color,
            };
        }

        /// <summary>
        /// Generates the next <see cref="KeyboardFrame"/>.
        /// </summary>
        /// <param name="bottomLayer">The bottom <see cref="KeyboardFrame"/> the method will add its own <see cref="KeyboardFrame"/> on.</param>
        /// <returns>the next <see cref="KeyboardFrame"/></returns>
        public override KeyboardFrame NextFrame(KeyboardFrame bottomLayer)
        {
            this.transparency -= 100 / this.fadeDuration;
            Logger.Log("Next frame. Transparency: " + this.transparency);
            if (this.transparency <= 0)
            {
                this.InternalFinished = true;
                return bottomLayer;
            }

            return bottomLayer.SetColor(
                (int)this.Key,
                ColorManipulation.Combine(bottomLayer.Bitmap[(int)this.Key], this.color, this.transparency));
        }
    }
}