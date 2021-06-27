// <copyright file="Frame.cs">
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
    /// <summary>
    /// A class containing a color bitmap for a full keyboard effect. <seealso href="https://github.com/SteelSeries/gamesense-sdk/blob/master/doc/api/json-handlers-full-keyboard-lighting.mdx"/>
    /// </summary>
    public class Frame
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Frame"/> class.
        /// </summary>
        public Frame()
        {
            this.Bitmap = new int[132][];
            int[] standardColor = new int[3];
            for (int i = 0; i < this.Bitmap.Length; i++)
            {
                this.Bitmap[i] = standardColor;
            }
        }

        /// <summary>
        /// Gets or sets the color bitmap.
        /// </summary>
        public int[][] Bitmap { get; set; }

        /// <summary>
        /// Sets a color in the <see cref="Bitmap"/> at the index.
        /// </summary>
        /// <param name="index">The index of the <see cref="Bitmap"/></param>
        /// <param name="r">The red channel value</param>
        /// <param name="g">The green channel value</param>
        /// <param name="b">The blue channel value</param>
        /// <returns>it self</returns>
        public Frame SetColor(int index, int r, int g, int b)
        {
            return this.SetColor(index, new int[] { r, g, b });
        }

        /// <summary>
        /// Sets a color in the <see cref="Bitmap"/> at the index.
        /// </summary>
        /// <param name="index">The index of the <see cref="Bitmap"/></param>
        /// <param name="color">The color to be set (RGB format)</param>
        /// <returns>it self</returns>
        public Frame SetColor(int index, int[] color)
        {
            this.Bitmap[index] = color;
            return this;
        }

        /// <summary>
        /// Creates a copy of itself.
        /// </summary>
        /// <returns>The copy</returns>
        public Frame Copy()
        {
            int[][] copyBitmap = new int[132][];
            this.Bitmap.CopyTo(copyBitmap, 0);
            return new Frame()
            {
                Bitmap = copyBitmap
            };
        }
    }
}