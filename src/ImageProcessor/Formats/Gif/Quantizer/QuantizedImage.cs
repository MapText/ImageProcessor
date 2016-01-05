// <copyright file="QuantizedImage.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessor.Formats
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents a quantized image where the pixels indexed by a color palette.
    /// </summary>
    public class QuantizedImage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantizedImage"/> class.
        /// </summary>
        /// <param name="width">The image width.</param>
        /// <param name="height">The image height.</param>
        /// <param name="palette">The color palette.</param>
        /// <param name="pixels">The quantized pixels.</param>
        public QuantizedImage(int width, int height, Color<byte>[] palette, byte[] pixels)
        {
            Guard.MustBeGreaterThan(width, 0, nameof(width));
            Guard.MustBeGreaterThan(height, 0, nameof(height));
            Guard.NotNull(palette, nameof(palette));
            Guard.NotNull(pixels, nameof(pixels));

            if (pixels.Length != width * height)
            {
                throw new ArgumentException(
                    $"Pixel array size must be {nameof(width)} * {nameof(height)}", nameof(pixels));
            }

            this.Width = width;
            this.Height = height;
            this.Palette = palette;
            this.Pixels = pixels;
        }

        /// <summary>
        /// Gets the width of this <see cref="T:QuantizedImage"/>.
        /// </summary>
        public int Width { get; }

        /// <summary>
        /// Gets the height of this <see cref="T:QuantizedImage"/>.
        /// </summary>
        public int Height { get; }

        /// <summary>
        /// Gets the color palette of this <see cref="T:QuantizedImage"/>.
        /// </summary>
        public Color<byte>[] Palette { get; }

        /// <summary>
        /// Gets the pixels of this <see cref="T:QuantizedImage"/>.
        /// </summary>
        public byte[] Pixels { get; }

        /// <summary>
        /// Converts this quantized image to a normal image.
        /// </summary>
        /// <returns>
        /// The <see cref="Image{Byte}"/>
        /// </returns>
        public Image<byte> ToImage()
        {
            Image<byte> image = new Image<byte>();

            int pixelCount = this.Pixels.Length;
            int palletCount = this.Palette.Length - 1;
            byte[] bgraPixels = new byte[pixelCount * 4];

            Parallel.For(0, pixelCount,
                i =>
                    {
                        int offset = i * 4;
                        Color<byte> color = this.Palette[Math.Min(palletCount, this.Pixels[i])];
                        bgraPixels[offset] = color.R;
                        bgraPixels[offset + 1] = color.G;
                        bgraPixels[offset + 2] = color.B;
                        bgraPixels[offset + 3] = color.A;
                    });

            image.SetPixels(this.Width, this.Height, bgraPixels);
            return image;
        }
    }
}
