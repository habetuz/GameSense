// <copyright file="KeyboardTest.cs">
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
    using SharpLog;

    /// <summary>
    /// Test <see cref="KeyboardAnimator"/> to check every LED individually.
    /// </summary>
    public class KeyboardTest : KeyboardAnimator
    {
        /// <summary>
        /// The logger of the <see cref="KeyboardTest"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Controller",
            LogDebug = true,
            LogInfo = true
        };

        /// <summary>
        /// The current frame of the animation.
        /// </summary>
        private int currentFrame = 0;

        /// <summary>
        /// Array containing all frames of the animation.
        /// </summary>
        private KeyboardFrame[] frames = new KeyboardFrame[132];

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardTest"/> class.
        /// </summary>
        public KeyboardTest()
        {
            for (int i = 0; i < this.frames.Length; i++)
            {
                this.frames[i] = new KeyboardFrame().SetColor(i, 255, 255, 255);
            }
        }

        /// <summary>
        /// Generates the next <see cref="KeyboardFrame"/> of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom <see cref="KeyboardFrame"/> the method will add its own <see cref="KeyboardFrame"/> on.</param>
        /// <returns>the next <see cref="KeyboardFrame"/></returns>
        public override KeyboardFrame NextFrame(KeyboardFrame bottomLayer)
        {
            this.currentFrame += 1;
            if (this.currentFrame > 132)
            {
                this.currentFrame = 0;
            }

            Logger.Log("Key:" + ((Key)this.currentFrame).ToString() + " | value: " + this.currentFrame, LogType.Info);
            return this.frames[this.currentFrame];
        }
    }
}