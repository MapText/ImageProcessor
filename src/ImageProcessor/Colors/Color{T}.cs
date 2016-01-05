// <copyright file="Color{T}.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    /// <summary>
    /// Represents a four-component color using red, green, blue, and alpha data. 
    /// Each component is stored in premultiplied format multiplied by the alpha component.
    /// </summary>
    public partial struct Color<T> : IColor<T>, IEquatable<Color<T>>
        where T : struct, IComparable<T>, IFormattable
    {
        /// <summary>
        /// Represents an empty <see cref="Color"/> that has R, G, B, and A values set to zero.
        /// </summary>
        public static readonly Color<T> Empty = default(Color<T>);

        /// <summary>
        /// The epsilon for comparing floating point numbers.
        /// </summary>
        private const float Epsilon = 0.0001f;

        /// <summary>
        /// The backing vector for SIMD support.
        /// </summary>
        private Vector<T> backingVector;

        /// <summary>
        /// Initializes a new instance of the <see cref="Color{T}"/> struct with the alpha component set to 255.
        /// </summary>
        /// <param name="r">The red component of this <see cref="Color{T}"/>.</param>
        /// <param name="g">The green component of this <see cref="Color{T}"/>.</param>
        /// <param name="b">The blue component of this <see cref="Color{T}"/>.</param>
        public Color(T r, T g, T b)
            : this(r, g, b, (T)(object)255)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color{T}"/> struct.
        /// </summary>
        /// <param name="r">The red component of this <see cref="Color{T}"/>.</param>
        /// <param name="g">The green component of this <see cref="Color{T}"/>.</param>
        /// <param name="b">The blue component of this <see cref="Color{T}"/>.</param>
        /// <param name="a">The alpha component of this <see cref="Color{T}"/>.</param>
        public Color(T r, T g, T b, T a)
            : this()
        {
            this.backingVector = new Vector<T>(new[] { r, g, b, a });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color{T}"/> struct.
        /// </summary>
        /// <param name="vector">The vector.</param>
        public Color(Vector<T> vector)
            : this()
        {
            this.backingVector = vector;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color{T}"/> struct.
        /// </summary>
        /// <param name="hex">
        /// The hexadecimal representation of the combined color components arranged
        /// in rgb, rrggbb, or aarrggbb format to match web syntax.
        /// </param>
        public Color(string hex)
            : this()
        {
            T r;
            T g;
            T b;
            T a;

            // Hexadecimal representations are layed out AARRGGBB to we need to do some reordering.
            hex = hex.StartsWith("#") ? hex.Substring(1) : hex;

            if (hex.Length != 8 && hex.Length != 6 && hex.Length != 3)
            {
                throw new ArgumentException("Hexadecimal string is not in the correct format.", nameof(hex));
            }

            if (hex.Length == 8)
            {
                r = (T)(object)Convert.ToByte(hex.Substring(2, 2), 16);
                g = (T)(object)Convert.ToByte(hex.Substring(4, 2), 16);
                b = (T)(object)Convert.ToByte(hex.Substring(6, 2), 16);
                a = (T)(object)Convert.ToByte(hex.Substring(0, 2), 16);
            }
            else if (hex.Length == 6)
            {
                r = (T)(object)Convert.ToByte(hex.Substring(0, 2), 16);
                g = (T)(object)Convert.ToByte(hex.Substring(2, 2), 16);
                b = (T)(object)Convert.ToByte(hex.Substring(4, 2), 16);
                a = (T)(object)255;
            }
            else
            {
                string rh = char.ToString(hex[0]);
                string gh = char.ToString(hex[1]);
                string bh = char.ToString(hex[2]);

                r = (T)(object)Convert.ToByte(rh + rh, 16);
                g = (T)(object)Convert.ToByte(gh + gh, 16);
                b = (T)(object)Convert.ToByte(bh + bh, 16);
                a = (T)(object)255;
            }

            this.backingVector = new Vector<T>(new[] { r, g, b, a });
        }

        /// <inheritdoc/>
        public T R => this.backingVector[0];

        /// <inheritdoc/>
        public T G => this.backingVector[1];

        /// <inheritdoc/>
        public T B => this.backingVector[2];

        /// <inheritdoc/>
        public T A => this.backingVector[3];

        /// <summary>
        /// Gets a value indicating whether this <see cref="Color"/> is empty.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEmpty => this.backingVector.Equals(default(Vector<T>));

        /// <summary>
        /// Gets this color with the component values clamped from 0 to 255.
        /// </summary>
        public Color<T> Limited
        {
            get
            {
                T min = (T)(object)0;
                T max = (T)(object)255;
                T r = this.R.Clamp(min, max);
                T g = this.G.Clamp(min, max);
                T b = this.B.Clamp(min, max);
                T a = this.A.Clamp(min, max);

                return new Color<T>(r, g, b, a);
            }
        }

        /// <summary>
        /// Computes the sum of adding two colors.
        /// </summary>
        /// <param name="left">The color on the left hand of the operand.</param>
        /// <param name="right">The color on the right hand of the operand.</param>
        /// <returns>
        /// The <see cref="Color{T}"/>
        /// </returns>
        public static Color<T> operator +(Color<T> left, Color<T> right)
        {
            return new Color<T>(left.backingVector + right.backingVector);
        }

        /// <summary>
        /// Computes the difference left by subtracting one color from another.
        /// </summary>
        /// <param name="left">The color on the left hand of the operand.</param>
        /// <param name="right">The color on the right hand of the operand.</param>
        /// <returns>
        /// The <see cref="Color{T}"/>
        /// </returns>
        public static Color<T> operator -(Color<T> left, Color<T> right)
        {
            return new Color<T>(left.backingVector - right.backingVector);
        }

        /// <summary>
        /// Computes the product of multiplying a color by a given factor.
        /// </summary>
        /// <param name="color">The color.</param>
        /// <param name="factor">The multiplication factor.</param>
        /// <returns>
        /// The <see cref="Color"/>
        /// </returns>
        public static Color<T> operator *(Color<T> color, T factor)
        {
            return new Color<T>(color.backingVector * factor);
        }

        /// <summary>
        /// Computes the product of multiplying a factor by a given color.
        /// </summary>
        /// <param name="factor">The factor.</param>
        /// <param name="color">The multiplication color.</param>
        /// <returns>
        /// The <see cref="Color"/>
        /// </returns>
        public static Color<T> operator *(T factor, Color<T> color)
        {
            return new Color<T>(color.backingVector * factor);
        }

        /// <summary>
        /// Computes the product of multiplying two colors.
        /// </summary>
        /// <param name="left">The color on the left hand of the operand.</param>
        /// <param name="right">The color on the right hand of the operand.</param>
        /// <returns>
        /// The <see cref="Color{T}"/>
        /// </returns>
        public static Color<T> operator *(Color<T> left, Color<T> right)
        {
            return new Color<T>(left.backingVector * right.backingVector);
        }

        /// <summary>
        /// Compares two <see cref="Color"/> objects for equality.
        /// </summary>
        /// <param name="left">
        /// The <see cref="Color{T}"/> on the left side of the operand.
        /// </param>
        /// <param name="right">
        /// The <see cref="Color{T}"/> on the right side of the operand.
        /// </param>
        /// <returns>
        /// True if the current left is equal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        public static bool operator ==(Color<T> left, Color<T> right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Compares two <see cref="Color{T}"/> objects for inequality.
        /// </summary>
        /// <param name="left">The <see cref="Color{T}"/> on the left side of the operand.</param>
        /// <param name="right">The <see cref="Color{T}"/> on the right side of the operand.</param>
        /// <returns>
        /// True if the current left is unequal to the <paramref name="right"/> parameter; otherwise, false.
        /// </returns>
        public static bool operator !=(Color<T> left, Color<T> right)
        {
            return !left.Equals(right);
        }


        /// <summary>
        /// Casts the components of the given color to the specified type.
        /// </summary>
        /// <param name="color">The color to cast from.</param>
        /// <typeparam name="TType">The type to cast the components to.</typeparam>
        /// <returns>
        /// The <see cref="Color{T}"/>.
        /// </returns>
        public static Color<T> Cast<TType>(Color<TType> color)
            where TType : struct, IComparable<TType>, IFormattable
        {
            TType[] components = new TType[4];
            color.backingVector.CopyTo(components);
            Vector<T> vector = new Vector<T>(components.Cast<T>().ToArray());
            return new Color<T>(vector);
        }

        /// <summary>
        /// Returns a new color whose components are the average of the components of first and second.
        /// </summary>
        /// <param name="first">The first color.</param>
        /// <param name="second">The second color.</param>
        /// <returns>
        /// The <see cref="Color{T}"/>
        /// </returns>
        public static Color<T> Average(Color<T> first, Color<T> second)
        {
            return new Color<T>(first.backingVector * second.backingVector / new Vector<T>((T)(object)2));
        }

        /// <summary>
        /// Converts a non-premultipled alpha <see cref="Color"/> to a <see cref="Color"/>
        /// that contains premultiplied alpha.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to convert.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color<T> FromNonPremultiplied(Color<T> color)
        {
            Vector<T> multiplied = color.backingVector * new Vector<T>(color.A);

            T r = multiplied[0];
            T g = multiplied[1];
            T b = multiplied[2];

            return new Color<T>(r, g, b, color.A);
        }

        /// <summary>
        /// Converts a premultipled alpha <see cref="Color"/> to a <see cref="Color"/>
        /// that contains non-premultiplied alpha.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to convert.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color<T> ToNonPremultiplied(Color<T> color)
        {
            if (EqualityComparer<T>.Default.Equals(color.A, default(T)))
            {
                return new Color<T>(color.backingVector);
            }

            Vector<T> divided = color.backingVector / new Vector<T>(color.A);

            T r = divided[0];
            T g = divided[1];
            T b = divided[2];

            return new Color<T>(r, g, b, color.A);
        }

        /// <summary>
        /// Compresses a linear color signal to its sRGB equivalent.
        /// <see href="http://www.4p8.com/eric.brasseur/gamma.html#formulas"/>
        /// <see href="http://entropymine.com/imageworsener/srgbformula/"/>
        /// </summary>
        /// <param name="linear">The <see cref="IColor{T}"/> whose signal to compress.</param>
        /// <returns>The <see cref="Color{T}"/>.</returns>
        public static Color<T> Compress(Color<T> linear)
        {
            // TODO: SIMD?
            float r = Compress((float)(object)linear.R);
            float g = Compress((float)(object)linear.G);
            float b = Compress((float)(object)linear.B);

            return new Color<T>((T)(object)r, (T)(object)g, (T)(object)b, linear.A);
        }

        /// <summary>
        /// Expands an sRGB color signal to its linear equivalent.
        /// <see href="http://www.4p8.com/eric.brasseur/gamma.html#formulas"/>
        /// <see href="http://entropymine.com/imageworsener/srgbformula/"/>
        /// </summary>
        /// <param name="gamma">The <see cref="Color{T}"/> whose signal to expand.</param>
        /// <returns>The <see cref="Color{T}"/>.</returns>
        public static Color<T> Expand(Color<T> gamma)
        {
            // TODO: SIMD?
            float r = Expand((float)(object)gamma.R);
            float g = Expand((float)(object)gamma.G);
            float b = Expand((float)(object)gamma.B);

            return new Color<T>((T)(object)r, (T)(object)g, (T)(object)b, gamma.A);
        }

        /// <summary>
        /// Linearly interpolates from one color to another based on the given amount.
        /// </summary>
        /// <param name="from">The first color value.</param>
        /// <param name="to">The second color value.</param>
        /// <param name="amount">
        /// The weight value. At amount = 0, "from" is returned, at amount = 1, "to" is returned.
        /// </param>
        /// <returns>
        /// The <see cref="Color{T}"/>
        /// </returns>
        public static Color<T> Lerp(Color<T> from, Color<T> to, T amount)
        {
            // Premultiplied.
            return from + ((to - from) * amount);
        }

        /// <inheritdoc/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public override bool Equals(object obj)
        {
            if (obj is Color<T>)
            {
                Color<T> color = (Color<T>)obj;

                return this.Equals(color);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return GetHashCode(this);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            if (this.IsEmpty)
            {
                return "Color [ Empty ]";
            }

            return $"Color [ R={this.R:#0.##}, G={this.G:#0.##}, B={this.B:#0.##}, A={this.A:#0.##} ]";
        }

        /// <inheritdoc/>
        public bool Equals(Color<T> other)
        {
            return this.backingVector.Equals(other.backingVector);
        }

        /// <summary>
        /// Gets the compressed sRGB value from an linear signal.
        /// <see href="http://www.4p8.com/eric.brasseur/gamma.html#formulas"/>
        /// <see href="http://entropymine.com/imageworsener/srgbformula/"/>
        /// </summary>
        /// <param name="signal">The signal value to compress.</param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        private static float Compress(float signal)
        {
            if (signal <= 0.0031308f)
            {
                return signal * 12.92f;
            }

            return (1.055f * (float)Math.Pow(signal, 0.41666666f)) - 0.055f;
        }

        /// <summary>
        /// Gets the expanded linear value from an sRGB signal.
        /// <see href="http://www.4p8.com/eric.brasseur/gamma.html#formulas"/>
        /// <see href="http://entropymine.com/imageworsener/srgbformula/"/>
        /// </summary>
        /// <param name="signal">The signal value to expand.</param>
        /// <returns>
        /// The <see cref="float"/>.
        /// </returns>
        private static float Expand(float signal)
        {
            if (signal <= 0.04045f)
            {
                return signal / 12.92f;
            }

            return (float)Math.Pow((signal + 0.055f) / 1.055f, 2.4f);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <param name="color">
        /// The instance of <see cref="Color"/> to return the hash code for.
        /// </param>
        /// <returns>
        /// A 32-bit signed integer that is the hash code for this instance.
        /// </returns>
        private static int GetHashCode(Color<T> color)
        {
            return color.backingVector.GetHashCode();
        }
    }
}
