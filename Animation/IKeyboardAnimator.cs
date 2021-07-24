// <copyright file="IKeyboardAnimator.cs">
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
    /// <summary>
    /// Interface for keyboard animations.
    /// </summary>
    public interface IKeyboardAnimator
    {
        /// <summary>
        /// Generates the next <see cref="KeyboardFrame"/>.
        /// </summary>
        /// <param name="bottomLayer">The bottom <see cref="KeyboardFrame"/> the method will add it's own <see cref="KeyboardFrame"/> on.</param>
        /// <returns>the next <see cref="KeyboardFrame"/></returns>
        KeyboardFrame NextFrame(KeyboardFrame bottomLayer = null);
    }
}
