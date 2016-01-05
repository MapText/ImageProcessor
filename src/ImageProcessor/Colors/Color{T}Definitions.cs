// <copyright file="Color{T}Definitions.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessor
{
    using System;

    /// <summary>
    /// Represents a four-component color using red, green, blue, and alpha data. 
    /// Each component is stored in premultiplied format multiplied by the alpha component.
    /// </summary>
    /// <typeparam name="T">
    /// The object representing the type to store the color components.
    /// </typeparam>
    public partial struct Color<T>
        where T : struct, IComparable<T>, IFormattable
    {
        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F0F8FF.
        /// </summary>
        public static readonly Color<T> AliceBlue = new Color<T>((T)(object)240, (T)(object)248, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FAEBD7.
        /// </summary>
        public static readonly Color<T> AntiqueWhite = new Color<T>((T)(object)250, (T)(object)235, (T)(object)215, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #00FFFF.
        /// </summary>
        public static readonly Color<T> Aqua = new Color<T>((T)(object)0, (T)(object)1, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #7FFFD4.
        /// </summary>
        public static readonly Color<T> Aquamarine = new Color<T>((T)(object)127, (T)(object)1, (T)(object)212, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F0FFFF.
        /// </summary>
        public static readonly Color<T> Azure = new Color<T>((T)(object)240, (T)(object)1, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F5F5DC.
        /// </summary>
        public static readonly Color<T> Beige = new Color<T>((T)(object)245, (T)(object)245, (T)(object)220, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFE4C4.
        /// </summary>
        public static readonly Color<T> Bisque = new Color<T>((T)(object)1, (T)(object)228, (T)(object)196, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #000000.
        /// </summary>
        public static readonly Color<T> Black = new Color<T>((T)(object)0, (T)(object)0, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFEBCD.
        /// </summary>
        public static readonly Color<T> BlanchedAlmond = new Color<T>((T)(object)1, (T)(object)235, (T)(object)205, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #0000FF.
        /// </summary>
        public static readonly Color<T> Blue = new Color<T>((T)(object)0, (T)(object)0, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #8A2BE2.
        /// </summary>
        public static readonly Color<T> BlueViolet = new Color<T>((T)(object)138, (T)(object)43, (T)(object)226, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #A52A2A.
        /// </summary>
        public static readonly Color<T> Brown = new Color<T>((T)(object)165, (T)(object)42, (T)(object)42, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #DEB887.
        /// </summary>
        public static readonly Color<T> BurlyWood = new Color<T>((T)(object)222, (T)(object)184, (T)(object)135, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #5F9EA0.
        /// </summary>
        public static readonly Color<T> CadetBlue = new Color<T>((T)(object)95, (T)(object)158, (T)(object)160, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #7FFF00.
        /// </summary>
        public static readonly Color<T> Chartreuse = new Color<T>((T)(object)127, (T)(object)1, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #D2691E.
        /// </summary>
        public static readonly Color<T> Chocolate = new Color<T>((T)(object)210, (T)(object)105, (T)(object)30, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF7F50.
        /// </summary>
        public static readonly Color<T> Coral = new Color<T>((T)(object)1, (T)(object)127, (T)(object)80, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #6495ED.
        /// </summary>
        public static readonly Color<T> CornflowerBlue = new Color<T>((T)(object)100, (T)(object)149, (T)(object)237, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFF8DC.
        /// </summary>
        public static readonly Color<T> Cornsilk = new Color<T>((T)(object)1, (T)(object)248, (T)(object)220, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #DC143C.
        /// </summary>
        public static readonly Color<T> Crimson = new Color<T>((T)(object)220, (T)(object)20, (T)(object)60, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #00FFFF.
        /// </summary>
        public static readonly Color<T> Cyan = new Color<T>((T)(object)0, (T)(object)1, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #00008B.
        /// </summary>
        public static readonly Color<T> DarkBlue = new Color<T>((T)(object)0, (T)(object)0, (T)(object)139, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #008B8B.
        /// </summary>
        public static readonly Color<T> DarkCyan = new Color<T>((T)(object)0, (T)(object)139, (T)(object)139, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #B8860B.
        /// </summary>
        public static readonly Color<T> DarkGoldenrod = new Color<T>((T)(object)184, (T)(object)134, (T)(object)11, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #A9A9A9.
        /// </summary>
        public static readonly Color<T> DarkGray = new Color<T>((T)(object)169, (T)(object)169, (T)(object)169, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #006400.
        /// </summary>
        public static readonly Color<T> DarkGreen = new Color<T>((T)(object)0, (T)(object)100, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #BDB76B.
        /// </summary>
        public static readonly Color<T> DarkKhaki = new Color<T>((T)(object)189, (T)(object)183, (T)(object)107, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #8B008B.
        /// </summary>
        public static readonly Color<T> DarkMagenta = new Color<T>((T)(object)139, (T)(object)0, (T)(object)139, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #556B2F.
        /// </summary>
        public static readonly Color<T> DarkOliveGreen = new Color<T>((T)(object)85, (T)(object)107, (T)(object)47, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF8C00.
        /// </summary>
        public static readonly Color<T> DarkOrange = new Color<T>((T)(object)1, (T)(object)140, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #9932CC.
        /// </summary>
        public static readonly Color<T> DarkOrchid = new Color<T>((T)(object)153, (T)(object)50, (T)(object)204, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #8B0000.
        /// </summary>
        public static readonly Color<T> DarkRed = new Color<T>((T)(object)139, (T)(object)0, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #E9967A.
        /// </summary>
        public static readonly Color<T> DarkSalmon = new Color<T>((T)(object)233, (T)(object)150, (T)(object)122, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #8FBC8B.
        /// </summary>
        public static readonly Color<T> DarkSeaGreen = new Color<T>((T)(object)143, (T)(object)188, (T)(object)139, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #483D8B.
        /// </summary>
        public static readonly Color<T> DarkSlateBlue = new Color<T>((T)(object)72, (T)(object)61, (T)(object)139, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #2F4F4F.
        /// </summary>
        public static readonly Color<T> DarkSlateGray = new Color<T>((T)(object)47, (T)(object)79, (T)(object)79, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #00CED1.
        /// </summary>
        public static readonly Color<T> DarkTurquoise = new Color<T>((T)(object)0, (T)(object)206, (T)(object)209, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #9400D3.
        /// </summary>
        public static readonly Color<T> DarkViolet = new Color<T>((T)(object)148, (T)(object)0, (T)(object)211, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF1493.
        /// </summary>
        public static readonly Color<T> DeepPink = new Color<T>((T)(object)1, (T)(object)20, (T)(object)147, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #00BFFF.
        /// </summary>
        public static readonly Color<T> DeepSkyBlue = new Color<T>((T)(object)0, (T)(object)191, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #696969.
        /// </summary>
        public static readonly Color<T> DimGray = new Color<T>((T)(object)105, (T)(object)105, (T)(object)105, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #1E90FF.
        /// </summary>
        public static readonly Color<T> DodgerBlue = new Color<T>((T)(object)30, (T)(object)144, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #B22222.
        /// </summary>
        public static readonly Color<T> Firebrick = new Color<T>((T)(object)178, (T)(object)34, (T)(object)34, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFFAF0.
        /// </summary>
        public static readonly Color<T> FloralWhite = new Color<T>((T)(object)1, (T)(object)250, (T)(object)240, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #228B22.
        /// </summary>
        public static readonly Color<T> ForestGreen = new Color<T>((T)(object)34, (T)(object)139, (T)(object)34, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF00FF.
        /// </summary>
        public static readonly Color<T> Fuchsia = new Color<T>((T)(object)1, (T)(object)0, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #DCDCDC.
        /// </summary>
        public static readonly Color<T> Gainsboro = new Color<T>((T)(object)220, (T)(object)220, (T)(object)220, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F8F8FF.
        /// </summary>
        public static readonly Color<T> GhostWhite = new Color<T>((T)(object)248, (T)(object)248, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFD700.
        /// </summary>
        public static readonly Color<T> Gold = new Color<T>((T)(object)1, (T)(object)215, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #DAA520.
        /// </summary>
        public static readonly Color<T> Goldenrod = new Color<T>((T)(object)218, (T)(object)165, (T)(object)32, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #808080.
        /// </summary>
        public static readonly Color<T> Gray = new Color<T>((T)(object)128, (T)(object)128, (T)(object)128, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #008000.
        /// </summary>
        public static readonly Color<T> Green = new Color<T>((T)(object)0, (T)(object)128, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #ADFF2F.
        /// </summary>
        public static readonly Color<T> GreenYellow = new Color<T>((T)(object)173, (T)(object)1, (T)(object)47, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F0FFF0.
        /// </summary>
        public static readonly Color<T> Honeydew = new Color<T>((T)(object)240, (T)(object)1, (T)(object)240, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF69B4.
        /// </summary>
        public static readonly Color<T> HotPink = new Color<T>((T)(object)1, (T)(object)105, (T)(object)180, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #CD5C5C.
        /// </summary>
        public static readonly Color<T> IndianRed = new Color<T>((T)(object)205, (T)(object)92, (T)(object)92, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #4B0082.
        /// </summary>
        public static readonly Color<T> Indigo = new Color<T>((T)(object)75, (T)(object)0, (T)(object)130, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFFFF0.
        /// </summary>
        public static readonly Color<T> Ivory = new Color<T>((T)(object)1, (T)(object)1, (T)(object)240, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F0E68C.
        /// </summary>
        public static readonly Color<T> Khaki = new Color<T>((T)(object)240, (T)(object)230, (T)(object)140, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #E6E6FA.
        /// </summary>
        public static readonly Color<T> Lavender = new Color<T>((T)(object)230, (T)(object)230, (T)(object)250, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFF0F5.
        /// </summary>
        public static readonly Color<T> LavenderBlush = new Color<T>((T)(object)1, (T)(object)240, (T)(object)245, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #7CFC00.
        /// </summary>
        public static readonly Color<T> LawnGreen = new Color<T>((T)(object)124, (T)(object)252, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFFACD.
        /// </summary>
        public static readonly Color<T> LemonChiffon = new Color<T>((T)(object)1, (T)(object)250, (T)(object)205, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #ADD8E6.
        /// </summary>
        public static readonly Color<T> LightBlue = new Color<T>((T)(object)173, (T)(object)216, (T)(object)230, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F08080.
        /// </summary>
        public static readonly Color<T> LightCoral = new Color<T>((T)(object)240, (T)(object)128, (T)(object)128, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #E0FFFF.
        /// </summary>
        public static readonly Color<T> LightCyan = new Color<T>((T)(object)224, (T)(object)1, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FAFAD2.
        /// </summary>
        public static readonly Color<T> LightGoldenrodYellow = new Color<T>((T)(object)250, (T)(object)250, (T)(object)210, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #D3D3D3.
        /// </summary>
        public static readonly Color<T> LightGray = new Color<T>((T)(object)211, (T)(object)211, (T)(object)211, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #90EE90.
        /// </summary>
        public static readonly Color<T> LightGreen = new Color<T>((T)(object)144, (T)(object)238, (T)(object)144, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFB6C1.
        /// </summary>
        public static readonly Color<T> LightPink = new Color<T>((T)(object)1, (T)(object)182, (T)(object)193, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFA07A.
        /// </summary>
        public static readonly Color<T> LightSalmon = new Color<T>((T)(object)1, (T)(object)160, (T)(object)122, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #20B2AA.
        /// </summary>
        public static readonly Color<T> LightSeaGreen = new Color<T>((T)(object)32, (T)(object)178, (T)(object)170, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #87CEFA.
        /// </summary>
        public static readonly Color<T> LightSkyBlue = new Color<T>((T)(object)135, (T)(object)206, (T)(object)250, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #778899.
        /// </summary>
        public static readonly Color<T> LightSlateGray = new Color<T>((T)(object)119, (T)(object)136, (T)(object)153, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #B0C4DE.
        /// </summary>
        public static readonly Color<T> LightSteelBlue = new Color<T>((T)(object)176, (T)(object)196, (T)(object)222, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFFFE0.
        /// </summary>
        public static readonly Color<T> LightYellow = new Color<T>((T)(object)1, (T)(object)1, (T)(object)224, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #00FF00.
        /// </summary>
        public static readonly Color<T> Lime = new Color<T>((T)(object)0, (T)(object)1, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #32CD32.
        /// </summary>
        public static readonly Color<T> LimeGreen = new Color<T>((T)(object)50, (T)(object)205, (T)(object)50, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FAF0E6.
        /// </summary>
        public static readonly Color<T> Linen = new Color<T>((T)(object)250, (T)(object)240, (T)(object)230, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF00FF.
        /// </summary>
        public static readonly Color<T> Magenta = new Color<T>((T)(object)1, (T)(object)0, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #800000.
        /// </summary>
        public static readonly Color<T> Maroon = new Color<T>((T)(object)128, (T)(object)0, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #66CDAA.
        /// </summary>
        public static readonly Color<T> MediumAquamarine = new Color<T>((T)(object)102, (T)(object)205, (T)(object)170, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #0000CD.
        /// </summary>
        public static readonly Color<T> MediumBlue = new Color<T>((T)(object)0, (T)(object)0, (T)(object)205, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #BA55D3.
        /// </summary>
        public static readonly Color<T> MediumOrchid = new Color<T>((T)(object)186, (T)(object)85, (T)(object)211, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #9370DB.
        /// </summary>
        public static readonly Color<T> MediumPurple = new Color<T>((T)(object)147, (T)(object)112, (T)(object)219, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #3CB371.
        /// </summary>
        public static readonly Color<T> MediumSeaGreen = new Color<T>((T)(object)60, (T)(object)179, (T)(object)113, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #7B68EE.
        /// </summary>
        public static readonly Color<T> MediumSlateBlue = new Color<T>((T)(object)123, (T)(object)104, (T)(object)238, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #00FA9A.
        /// </summary>
        public static readonly Color<T> MediumSpringGreen = new Color<T>((T)(object)0, (T)(object)250, (T)(object)154, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #48D1CC.
        /// </summary>
        public static readonly Color<T> MediumTurquoise = new Color<T>((T)(object)72, (T)(object)209, (T)(object)204, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #C71585.
        /// </summary>
        public static readonly Color<T> MediumVioletRed = new Color<T>((T)(object)199, (T)(object)21, (T)(object)133, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #191970.
        /// </summary>
        public static readonly Color<T> MidnightBlue = new Color<T>((T)(object)25, (T)(object)25, (T)(object)112, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F5FFFA.
        /// </summary>
        public static readonly Color<T> MintCream = new Color<T>((T)(object)245, (T)(object)1, (T)(object)250, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFE4E1.
        /// </summary>
        public static readonly Color<T> MistyRose = new Color<T>((T)(object)1, (T)(object)228, (T)(object)225, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFE4B5.
        /// </summary>
        public static readonly Color<T> Moccasin = new Color<T>((T)(object)1, (T)(object)228, (T)(object)181, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFDEAD.
        /// </summary>
        public static readonly Color<T> NavajoWhite = new Color<T>((T)(object)1, (T)(object)222, (T)(object)173, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #000080.
        /// </summary>
        public static readonly Color<T> Navy = new Color<T>((T)(object)0, (T)(object)0, (T)(object)128, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FDF5E6.
        /// </summary>
        public static readonly Color<T> OldLace = new Color<T>((T)(object)253, (T)(object)245, (T)(object)230, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #808000.
        /// </summary>
        public static readonly Color<T> Olive = new Color<T>((T)(object)128, (T)(object)128, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #6B8E23.
        /// </summary>
        public static readonly Color<T> OliveDrab = new Color<T>((T)(object)107, (T)(object)142, (T)(object)35, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFA500.
        /// </summary>
        public static readonly Color<T> Orange = new Color<T>((T)(object)1, (T)(object)165, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF4500.
        /// </summary>
        public static readonly Color<T> OrangeRed = new Color<T>((T)(object)1, (T)(object)69, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #DA70D6.
        /// </summary>
        public static readonly Color<T> Orchid = new Color<T>((T)(object)218, (T)(object)112, (T)(object)214, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #EEE8AA.
        /// </summary>
        public static readonly Color<T> PaleGoldenrod = new Color<T>((T)(object)238, (T)(object)232, (T)(object)170, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #98FB98.
        /// </summary>
        public static readonly Color<T> PaleGreen = new Color<T>((T)(object)152, (T)(object)251, (T)(object)152, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #AFEEEE.
        /// </summary>
        public static readonly Color<T> PaleTurquoise = new Color<T>((T)(object)175, (T)(object)238, (T)(object)238, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #DB7093.
        /// </summary>
        public static readonly Color<T> PaleVioletRed = new Color<T>((T)(object)219, (T)(object)112, (T)(object)147, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFEFD5.
        /// </summary>
        public static readonly Color<T> PapayaWhip = new Color<T>((T)(object)1, (T)(object)239, (T)(object)213, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFDAB9.
        /// </summary>
        public static readonly Color<T> PeachPuff = new Color<T>((T)(object)1, (T)(object)218, (T)(object)185, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #CD853F.
        /// </summary>
        public static readonly Color<T> Peru = new Color<T>((T)(object)205, (T)(object)133, (T)(object)63, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFC0CB.
        /// </summary>
        public static readonly Color<T> Pink = new Color<T>((T)(object)1, (T)(object)192, (T)(object)203, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #DDA0DD.
        /// </summary>
        public static readonly Color<T> Plum = new Color<T>((T)(object)221, (T)(object)160, (T)(object)221, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #B0E0E6.
        /// </summary>
        public static readonly Color<T> PowderBlue = new Color<T>((T)(object)176, (T)(object)224, (T)(object)230, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #800080.
        /// </summary>
        public static readonly Color<T> Purple = new Color<T>((T)(object)128, (T)(object)0, (T)(object)128, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #0.
        /// </summary>
        public static readonly Color<T> RebeccaPurple = new Color<T>((T)(object)102, (T)(object)51, (T)(object)153, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF0000.
        /// </summary>
        public static readonly Color<T> Red = new Color<T>((T)(object)1, (T)(object)0, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #BC8F8F.
        /// </summary>
        public static readonly Color<T> RosyBrown = new Color<T>((T)(object)188, (T)(object)143, (T)(object)143, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #4169E1.
        /// </summary>
        public static readonly Color<T> RoyalBlue = new Color<T>((T)(object)65, (T)(object)105, (T)(object)225, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #8B4513.
        /// </summary>
        public static readonly Color<T> SaddleBrown = new Color<T>((T)(object)139, (T)(object)69, (T)(object)19, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FA8072.
        /// </summary>
        public static readonly Color<T> Salmon = new Color<T>((T)(object)250, (T)(object)128, (T)(object)114, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F4A460.
        /// </summary>
        public static readonly Color<T> SandyBrown = new Color<T>((T)(object)244, (T)(object)164, (T)(object)96, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #2E8B57.
        /// </summary>
        public static readonly Color<T> SeaGreen = new Color<T>((T)(object)46, (T)(object)139, (T)(object)87, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFF5EE.
        /// </summary>
        public static readonly Color<T> SeaShell = new Color<T>((T)(object)1, (T)(object)245, (T)(object)238, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #A0522D.
        /// </summary>
        public static readonly Color<T> Sienna = new Color<T>((T)(object)160, (T)(object)82, (T)(object)45, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #C0C0C0.
        /// </summary>
        public static readonly Color<T> Silver = new Color<T>((T)(object)192, (T)(object)192, (T)(object)192, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #87CEEB.
        /// </summary>
        public static readonly Color<T> SkyBlue = new Color<T>((T)(object)135, (T)(object)206, (T)(object)235, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #6A5ACD.
        /// </summary>
        public static readonly Color<T> SlateBlue = new Color<T>((T)(object)106, (T)(object)90, (T)(object)205, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #708090.
        /// </summary>
        public static readonly Color<T> SlateGray = new Color<T>((T)(object)112, (T)(object)128, (T)(object)144, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFFAFA.
        /// </summary>
        public static readonly Color<T> Snow = new Color<T>((T)(object)1, (T)(object)250, (T)(object)250, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #00FF7F.
        /// </summary>
        public static readonly Color<T> SpringGreen = new Color<T>((T)(object)0, (T)(object)1, (T)(object)127, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #4682B4.
        /// </summary>
        public static readonly Color<T> SteelBlue = new Color<T>((T)(object)70, (T)(object)130, (T)(object)180, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #D2B48C.
        /// </summary>
        public static readonly Color<T> Tan = new Color<T>((T)(object)210, (T)(object)180, (T)(object)140, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #008080.
        /// </summary>
        public static readonly Color<T> Teal = new Color<T>((T)(object)0, (T)(object)128, (T)(object)128, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #D8BFD8.
        /// </summary>
        public static readonly Color<T> Thistle = new Color<T>((T)(object)216, (T)(object)191, (T)(object)216, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FF6347.
        /// </summary>
        public static readonly Color<T> Tomato = new Color<T>((T)(object)1, (T)(object)99, (T)(object)71, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFFFFF.
        /// </summary>
        public static readonly Color<T> Transparent = new Color<T>((T)(object)1, (T)(object)1, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #40E0D0.
        /// </summary>
        public static readonly Color<T> Turquoise = new Color<T>((T)(object)64, (T)(object)224, (T)(object)208, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #EE82EE.
        /// </summary>
        public static readonly Color<T> Violet = new Color<T>((T)(object)238, (T)(object)130, (T)(object)238, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F5DEB3.
        /// </summary>
        public static readonly Color<T> Wheat = new Color<T>((T)(object)245, (T)(object)222, (T)(object)179, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFFFFF.
        /// </summary>
        public static readonly Color<T> White = new Color<T>((T)(object)1, (T)(object)1, (T)(object)1, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #F5F5F5.
        /// </summary>
        public static readonly Color<T> WhiteSmoke = new Color<T>((T)(object)245, (T)(object)245, (T)(object)245, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #FFFF00.
        /// </summary>
        public static readonly Color<T> Yellow = new Color<T>((T)(object)1, (T)(object)1, (T)(object)0, (T)(object)255);

        /// <summary>
        /// Represents a <see cref="Color{T}"/> matching the W3C definition that has an hex value of #9ACD32.
        /// </summary>
        public static readonly Color<T> YellowGreen = new Color<T>((T)(object)154, (T)(object)205, (T)(object)50, (T)(object)255);
    }
}
