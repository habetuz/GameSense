// <copyright file="SingleValueAnimation.cs">
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
    using System.Linq;

    /// <summary>
    /// <see cref="Animator"/> that animates a single constant value.
    /// </summary>
    public class SingleValueAnimation : Animator
    {
        /// <summary>
        /// The value the animator returns.
        /// </summary>
        private readonly int value;

        /// <summary>
        /// Just for testing. Needs to be removed before release!
        /// </summary>
        private bool on = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="SingleValueAnimation"/> class.
        /// </summary>
        /// <param name="value">The value the animator should return on <see cref="NextFrame(int[])"/></param>
        /// <param name="numberOfZones">The number of zones the animator should animate. Defines the length of the array <see cref="NextFrame(int[])"/> returns</param>
        public SingleValueAnimation(int value, int numberOfZones) : base(numberOfZones)
        {
            this.value = value;
        }

        /// <summary>
        /// Generates and returns the next frame of the animation.
        /// </summary>
        /// <param name="bottomLayer">The bottom frame the animator should render on top</param>
        /// <returns>The next frame as array with the length defined in the constructor</returns>
        public override int[] NextFrame(int[] bottomLayer)
        {
            // Testing only!
            int value = this.on ? 0 : 100;
            this.on = !this.on;
            return Enumerable.Repeat(value, NumberOfZones).ToArray();
        }
    }
}