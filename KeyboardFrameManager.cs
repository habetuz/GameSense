// <copyright file="KeyboardFrameManager.cs">
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
    using System.Collections.Generic;
    using GameSense.Animation;
    using SharpLog;
    using SharpLog.Output;

    /// <summary>
    /// Frame manager for all <see cref="KeyboardAnimator"/> and <see cref="KeyAnimator"/>.
    /// </summary>
    internal static class KeyboardFrameManager
    {
        /// <summary>
        /// The logger for the <see cref="KeyboardFrameManager"/> class.
        /// </summary>
        private static readonly Logger Logger = new Logger()
        {
            Ident = "GameSense/KeyboardFrameManager",
            LogDebug = false,
            Outputs = new List<IOutput>() { new ConsoleOutput(), new FileOutput() { FileName = Controller.LogFile, LogFlags = LogType.Warning | LogType.Error } },
        };

        /// <summary>
        /// List with <see cref="KeyAnimator"/> for keys that were pressed and where the animation is still going on.
        /// </summary>
        private static readonly List<KeyAnimator> PressedKeys = new List<KeyAnimator>();

        /// <summary>
        /// Gets or sets the <see cref="GameSense.Animation.IAnimator"/> for the background.
        /// </summary>
        public static KeyboardAnimator Background { get; set; } = new KeyboardColor(new int[] { 0, 0, 0 });

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
            if (Background == null)
            {
                return null;
            }

            KeyboardFrame frame = Background.NextFrame().Copy();
            Logger.Log(PressedKeys.Count + string.Empty);
            PressedKeys.ForEach(key => frame = key.NextFrame(frame));
            PressedKeys.RemoveAll(key => key.Finished);

            return frame;
        }
    }
}