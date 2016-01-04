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
        IColor<T> Compress(IColor<T> color);

        IColor<T> Expand(IColor<T> color);

        IColor<T> Lerp(IColor<T> from, IColor<T> to, T amount);
    }
}
