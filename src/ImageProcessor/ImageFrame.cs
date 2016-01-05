// <copyright file="ImageFrame.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessor
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// Represents a single frame in a animation.
    /// </summary>
    /// <typeparam name="T">
    /// The object representing the type used to store the image pixel color components.
    /// </typeparam>
    [DebuggerDisplay("ImageFrame: {Width}x{Height}")]
    public class ImageFrame<T> : ImageBase<T>
        where T : struct, IComparable<T>, IFormattable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFrame{T}"/> class.
        /// </summary>
        public ImageFrame()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ImageFrame{T}"/> class.
        /// </summary>
        /// <param name="other">
        /// The other <see cref="ImageBase{T}"/> to create this instance from.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the given <see cref="ImageFrame{T}"/> is null.
        /// </exception>
        public ImageFrame(ImageFrame<T> other)
            : base(other)
        {
        }
    }
}
