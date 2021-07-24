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

    /// <summary>
    /// Keeps track of all <see cref="GameSense.Animation.IAnimator"/> and combines the <see cref="GameSense.Struct.Frame"/>s from <see cref="GameSense.Animation.IAnimator.NextFrame(Struct.Frame)"/> to one final <see cref="GameSense.Struct.Frame"/>
    /// </summary>
    static class KeyboardFrameManager
    {
        private static readonly Logger Logger = new Logger()
        {
            Ident = "KeyboardFrameManager",
            LogDebug = false
        };

        private static readonly List<IKeyAnimator> PressedKeys = new List<IKeyAnimator>();
        private static IKeyboardAnimator background;

        /// <summary>
        /// Sets the <see cref="GameSense.Animation.IAnimator"/> for the background.
        /// </summary>
        public static IKeyboardAnimator Background
        {
            set { background = value; }
        }

        /// <summary>
        /// Adds a <see cref="IKeyAnimator"/> for a <see cref="Key"/>. Removes any excising <see cref="IKeyAnimator"/> for the <see cref="Key"/> of the given parameter.
        /// </summary>
        /// <param name="keyAnimation">The <see cref="IKeyAnimator"/> to be added.</param>
        public static void AddKeyAnimation(IKeyAnimator keyAnimation)
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
