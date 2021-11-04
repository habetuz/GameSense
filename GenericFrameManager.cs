// <copyright file="MousePadAnimator.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://marvin-fuchs.de for more information
// </summary>

namespace GameSense
{
    using System;
    using System.Collections.Generic;
    using Struct.Request;
    using SharpLog;
    using SharpLog.Output;
    using GameSense.Animation.Generic;

    public class GenericFrameManager
    {
        private static readonly Logger Logger = new Logger()
        {
            Ident = "GameSense/GenericFrameManager",
            LogDebug = false,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        private readonly int numberOfZones;

        public GenericFrameManager(IAnimator background, string prefix, int numberOfZones)
        {
            if (numberOfZones <= 0)
            {
                Logger.Log(new ArgumentOutOfRangeException("numberOfZones").ToString(), LogType.Error);
                return;
            }

            this.Background = background;
            this.Prefix = prefix;
            this.numberOfZones = numberOfZones;
        }

        public IAnimator Background { get; set; }
        public string Prefix { get; set; }
        public int NumberOfZones
        {
            get
            {
                return numberOfZones;
            }
        }

        public EventBinder[] Generate()
        {
            List<EventBinder> requests = new List<EventBinder>();
            int[] frame = this.Background.NextFrame(null, this.numberOfZones);
            for(int i = 0; i < this.numberOfZones; i++)
            {
                requests.Add(new EventBinder
                {
                    Event = this.Prefix + i,
                    Data = new EventData
                    {
                        Value = frame[i]
                    }
                });
            }

            return requests.ToArray();
        }
    }
}
