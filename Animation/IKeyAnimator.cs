// <copyright file="IKeyAnimator.cs">
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
    /// Interface for key animations
    /// </summary>
    public interface IKeyAnimator : IKeyboardAnimator
    {
        /// <summary>
        /// Gets a value indicating whether the animation has finished yet.
        /// </summary>
        bool Finished { get; }

        /// <summary>
        /// Gets or sets the key to be animated.
        /// </summary>
        Key Key { get; set; }

        /// <summary>
        /// Creates a copy of itself.
        /// </summary>
        /// <returns>The copy</returns>
        IKeyAnimator Copy();
    }
}
