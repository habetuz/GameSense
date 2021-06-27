// <copyright file="MouseGradient.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

using System.Collections.Generic;
using System;

namespace GameSense.Animation
{
    public class MouseGradient : IMouseAnimator
    {
        private static readonly SharpLog.Logger Logger = new SharpLog.Logger()
        {
            Ident = "GameSense/Animator/MouseGradient",
        };

        private Dictionary<MouseZone, int>[] frames;

        private int currentFrame = 0;

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

                    switch(x)
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

        public Dictionary<MouseZone, int> NextFrame(Dictionary<MouseZone, int> bottomLayer)
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
