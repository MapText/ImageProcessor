// <copyright file="Color{T}Transforms.cs" company="James Jackson-South">
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
        /// Allows the implicit conversion of an instance of <see cref="Cmyk"/> to a
        /// <see cref="Color{T}"/>.
        /// </summary>
        /// <param name="cmykColor">The instance of <see cref="Cmyk"/> to convert.</param>
        /// <returns>
        /// An instance of <see cref="Color{T}"/>.
        /// </returns>
        public static implicit operator Color<T>(Cmyk cmykColor)
        {
            T r = (T)(object)((255 - cmykColor.C) * (255 - cmykColor.K));
            T g = (T)(object)((255 - cmykColor.M) * (255 - cmykColor.K));
            T b = (T)(object)((255 - cmykColor.Y) * (255 - cmykColor.K));
            return new Color<T>(r, g, b);
        }

        /// <summary>
        /// Allows the implicit conversion of an instance of <see cref="YCbCr"/> to a
        /// <see cref="Color{T}"/>.
        /// </summary>
        /// <param name="color">The instance of <see cref="YCbCr"/> to convert.</param>
        /// <returns>
        /// An instance of <see cref="Color{T}"/>.
        /// </returns>
        public static implicit operator Color<T>(YCbCr color)
        {
            float y = color.Y;
            float cb = color.Cb - 128;
            float cr = color.Cr - 128;

            T r = (T)(object)(y + (1.402 * cr));
            T g = (T)(object)(y - (0.34414 * cb) - (0.71414 * cr));
            T b = (T)(object)(y + (1.772 * cb));

            return new Color<T>(r, g, b);
        }

        /// <summary>
        /// Allows the implicit conversion of an instance of <see cref="Hsv"/> to a
        /// <see cref="Color{T}"/>.
        /// </summary>
        /// <param name="color">The instance of <see cref="Hsv"/> to convert.</param>
        /// <returns>
        /// An instance of <see cref="Color{T}"/>.
        /// </returns>
        public static implicit operator Color<T>(Hsv color)
        {
            float s = color.S;
            float v = color.V;

            if (Math.Abs(s) < Epsilon)
            {
                T tv = (T)(object)(v * 255f);
                return new Color<T>(tv, tv, tv);
            }

            float h = (Math.Abs(color.H - 360) < Epsilon) ? 0 : color.H / 60;
            int i = (int)Math.Truncate(h);
            float f = h - i;

            float p = v * (1.0f - s);
            float q = v * (1.0f - (s * f));
            float t = v * (1.0f - (s * (1.0f - f)));

            float r, g, b;
            switch (i)
            {
                case 0:
                    r = v;
                    g = t;
                    b = p;
                    break;

                case 1:
                    r = q;
                    g = v;
                    b = p;
                    break;

                case 2:
                    r = p;
                    g = v;
                    b = t;
                    break;

                case 3:
                    r = p;
                    g = q;
                    b = v;
                    break;

                case 4:
                    r = t;
                    g = p;
                    b = v;
                    break;

                default:
                    r = v;
                    g = p;
                    b = q;
                    break;
            }

            T tr = (T)(object)(r * 255f);
            T tg = (T)(object)(g * 255f);
            T tb = (T)(object)(b * 255f);
            return new Color<T>(tr, tg, tb);
        }

        /// <summary>
        /// Allows the implicit conversion of an instance of <see cref="Hsl"/> to a
        /// <see cref="Color"/>.
        /// </summary>
        /// <param name="color">The instance of <see cref="Hsl"/> to convert.</param>
        /// <returns>
        /// An instance of <see cref="Color"/>.
        /// </returns>
        public static implicit operator Color<T>(Hsl color)
        {
            float rangedH = color.H / 360f;
            float r = 0;
            float g = 0;
            float b = 0;
            float s = color.S;
            float l = color.L;

            if (Math.Abs(l) > Epsilon)
            {
                if (Math.Abs(s) < Epsilon)
                {
                    r = g = b = l;
                }
                else
                {
                    float temp2 = (l < 0.5f) ? l * (1f + s) : l + s - (l * s);
                    float temp1 = (2f * l) - temp2;

                    r = GetColorComponent(temp1, temp2, rangedH + (1 / 3f));
                    g = GetColorComponent(temp1, temp2, rangedH);
                    b = GetColorComponent(temp1, temp2, rangedH - (1 / 3f));
                }
            }

            T tr = (T)(object)(r * 255f);
            T tg = (T)(object)(g * 255f);
            T tb = (T)(object)(b * 255f);
            return new Color<T>(tr, tg, tb);
        }

        /// <summary>
        /// Gets the color component from the given values.
        /// </summary>
        /// <param name="first">The first value.</param>
        /// <param name="second">The second value.</param>
        /// <param name="third">The third value.</param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        private static float GetColorComponent(float first, float second, float third)
        {
            third = MoveIntoRange(third);
            if (third < 1.0 / 6.0)
            {
                return first + ((second - first) * 6.0f * third);
            }

            if (third < 0.5)
            {
                return second;
            }

            if (third < 2.0 / 3.0)
            {
                return first + ((second - first) * ((2.0f / 3.0f) - third) * 6.0f);
            }

            return first;
        }

        /// <summary>
        /// Moves the specific value within the acceptable range for 
        /// conversion.
        /// <remarks>Used for converting <see cref="Hsl"/> colors to this type.</remarks>
        /// </summary>
        /// <param name="value">The value to shift.</param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        private static float MoveIntoRange(float value)
        {
            if (value < 0.0)
            {
                value += 1.0f;
            }
            else if (value > 1.0)
            {
                value -= 1.0f;
            }

            return value;
        }
    }
}
