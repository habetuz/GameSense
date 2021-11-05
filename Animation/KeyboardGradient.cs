// <copyright file="KeyboardGradient.cs">
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
    /// A <see cref="KeyboardAnimator"/> that generates a gradient background effect. The gradient gets animated moving from right to left.
    /// </summary>
    public class KeyboardGradient : KeyboardAnimator
    {
        /// <summary>
        /// The logger of the <see cref="KeyboardGradient"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger
        {
            Ident = "GameSense/Animator/KeyboardGradient",
            LogDebug = false,
            LogInfo = true,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// The current frame of the animation.
        /// </summary>
        private int currentFrame = 0;

        /// <summary>
        /// Array containing all frames of the animation.
        /// </summary>
        private KeyboardFrame[] frames;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyboardGradient"/> class.
        /// </summary>
        /// <param name="color1">The left color of the gradient (RGB format).</param>
        /// <param name="color2">The right color of the gradient (RGB format).</param>
        /// <param name="time">The speed of the animation. The speed is dependent on the <see cref="GameSense.Controller.UpdateInterval"/>. It needs 22*speed' <see cref="GameSense.Animation.KeyboardAnimator.NextFrame(KeyboardFrame)"/> calls for one full animation cycle. Default: 1</param>
        /// <param name="length">How long the gradient is compared to the keyboard. The gradient is 'length'*keyboard long. Default: 1</param>
        public KeyboardGradient(int[] color1, int[] color2, int time = 1, int length = 1)
        {
            List<KeyboardFrame> frames = new List<KeyboardFrame>();
            int[][] gradient = new int[DimensionX * time * length][];
            int[] difference = new int[]
            {
                color2[0] - color1[0],
                color2[1] - color1[1],
                color2[2] - color1[2]
            };
            double[] frameChange = new double[]
            {
                (double)difference[0] / (double)gradient.Length * 2.0,
                (double)difference[1] / (double)gradient.Length * 2.0,
                (double)difference[2] / (double)gradient.Length * 2.0,
            };
            Logger.Log("GradientLength: " + gradient.Length);
            Logger.Log("color1:         " + color1[0] + "|" + color1[1] + "|" + color1[2]);
            Logger.Log("color2:         " + color2[0] + "|" + color2[1] + "|" + color2[2]);
            Logger.Log("Difference:     " + difference[0] + "|" + difference[1] + "|" + difference[2]);
            Logger.Log("FrameChange:    " + frameChange[0] + "|" + frameChange[1] + "|" + frameChange[2]);
            for (int i = 0; i < gradient.Length / 2; i++)
            {
                gradient[i] = new int[]
                {
                    color1[0] + (int)Math.Round(i * frameChange[0]),
                    color1[1] + (int)Math.Round(i * frameChange[1]),
                    color1[2] + (int)Math.Round(i * frameChange[2])
                };
            }

            for (int i = 0; i < gradient.Length / 2; i++)
            {
                gradient[i + (gradient.Length / 2)] = new int[]
                {
                    color2[0] - (int)Math.Round(i * frameChange[0]),
                    color2[1] - (int)Math.Round(i * frameChange[1]),
                    color2[2] - (int)Math.Round(i * frameChange[2])
                };
            }

            for (int i = 0; i < gradient.Length; i++)
            {
                if (i == gradient.Length / 2)
                {
                    Logger.Log("Switching direction!");
                }

                Logger.Log("Gradient at " + i + ": " + gradient[i][0] + "|" + gradient[i][1] + "|" + gradient[i][2]);
            }

            for (int i = 0; i < gradient.Length; i++)
            {
                // Generate bitmap
                KeyboardFrame frame = new KeyboardFrame();
                for (int x = 0; x < KeyboardAnimator.DimensionX; x++)
                {
                    int index = (x * time) + i;
                    if (index >= gradient.Length)
                    {
                        index -= index / gradient.Length * gradient.Length;
                    }

                    for (int y = 0; y < KeyboardAnimator.DimensionY; y++)
                    {
                        frame.Bitmap[x + (KeyboardAnimator.DimensionX * y)] = gradient[index];
                    }
                }

                frames.Add(frame);
            }

            this.frames = frames.ToArray();
            Logger.Log(this.frames.Length + " frames rendered");
        }

        /// <summary>
        /// Generates the next <see cref="KeyboardFrame"/> of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom <see cref="KeyboardFrame"/> the method will add its own <see cref="KeyboardFrame"/> on.</param>
        /// <returns>the next <see cref="KeyboardFrame"/></returns>
        public override KeyboardFrame NextFrame(KeyboardFrame bottomLayer)
        {
            KeyboardFrame frame = this.frames[this.currentFrame];
            Logger.Log("frame:" + this.currentFrame);
            this.currentFrame++;
            if (this.currentFrame >= this.frames.Length)
            {
                this.currentFrame = 0;
            }

            return frame;
        }
    }
}