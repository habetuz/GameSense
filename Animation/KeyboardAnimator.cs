// <copyright file="KeyboardAnimator.cs">
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
    /// Abstract class for keyboard animations.
    /// </summary>
    public abstract class KeyboardAnimator
    {
        protected static readonly int DimensionX = 22;
        protected static readonly int DimensionY = 6;

        /// <summary>
        /// Generates the next <see cref="KeyboardFrame"/> of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom <see cref="KeyboardFrame"/> the method will add it's own <see cref="KeyboardFrame"/> on.</param>
        /// <returns>the next <see cref="KeyboardFrame"/></returns>
        public abstract KeyboardFrame NextFrame(KeyboardFrame bottomLayer = null);
    }
}
