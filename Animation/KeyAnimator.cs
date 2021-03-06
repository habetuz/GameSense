// <copyright file="KeyAnimator.cs">
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
    /// Abstract class for key animations
    /// </summary>
    public abstract class KeyAnimator : KeyboardAnimator
    {
        /// <summary>
        /// Gets a value indicating whether the animation has finished yet.
        /// </summary>
        public bool Finished
        {
            get
            {
                return this.InternalFinished;
            }
        }

        /// <summary>
        /// Gets or sets the key to be animated.
        /// </summary>
        public Key Key { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the animation has finished yet.
        /// </summary>
        protected bool InternalFinished { get; set; }

        /// <summary>
        /// Creates a copy of itself.
        /// </summary>
        /// <returns>The copy</returns>
        public abstract KeyAnimator Copy();
    }
}