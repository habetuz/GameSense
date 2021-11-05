// <copyright file="GenericFrameManager.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace GameSense
{
    using System;
    using System.Collections.Generic;
    using GameSense.Animation.Generic;
    using SharpLog;
    using SharpLog.Output;
    using Struct.Request;

    /// <summary>
    /// A generic frame manager for generic <see cref="Animator"/>.
    /// </summary>
    public class GenericFrameManager
    {
        /// <summary>
        /// The logger for the <see cref="GenericFrameManager"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger()
        {
            Ident = "GameSense/GenericFrameManager",
            LogDebug = false,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// The number of zones the <see cref="Animator"/> should animate.
        /// </summary>
        private readonly int numberOfZones;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericFrameManager"/> class.
        /// </summary>
        /// <param name="background">The background <see cref="Animator"/></param>
        /// <param name="prefix">The prefix of the events that will show up in the game sense engine. The events will be named "[prefix][numberOfZone]"</param>
        /// <param name="numberOfZones">The number of zones the <see cref="Animator"/> should animate</param>
        public GenericFrameManager(Animator background, string prefix, int numberOfZones)
        {
            if (numberOfZones <= 0)
            {
                Logger.Log(new ArgumentOutOfRangeException("NumberOfZones").ToString(), LogType.Error);
                return;
            }

            this.Background = background;
            this.Prefix = prefix;
            this.numberOfZones = numberOfZones;
        }

        /// <summary>
        /// Gets or sets the background <see cref="Animator"/>.
        /// </summary>
        public Animator Background { get; set; }

        /// <summary>
        /// Gets or sets the prefix that will be used to bind and fire the events to the game sense engine.
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// Gets the number of zones the frame manager has.
        /// </summary>
        public int NumberOfZones
        {
            get
            {
                return this.numberOfZones;
            }
        }

        /// <summary>
        /// Generates an array containing the events of the next frame using <see cref="Animator.NextFrame(int[])"/>.
        /// </summary>
        /// <returns>The array containing the events of the next frame</returns>
        public EventBinder[] Generate()
        {
            List<EventBinder> requests = new List<EventBinder>();
            int[] frame = this.Background.NextFrame(null);
            for (int i = 0; i < this.numberOfZones; i++)
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