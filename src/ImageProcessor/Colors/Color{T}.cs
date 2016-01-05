// <copyright file="Color.cs" company="James Jackson-South">
// Copyright (c) James Jackson-South and contributors.
// Licensed under the Apache License, Version 2.0.
// </copyright>

namespace ImageProcessor.Colors
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    public struct Color<T> : IColor<T>, IEquatable<Color<T>>
        where T : struct, IComparable<T>
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
        /// Initializes a new instance of the <see cref="Color{T}"/> struct.
        /// </summary>
        /// <param name="r">The red component of this <see cref="Color{T}"/>.</param>
        /// <param name="g">The green component of this <see cref="Color{T}"/>.</param>
        /// <param name="b">The blue component of this <see cref="Color{T}"/>.</param>
        /// <param name="a">The alpha component of this <see cref="Color{T}"/>.</param>
        public Color(T r, T g, T b, T a)
            : this()
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="hex">
        /// The hexadecimal representation of the combined color components arranged
        /// in rgb, rrggbb, or aarrggbb format to match web syntax.
        /// </param>
        public Color(string hex)
            : this()
        {
            // Hexadecimal representations are layed out AARRGGBB to we need to do some reordering.
            hex = hex.StartsWith("#") ? hex.Substring(1) : hex;

            if (hex.Length != 8 && hex.Length != 6 && hex.Length != 3)
            {
                throw new ArgumentException("Hexadecimal string is not in the correct format.", nameof(hex));
            }

            if (hex.Length == 8)
            {
                this.R = (T)(object)Convert.ToByte(hex.Substring(2, 2), 16);
                this.G = (T)(object)Convert.ToByte(hex.Substring(4, 2), 16);
                this.B = (T)(object)Convert.ToByte(hex.Substring(6, 2), 16);
                this.A = (T)(object)Convert.ToByte(hex.Substring(0, 2), 16);
            }
            else if (hex.Length == 6)
            {
                this.R = (T)(object)Convert.ToByte(hex.Substring(0, 2), 16);
                this.G = (T)(object)Convert.ToByte(hex.Substring(2, 2), 16);
                this.B = (T)(object)Convert.ToByte(hex.Substring(4, 2), 16);
                this.A = (T)(object)255;
            }
            else
            {
                string rh = char.ToString(hex[0]);
                string gh = char.ToString(hex[1]);
                string bh = char.ToString(hex[2]);

                this.B = (T)(object)Convert.ToByte(bh + bh, 16);
                this.G = (T)(object)Convert.ToByte(gh + gh, 16);
                this.R = (T)(object)Convert.ToByte(rh + rh, 16);
                this.A = (T)(object)255;
            }
        }

        /// <inheritdoc/>
        public T R { get; set; }

        /// <summary>
        /// Gets or sets the green component of the color.
        /// </summary>
        public T G { get; set; }

        /// <inheritdoc/>
        public T B { get; set; }

        /// <inheritdoc/>
        public T A { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="Color"/> is empty.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsEmpty => this.Equals(Empty);

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
            // TODO: SIMD?
            T r = ScalarAdd(left.R, right.R);
            T g = ScalarAdd(left.G, right.G);
            T b = ScalarAdd(left.B, right.B);
            T a = ScalarAdd(left.A, right.A);

            return new Color<T>(r, g, b, a);
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
            // TODO: SIMD?
            T r = ScalarSubtract(left.R, right.R);
            T g = ScalarSubtract(left.G, right.G);
            T b = ScalarSubtract(left.B, right.B);
            T a = ScalarSubtract(left.A, right.A);

            return new Color<T>(r, g, b, a);
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
            return new Color<T>(factor, factor, factor, factor) * color;
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
            return new Color<T>(factor, factor, factor, factor) * color;
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
            // TODO: SIMD?
            T r = ScalarMultiply(left.R, right.R);
            T g = ScalarMultiply(left.G, right.G);
            T b = ScalarMultiply(left.B, right.B);
            T a = ScalarMultiply(left.A, right.A);

            return new Color<T>(r, g, b, a);
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
        /// Returns a new color whose components are the average of the components of first and second.
        /// </summary>
        /// <param name="first">The first color.</param>
        /// <param name="second">The second color.</param>
        /// <returns>
        /// The <see cref="Color{T}"/>
        /// </returns>
        public static Color<T> Average(Color<T> first, Color<T> second)
        {
            // TODO: SIMD?
            T r = ScalarAverage(first.R, second.R);
            T g = ScalarAverage(first.G, second.G);
            T b = ScalarAverage(first.B, second.B);
            T a = ScalarAverage(first.A, second.A);

            return new Color<T>(r, g, b, a);
        }

        /// <summary>
        /// Converts a non-premultipled alpha <see cref="Color"/> to a <see cref="Color"/>
        /// that contains premultiplied alpha.
        /// </summary>
        /// <param name="color">The <see cref="Color"/> to convert.</param>
        /// <returns>The <see cref="Color"/>.</returns>
        public static Color<T> FromNonPremultiplied(Color<T> color)
        {
            // TODO: SIMD?
            T r = ScalarMultiply(color.R, color.A);
            T g = ScalarMultiply(color.G, color.A);
            T b = ScalarMultiply(color.B, color.A);

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
            if (typeof(T) == typeof(byte))
            {
                if ((byte)(object)color.A == 0)
                {
                    return new Color<T>(color.R, color.G, color.B, color.A);
                }
            }

            if (typeof(T) == typeof(float))
            {
                if (Math.Abs((float)(object)color.A) < Epsilon)
                {
                    return new Color<T>(color.R, color.G, color.B, color.A);
                }
            }

            // TODO: SIMD?
            T r = ScalarDivide(color.R, color.A);
            T g = ScalarDivide(color.G, color.A);
            T b = ScalarDivide(color.B, color.A);

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

            if (typeof(T) == typeof(byte))
            {
                return $"Color [ R={(byte)(object)this.R}, G={(byte)(object)this.G}, B={(byte)(object)this.B}, A={(byte)(object)this.A} ]";
            }

            if (typeof(T) == typeof(float))
            {
                return $"Color [ R={(float)(object)this.R:#0.##}, G={(float)(object)this.G:#0.##}, B={(float)(object)this.B:#0.##}, A={(float)(object)this.A:#0.##} ]";
            }

            throw new NotSupportedException("Specified type is not supported");
        }

        /// <inheritdoc/>
        public bool Equals(Color<T> other)
        {
            // TODO: SIMD?
            return ScalarEquals(this.R, other.R)
                && ScalarEquals(this.G, other.G)
                && ScalarEquals(this.B, other.B)
                && ScalarEquals(this.A, other.A);
        }

        /// <summary>
        /// Computes the sum of adding two scalar values.
        /// </summary>
        /// <param name="left">The scalar on the left side of the operand.</param>
        /// <param name="right">The scalar on the right side of the operand.</param>
        /// <returns>The <see cref="T"/>.</returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the given type parameter is not supported.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T ScalarAdd(T left, T right)
        {
            unchecked
            {
                if (typeof(T) == typeof(byte))
                {
                    return (T)(object)(byte)((byte)(object)left + (byte)(object)right);
                }

                if (typeof(T) == typeof(float))
                {
                    return (T)(object)((float)(object)left + (float)(object)right);
                }

                throw new NotSupportedException("Specified type is not supported");
            }
        }

        /// <summary>
        /// Computes the difference left by subtracting one scalar value from another.
        /// </summary>
        /// <param name="left">The scalar on the left side of the operand.</param>
        /// <param name="right">The scalar on the right side of the operand.</param>
        /// <returns>The <see cref="T"/>.</returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the given type parameter is not supported.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T ScalarSubtract(T left, T right)
        {
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)(byte)((byte)(object)left - (byte)(object)right);
            }

            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left - (float)(object)right);
            }

            throw new NotSupportedException("Specified type is not supported");
        }

        /// <summary>
        /// Computes the average of two scalar values.
        /// </summary>
        /// <param name="left">The scalar on the left side of the operand.</param>
        /// <param name="right">The scalar on the right side of the operand.</param>
        /// <returns>The <see cref="T"/>.</returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the given type parameter is not supported.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T ScalarAverage(T left, T right)
        {
            unchecked
            {
                if (typeof(T) == typeof(byte))
                {
                    return (T)(object)(byte)((byte)(object)left * (byte)(object)right * .5f);
                }

                if (typeof(T) == typeof(float))
                {
                    return (T)(object)((float)(object)left * (float)(object)right * .5f);
                }

                throw new NotSupportedException("Specified type is not supported");
            }
        }

        /// <summary>
        /// Computes the product of multiplying two scalar values.
        /// </summary>
        /// <param name="left">The scalar on the left side of the operand.</param>
        /// <param name="right">The scalar on the right side of the operand.</param>
        /// <returns>The <see cref="T"/>.</returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the given type parameter is not supported.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T ScalarMultiply(T left, T right)
        {
            unchecked
            {
                if (typeof(T) == typeof(byte))
                {
                    return (T)(object)(byte)((byte)(object)left * (byte)(object)right);
                }

                if (typeof(T) == typeof(float))
                {
                    return (T)(object)((float)(object)left * (float)(object)right);
                }

                throw new NotSupportedException("Specified type is not supported");
            }
        }

        /// <summary>
        /// Computes the dividend of dividing one scalar value by another.
        /// </summary>
        /// <param name="left">The scalar on the left side of the operand.</param>
        /// <param name="right">The scalar on the right side of the operand.</param>
        /// <returns>The <see cref="T"/>.</returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the given type parameter is not supported.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static T ScalarDivide(T left, T right)
        {
            // TODO: Divide by zero
            if (typeof(T) == typeof(byte))
            {
                return (T)(object)(byte)((byte)(object)left / (byte)(object)right);
            }

            if (typeof(T) == typeof(float))
            {
                return (T)(object)((float)(object)left / (float)(object)right);
            }

            throw new NotSupportedException("Specified type is not supported");
        }

        /// <summary>
        /// Compares two scalar values for equality.
        /// </summary>
        /// <param name="left">The scalar on the left side of the operand.</param>
        /// <param name="right">The scalar on the right side of the operand.</param>
        /// <returns>True if the two values are equal; otherwise, false.</returns>
        /// <exception cref="NotSupportedException">
        /// Thrown if the given type parameter is not supported.
        /// </exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static bool ScalarEquals(T left, T right)
        {
            if (typeof(T) == typeof(byte))
            {
                return (byte)(object)left == (byte)(object)right;
            }

            if (typeof(T) == typeof(float))
            {
                return Math.Abs((float)(object)left - (float)(object)right) < Epsilon;
            }

            throw new NotSupportedException("Specified type is not supported");
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
            unchecked
            {
                Type type = typeof(T);
                if (type != typeof(byte) && type != typeof(float))
                {
                    throw new NotSupportedException("Specified type is not supported");
                }

                int hashCode = color.R.GetHashCode();
                hashCode = (hashCode * 397) ^ color.G.GetHashCode();
                hashCode = (hashCode * 397) ^ color.B.GetHashCode();
                hashCode = (hashCode * 397) ^ color.A.GetHashCode();
                return hashCode;
            }
        }
    }
}
