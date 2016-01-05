// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BmpDecoder.cs" company="James Jackson-South">
//   Copyright (c) James Jackson-South and contributors.
//   Licensed under the Apache License, Version 2.0.
// </copyright>
// <summary>
//   Image decoder for generating an image out of a Windows bitmap stream.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ImageProcessor.Formats
{
    using System;
    using System.IO;

    /// <summary>
    /// Image decoder for generating an image out of a Windows bitmap stream.
    /// </summary>
    /// <remarks>
    /// Does not support the following formats at the moment:
    /// <list type="bullet">
    ///    <item>JPG</item>
    ///    <item>PNG</item>
    ///    <item>RLE4</item>
    ///    <item>RLE8</item>
    ///    <item>BitFields</item>
    /// </list>
    /// Formats will be supported in a later releases. We advise always
    /// to use only 24 Bit Windows bitmaps.
    /// </remarks>
    public class BmpDecoder : IImageDecoder
    {
        /// <inheritdoc/>
        public int HeaderSize => 2;

        /// <inheritdoc/>
        public bool IsSupportedFileExtension(string extension)
        {
            Guard.NotNullOrEmpty(extension, "extension");

            extension = extension.StartsWith(".") ? extension.Substring(1) : extension;

            return extension.Equals("BMP", StringComparison.OrdinalIgnoreCase)
                || extension.Equals("DIP", StringComparison.OrdinalIgnoreCase);
        }

        /// <inheritdoc/>
        public bool IsSupportedFileFormat(byte[] header)
        {
            bool isBmp = false;
            if (header.Length >= 2)
            {
                isBmp = header[0] == 0x42 && // B
                        header[1] == 0x4D;   // M
            }

            return isBmp;
        }

        /// <inheritdoc/>
        public void Decode<T>(Image<T> image, Stream stream)
            where T : struct, IComparable<T>, IFormattable
        {
            new BmpDecoderCore().Decode(image, stream);
        }
    }
}
