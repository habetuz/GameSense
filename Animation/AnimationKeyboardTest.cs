// <copyright file="AnimationKeyboardTest.cs">
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

    public class KeyboardTest : IKeyboardAnimator
    {
        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Controller",
            LogDebug = true,
            LogInfo = true
        };

        private int pos = 0;
        private Frame[] frames = new Frame[132];

        public KeyboardTest()
        {
            for (int i = 0; i < this.frames.Length; i++)
            {
                this.frames[i] = new Frame().SetColor(i, 255, 255, 255);
            }
        }

        public Frame NextFrame(Frame bottomLayer)
        {
            this.pos += 1;
            if (this.pos > 132)
            {
                this.pos = 0;
            }

            Logger.Log("Key:" + ((Key)this.pos).ToString() + " | Value: " + this.pos, LoggerType.Info);
            return this.frames[this.pos];
        }
    }
}