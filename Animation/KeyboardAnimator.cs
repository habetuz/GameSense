// <copyright file="KeyboardAnimator.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace GameSense.Animation
{
    /// <summary>
    /// Abstract class for keyboard animations.
    /// </summary>
    public abstract class KeyboardAnimator
    {
        /// <summary>
        /// The horizontal dimension of the keyboard matrix.
        /// </summary>
        protected static readonly int DimensionX = 22;

        /// <summary>
        /// The vertical dimension of the keyboard matrix.
        /// </summary>
        protected static readonly int DimensionY = 6;

        /// <summary>
        /// Generates the next <see cref="KeyboardFrame"/> of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom <see cref="KeyboardFrame"/> the method will add its own <see cref="KeyboardFrame"/> on.</param>
        /// <returns>the next <see cref="KeyboardFrame"/>The next frame.</returns>
        public abstract KeyboardFrame NextFrame(KeyboardFrame bottomLayer = null);
    }
}