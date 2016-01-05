// <copyright file="IColor.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessor.Colors
{
    /// <summary>
    /// Encapsulates properties and methods that define a color.
    /// </summary>
    /// <typeparam name="T">
    /// The object representing the type to store the image pixel color components.
    /// </typeparam>
    public interface IColor<T>
        where T : struct
    {
        /// <summary>
        /// Gets or sets the red component of the color.
        /// </summary>
        T R { get; set; }

        /// <summary>
        /// Gets or sets the green component of the color.
        /// </summary>
        T G { get; set; }

        /// <summary>
        /// Gets or sets the blue component of the color.
        /// </summary>
        T B { get; set; }

        /// <summary>
        /// Gets or sets the alpha component of the color.
        /// </summary>
        T A { get; set; }
    }
}
