// <copyright file="MouseGradient.cs">
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
    /// A <see cref="KeyboardAnimator"/> that generates a gradient background effect.
    /// </summary>
    public class MouseGradient : MouseAnimator
    {
        /// <summary>
        /// Logger for the <see cref="MouseGradient"/> class.
        /// </summary>
        private static readonly Logger Logger = new SharpLog.Logger()
        {
            Ident = "GameSense/Animator/MouseGradient",
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// The current frame of the animation.
        /// </summary>
        private int currentFrame = 0;

        /// <summary>
        /// Array with all frames of the animation.
        /// </summary>
        private Dictionary<MouseZone, int>[] frames;

        /// <summary>
        /// Initializes a new instance of the <see cref="MouseGradient"/> class.
        /// </summary>
        /// <param name="time">The speed of the animation. The speed is dependent on the <see cref="GameSense.Controller.UpdateInterval"/>.</param>
        /// <param name="length">How long the gradient is compared to the keyboard. The gradient is 'length'*keyboard long. Default: 1</param>
        public MouseGradient(int time, int length)
        {
            List<Dictionary<MouseZone, int>> frames = new List<Dictionary<MouseZone, int>>();

            int[] gradient = new int[5 * time * length];

            double frameChange = 100.0 / (double)gradient.Length * 2.0;

            // Generate gradient.
            for (int i = 0; i < gradient.Length / 2; i++)
            {
                gradient[i] = (int)Math.Round(i * frameChange);
            }

            for (int i = 0; i < gradient.Length / 2; i++)
            {
                gradient[i + (gradient.Length / 2)] = 100 - (int)Math.Round(i * frameChange);
            }

            for (int i = 0; i < gradient.Length; i++)
            {
                if (i == gradient.Length / 2)
                {
                    Logger.Log("Switching direction!");
                }

                Logger.Log("Gradient at " + i + ": " + gradient[i]);
            }

            for (int i = 0; i < gradient.Length; i++)
            {
                // Generate bitmap
                Dictionary<MouseZone, int> frame = new Dictionary<MouseZone, int>();
                for (int x = 0; x < 5; x++)
                {
                    int index = (x * time) + i;
                    if (index >= gradient.Length)
                    {
                        index -= index / gradient.Length * gradient.Length;
                    }

                    switch (x)
                    {
                        case 0:
                            frame.Add(MouseZone.Wheel, gradient[index]);
                            break;

                        case 1:
                            frame.Add(MouseZone.Left1, gradient[index]);
                            frame.Add(MouseZone.Right1, gradient[index]);
                            break;

                        case 2:
                            frame.Add(MouseZone.Left2, gradient[index]);
                            frame.Add(MouseZone.Right2, gradient[index]);
                            break;

                        case 3:
                            frame.Add(MouseZone.Left3, gradient[index]);
                            frame.Add(MouseZone.Right3, gradient[index]);
                            break;

                        case 4:
                            frame.Add(MouseZone.Logo, gradient[index]);
                            break;
                    }
                }

                frames.Add(frame);
            }

            this.frames = frames.ToArray();
        }

        /// <summary>
        /// Generates the next frame as dictionary of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom layer the animator should render on top.</param>
        /// <returns>The next frame.</returns>
        public override Dictionary<MouseZone, int> NextFrame(Dictionary<MouseZone, int> bottomLayer)
        {
            if (this.currentFrame >= this.frames.Length)
            {
                this.currentFrame = 0;
            }

            this.currentFrame++;
            return this.frames[this.currentFrame];
        }
    }
}