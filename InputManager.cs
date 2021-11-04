﻿// <copyright file="InputManager.cs">
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
    using System.Windows.Forms;
    using GameSense.Animation;
    using Gma.System.MouseKeyHook;
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// Class responsible for managing keyboard and mouse inputs.
    /// </summary>
    static class InputManager
    {
        private static readonly IKeyboardMouseEvents GlobalHook = Hook.GlobalEvents();

        private static readonly MassLogger Logger = new MassLogger(30 * 60000)
        {
            Ident = "GameSense/InputManager",
            LogDebug = false,
            InfoLogText = "Inputs",
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        static InputManager()
        {
            Logger.Log("Starting...", LogType.Info, true);
            GlobalHook.KeyDown += KeyEvent;
            GlobalHook.MouseDownExt += MouseEvent;
            Logger.Log("Ready!", LogType.Info, true);
        }

        /// <summary>
        /// Gets or sets the default <see cref="KeyAnimator"/> for key presses.
        /// </summary>
        public static KeyAnimator DefaultKeyAnimation { get; set; }

        /// <summary>
        /// Starts the <see cref="InputManager"/>
        /// </summary>
        public static void Start()
        {
        }

        /// <summary>
        /// Stops the <see cref="InputManager"/>. Should be called at the end of the program.
        /// </summary>
        public static void Stop()
        {
            GlobalHook.MouseDownExt -= MouseEvent;
            GlobalHook.KeyDown -= KeyEvent;

            GlobalHook.Dispose();

            Logger.Log("Closed!", LogType.Info, instant: true);
        }

        private static void KeyEvent(object sender, KeyEventArgs eventArgs)
        {
            try
            {
                Logger.Log(((Key)Enum.Parse(typeof(Key), eventArgs.KeyCode.ToString())).ToString(), LogType.Info);
                Logger.Log(((Key)Enum.Parse(typeof(Key), eventArgs.KeyCode.ToString())).ToString());
                KeyAnimator animation = DefaultKeyAnimation.Copy();
                animation.Key = (Key)Enum.Parse(typeof(Key), eventArgs.KeyCode.ToString());
                KeyboardFrameManager.AddKeyAnimation(animation);
            }
            catch (ArgumentException)
            {
                Logger.Log("Key " + eventArgs.KeyCode.ToString() + " does not exist", LogType.Warning);
            }
        }

        private static void MouseEvent(object sender, MouseEventArgs eventArgs)
        {
            Logger.Log(eventArgs.Button.ToString(), LogType.Info);
            Logger.Log(eventArgs.Button.ToString());

        }
    }
}
