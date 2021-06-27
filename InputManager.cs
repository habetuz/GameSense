// <copyright file="InputManager.cs">
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
    using System.Windows.Forms;
    using GameSense.Animation;
    using Gma.System.MouseKeyHook;
    using SharpLog;

    /// <summary>
    /// Class responsible for managing keyboard and mouse inputs.
    /// </summary>
    public class InputManager
    {
        private static readonly IKeyboardMouseEvents GlobalHook = Hook.GlobalEvents();

        private static readonly MassLogger Logger = new MassLogger(300000)
        {
            Ident = "GameSense/InputManager",
            LogDebug = true,
            InfoLogText = "Inputs"
        };

        static InputManager()
        {
            Logger.Log("Starting...", LoggerType.Info, true);
            GlobalHook.KeyDown += KeyEvent;
            GlobalHook.MouseDownExt += MouseEvent;
            Logger.Log("Ready!", LoggerType.Info, true);
        }

        /// <summary>
        /// Gets or sets the default <see cref="IKeyAnimator"/> for key presses.
        /// </summary>
        public static IKeyAnimator DefaultKeyAnimation { get; set; }

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
        }

        private static void KeyEvent(object sender, KeyEventArgs eventArgs)
        {
            try
            {
                Logger.Log(((Key)Enum.Parse(typeof(Key), eventArgs.KeyCode.ToString())).ToString(), LoggerType.Info);
                Logger.Log(((Key)Enum.Parse(typeof(Key), eventArgs.KeyCode.ToString())).ToString());
                IKeyAnimator animation = DefaultKeyAnimation.Create();
                animation.Key = (Key)Enum.Parse(typeof(Key), eventArgs.KeyCode.ToString());
                KeyboardFrameManager.AddKeyAnimation(animation);
            }
            catch (ArgumentException)
            {
                Logger.Log("Key " + eventArgs.KeyCode.ToString() + " does not exist", LoggerType.Warning);
            }
        }

        private static void MouseEvent(object sender, MouseEventArgs eventArgs)
        {
            Logger.Log(eventArgs.Button.ToString(), LoggerType.Info);
        }
    }
}
