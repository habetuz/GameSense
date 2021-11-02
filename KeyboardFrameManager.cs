// <copyright file="KeyboardFrameManager.cs">
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
    using System.Collections.Generic;
    using GameSense.Animation;
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// Keeps track of all <see cref="GameSense.Animation.IAnimator"/> and combines the <see cref="GameSense.Struct.Frame"/>s from <see cref="GameSense.Animation.IAnimator.NextFrame(Struct.Frame)"/> to one final <see cref="GameSense.Struct.Frame"/>
    /// </summary>
    static class KeyboardFrameManager
    {
        private static readonly Logger Logger = new Logger()
        {
            Ident = "KeyboardFrameManager",
            LogDebug = false,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        private static readonly List<KeyAnimator> PressedKeys = new List<KeyAnimator>();
        private static KeyboardAnimator background = new KeyboardColor(new int[] { 0, 0, 0 });

        /// <summary>
        /// Sets the <see cref="GameSense.Animation.IAnimator"/> for the background.
        /// </summary>
        public static KeyboardAnimator Background
        {
            set { background = value; }
        }

        /// <summary>
        /// Adds a <see cref="KeyAnimator"/> for a <see cref="Key"/>. Removes any excising <see cref="KeyAnimator"/> for the <see cref="Key"/> of the given parameter.
        /// </summary>
        /// <param name="keyAnimation">The <see cref="KeyAnimator"/> to be added.</param>
        public static void AddKeyAnimation(KeyAnimator keyAnimation)
        {
            Logger.Log(PressedKeys.TrueForAll(animator => animator.Key != keyAnimation.Key) + string.Empty);
            PressedKeys.RemoveAll(animator => animator.Key == keyAnimation.Key);
            PressedKeys.Add(keyAnimation);
        }

        /// <summary>
        /// Combines all stored <see cref="GameSense.Animation.IAnimator"/> to one <see cref="GameSense.Struct.Frame"/> by calling their <see cref="GameSense.Animation.IAnimator.NextFrame(KeyboardFrame)"/> method.
        /// </summary>
        /// <returns>The combined <see cref="GameSense.Struct.Frame"/></returns>
        public static KeyboardFrame Generate()
        {
            if (background == null) return null;

            KeyboardFrame frame = background.NextFrame().Copy();
            Logger.Log(PressedKeys.Count + string.Empty);
            PressedKeys.ForEach(key => frame = key.NextFrame(frame));
            PressedKeys.RemoveAll(key => key.Finished);

            return frame;
        }
    }
}
