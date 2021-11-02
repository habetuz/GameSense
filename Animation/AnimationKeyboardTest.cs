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

    class KeyboardTest : KeyboardAnimator
    {
        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Controller",
            LogDebug = true,
            LogInfo = true
        };

        private int pos = 0;
        private KeyboardFrame[] frames = new KeyboardFrame[132];

        public KeyboardTest()
        {
            for (int i = 0; i < this.frames.Length; i++)
            {
                this.frames[i] = new KeyboardFrame().SetColor(i, 255, 255, 255);
            }
        }

        public override KeyboardFrame NextFrame(KeyboardFrame bottomLayer)
        {
            this.pos += 1;
            if (this.pos > 132)
            {
                this.pos = 0;
            }

            Logger.Log("Key:" + ((Key)this.pos).ToString() + " | Value: " + this.pos, LogType.Info);
            return this.frames[this.pos];
        }
    }
}