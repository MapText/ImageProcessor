// <copyright file="Quantizer.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessor.Formats
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Encapsulates methods to calculate the color palette of an image.
    /// </summary>
    public abstract class Quantizer : IQuantizer
    {
        /// <summary>
        /// Flag used to indicate whether a single pass or two passes are needed for quantization.
        /// </summary>
        private readonly bool singlePass;

        /// <summary>
        /// Initializes a new instance of the <see cref="Quantizer"/> class.
        /// </summary>
        /// <param name="singlePass">
        /// If true, the quantization only needs to loop through the source pixels once
        /// </param>
        /// <remarks>
        /// If you construct this class with a true value for singlePass, then the code will, when quantizing your image,
        /// only call the 'QuantizeImage' function. If two passes are required, the code will call 'InitialQuantizeImage'
        /// and then 'QuantizeImage'.
        /// </remarks>
        protected Quantizer(bool singlePass)
        {
            this.singlePass = singlePass;
        }

        /// <summary>
        /// Quantize an image and return the resulting output pixels.
        /// </summary>
        /// <param name="imageBase">The image to quantize.</param>
        /// <returns>
        /// A <see cref="T:byte[]"/> representing a quantized version of the image pixels.
        /// </returns>
        public QuantizedImage Quantize<T>(ImageBase<T> imageBase)
            where T : struct, IComparable<T>, IFormattable
        {
            // Get the size of the source image
            int height = imageBase.Height;
            int width = imageBase.Width;

            // Call the FirstPass function if not a single pass algorithm.
            // For something like an Octree quantizer, this will run through
            // all image pixels, build a data structure, and create a palette.
            if (!this.singlePass)
            {
                this.FirstPass(imageBase, width, height);
            }

            byte[] quantizedPixels = new byte[width * height];

            // Get the pallete
            List<Color<byte>> palette = this.GetPalette();

            this.SecondPass(imageBase, quantizedPixels, width, height);

            return new QuantizedImage(width, height, palette.ToArray(), quantizedPixels);
        }

        /// <summary>
        /// Execute the first pass through the pixels in the image
        /// </summary>
        /// <param name="source">The source data</param>
        /// <param name="width">The width in pixels of the image.</param>
        /// <param name="height">The height in pixels of the image.</param>
        protected virtual void FirstPass<T>(ImageBase<T> source, int width, int height)
            where T : struct, IComparable<T>, IFormattable
        {
            // Loop through each row
            for (int y = 0; y < height; y++)
            {
                // And loop through each column
                for (int x = 0; x < width; x++)
                {
                    // Now I have the pixel, call the FirstPassQuantize function...
                    this.InitialQuantizePixel(Color<byte>.Cast(source[x, y]));
                }
            }
        }

        /// <summary>
        /// Execute a second pass through the bitmap
        /// </summary>
        /// <param name="source">The source image.</param>
        /// <param name="output">The output pixel array</param>
        /// <param name="width">The width in pixels of the image</param>
        /// <param name="height">The height in pixels of the image</param>
        protected virtual void SecondPass<T>(ImageBase<T> source, byte[] output, int width, int height)
            where T : struct, IComparable<T>, IFormattable
        {
            int i = 0;

            // Convert the first pixel, so that I have values going into the loop.
            // Implicit cast here from Color.
            Color<byte> previousPixel = Color<byte>.Cast(source[0, 0]);
            byte pixelValue = this.QuantizePixel(previousPixel);

            output[0] = pixelValue;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color<byte> sourcePixel = Color<byte>.Cast(source[x, y]);

                    // Check if this is the same as the last pixel. If so use that value
                    // rather than calculating it again. This is an inexpensive optimization.
                    if (sourcePixel != previousPixel)
                    {
                        // Quantize the pixel
                        pixelValue = this.QuantizePixel(sourcePixel);

                        // And setup the previous pointer
                        previousPixel = sourcePixel;
                    }

                    output[i++] = pixelValue;
                }
            }
        }

        /// <summary>
        /// Override this to process the pixel in the first pass of the algorithm
        /// </summary>
        /// <param name="pixel">
        /// The pixel to quantize
        /// </param>
        /// <remarks>
        /// This function need only be overridden if your quantize algorithm needs two passes,
        /// such as an Octree quantizer.
        /// </remarks>
        protected virtual void InitialQuantizePixel(Color<byte> pixel)
        {
        }

        /// <summary>
        /// Override this to process the pixel in the second pass of the algorithm
        /// </summary>
        /// <param name="pixel">
        /// The pixel to quantize
        /// </param>
        /// <returns>
        /// The quantized value
        /// </returns>
        protected abstract byte QuantizePixel(Color<byte> pixel);

        /// <summary>
        /// Retrieve the palette for the quantized image
        /// </summary>
        /// <returns>
        /// The new color palette
        /// </returns>
        protected abstract List<Color<byte>> GetPalette();
    }
}