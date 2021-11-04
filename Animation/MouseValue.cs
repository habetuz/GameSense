// <copyright file="MouseGradient.cs">
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
    using System.Collections.Generic;
    using System;
    using SharpLog.Output;
    using SharpLog;

    public class MouseValue : MouseAnimator
    {
        private static readonly Logger Logger = new Logger()
        {
            Ident = "GameSense/Animator/MosueColor",
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        private Dictionary<MouseZone, int> Frame = new Dictionary<MouseZone, int>();


        public MouseValue(int value)
        {
            foreach(MouseZone zone in Enum.GetValues(typeof(MouseZone)))
            {
                Frame.Add(zone, value);
            }
        }

        public override Dictionary<MouseZone, int> NextFrame(Dictionary<MouseZone, int> bottomLayer)
        {
            return Frame;
        }
    }
}

