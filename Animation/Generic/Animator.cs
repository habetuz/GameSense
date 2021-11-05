// <copyright file="Animator.cs">
// Copyright (c) 2021. All Rights Reserved
// </copyright>
// <author>
// Marvin Fuchs
// </author>
// <summary>
// Visit https://sharplog.marvin-fuchs.de for more information
// </summary>

namespace GameSense.Animation.Generic
{
    /// <summary>
    /// Abstract class for generic animators.
    /// </summary>
    public abstract class Animator
    {
        /// <summary>
        /// The number of zones the animator should animate. Defines the length of the array <see cref="NextFrame(int[])"/> returns.
        /// </summary>
        protected readonly int NumberOfZones;

        /// <summary>
        /// Initializes a new instance of the <see cref="Animator"/> class.
        /// </summary>
        /// <param name="numberOfZones">The number of zones the animator should animate. Defines the length of the array <see cref="NextFrame(int[])"/> returns</param>
        public Animator(int numberOfZones)
        {
            this.NumberOfZones = numberOfZones;
        }

        /// <summary>
        /// Generates and returns the next frame of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom frame the animator should render on top</param>
        /// <returns>The next frame as array with the length defined in the constructor</returns>
        public abstract int[] NextFrame(int[] bottomLayer);
    }
}