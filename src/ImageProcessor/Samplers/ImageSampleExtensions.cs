﻿// <copyright file="ImageSampleExtensions.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessor.Samplers
{
    /// <summary>
    /// Extensions methods for <see cref="Image"/> to apply samplers to the image.
    /// </summary>
    public static class ImageSampleExtensions
    {
        /// <summary>
        /// Crops an image to the given width and height.
        /// </summary>
        /// <param name="source">The image to resize.</param>
        /// <param name="width">The target image width.</param>
        /// <param name="height">The target image height.</param>
        /// <returns>The <see cref="Image"/></returns>
        public static Image Crop(this Image source, int width, int height)
        {
            return Crop(source, width, height, source.Bounds);
        }

        /// <summary>
        /// Crops an image to the given width and height with the given source rectangle.
        /// <remarks>
        /// If the source rectangle is smaller than the target dimensions then the
        /// area within the source is resized performing a zoomed crop.
        /// </remarks>
        /// </summary>
        /// <param name="source">The image to crop.</param>
        /// <param name="width">The target image width.</param>
        /// <param name="height">The target image height.</param>
        /// <param name="sourceRectangle">
        /// The <see cref="Rectangle"/> structure that specifies the portion of the image object to draw.
        /// </param>
        /// <returns>The <see cref="Image"/></returns>
        public static Image Crop(this Image source, int width, int height, Rectangle sourceRectangle)
        {
            if (sourceRectangle.Width < width || sourceRectangle.Height < height)
            {
                // If the source rectangle is smaller than the target perform a
                // cropped zoom.
                source = source.Resize(sourceRectangle.Width, sourceRectangle.Height);
            }

            return source.Process(width, height, sourceRectangle, new Rectangle(0, 0, width, height), new Crop());
        }

        /// <summary>
        /// Crops an image to the area of greatest entropy.
        /// </summary>
        /// <param name="source">The image to crop.</param>
        /// <param name="threshold">The threshold for entropic density.</param>
        /// <returns>The <see cref="Image"/></returns>
        public static Image EntropyCrop(this Image source, float threshold = .5f)
        {
            return source.Process(source.Width, source.Height, source.Bounds, source.Bounds, new EntropyCrop(threshold));
        }

        /// <summary>
        /// Resizes an image to the given width and height.
        /// </summary>
        /// <param name="source">The image to resize.</param>
        /// <param name="width">The target image width.</param>
        /// <param name="height">The target image height.</param>
        /// <returns>The <see cref="Image"/></returns>
        /// <remarks>Passing zero for one of height or width will automatically preserve the aspect ratio of the original image</remarks>
        public static Image Resize(this Image source, int width, int height)
        {
            return Resize(source, width, height, new BicubicResampler());
        }

        /// <summary>
        /// Resizes an image to the given width and height with the given sampler.
        /// </summary>
        /// <param name="source">The image to resize.</param>
        /// <param name="width">The target image width.</param>
        /// <param name="height">The target image height.</param>
        /// <param name="sampler">The <see cref="IResampler"/> to perform the resampling.</param>
        /// <returns>The <see cref="Image"/></returns>
        /// <remarks>Passing zero for one of height or width will automatically preserve the aspect ratio of the original image</remarks>
        public static Image Resize(this Image source, int width, int height, IResampler sampler)
        {
            return Resize(source, width, height, sampler, source.Bounds);
        }

        /// <summary>
        /// Resizes an image to the given width and height with the given sampler and
        /// source rectangle.
        /// </summary>
        /// <param name="source">The image to resize.</param>
        /// <param name="width">The target image width.</param>
        /// <param name="height">The target image height.</param>
        /// <param name="sampler">The <see cref="IResampler"/> to perform the resampling.</param>
        /// <param name="sourceRectangle">
        /// The <see cref="Rectangle"/> structure that specifies the portion of the image object to draw.
        /// </param>
        /// <returns>The <see cref="Image"/></returns>
        /// <remarks>Passing zero for one of height or width will automatically preserve the aspect ratio of the original image</remarks>
        public static Image Resize(this Image source, int width, int height, IResampler sampler, Rectangle sourceRectangle)
        {
            if (width == 0 && height > 0)
            {
                width = source.Width * height / source.Height;
            }

            if (height == 0 && width > 0)
            {
                height = source.Height * width / source.Width;
            }

            return source.Process(width, height, sourceRectangle, new Rectangle(0, 0, width, height), new Resize(sampler));
        }

        /// <summary>
        /// Rotates an image by the given angle in degrees.
        /// </summary>
        /// <param name="source">The image to resize.</param>
        /// <param name="degrees">The angle in degrees to perform the rotation.</param>
        /// <returns>The <see cref="Image"/></returns>
        public static Image Rotate(this Image source, float degrees)
        {
            return Rotate(source, degrees, new BicubicResampler());
        }

        /// <summary>
        /// Rotates an image by the given angle in degrees.
        /// </summary>
        /// <param name="source">The image to resize.</param>
        /// <param name="degrees">The angle in degrees to perform the rotation.</param>
        /// <param name="sampler">The <see cref="IResampler"/> to perform the resampling.</param>
        /// <returns>The <see cref="Image"/></returns>
        public static Image Rotate(this Image source, float degrees, IResampler sampler)
        {
            return source.Process(source.Width, source.Height, source.Bounds, source.Bounds, new Rotate(sampler) { Angle = degrees });
        }

        /// <summary>
        /// Rotates and flips an image by the given instructions.
        /// </summary>
        /// <param name="source">The image to resize.</param>
        /// <param name="rotateType">The <see cref="RotateType"/> to perform the rotation.</param>
        /// <param name="flipType">The <see cref="FlipType"/> to perform the flip.</param>
        /// <returns>The <see cref="Image"/></returns>
        public static Image RotateFlip(this Image source, RotateType rotateType, FlipType flipType)
        {
            return source.Process(source.Width, source.Height, source.Bounds, source.Bounds, new RotateFlip(rotateType, flipType));
        }
    }
}
