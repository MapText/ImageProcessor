
namespace ImageProcessor.Colors
{
    using System;
    using System.Numerics;

    public struct Color<T> : IColor<T>, IEquatable<Color<T>>
        where T : struct, IComparable<T>
    {
        public Color(T r, T g, T b, T a)
        {
            this.R = r;
            this.G = g;
            this.B = b;
            this.A = a;
        }

        /// <summary>
        /// Gets or sets the red component of the color.
        /// </summary>
        public T R { get; set; }

        /// <summary>
        /// Gets or sets the green component of the color.
        /// </summary>
        public T G { get; set; }

        /// <summary>
        /// Gets or sets the blue component of the color.
        /// </summary>
        public T B { get; set; }

        /// <summary>
        /// Gets or sets the alpha component of the color.
        /// </summary>
        public T A { get; set; }

        public IColor<T> Compress(IColor<T> color)
        {
            throw new NotImplementedException();
        }

        public IColor<T> Expand(IColor<T> color)
        {
            throw new NotImplementedException();
        }

        public IColor<T> Lerp(IColor<T> from, IColor<T> to, T amount)
        {
            //amount = amount.Clamp(0f, 1f);

            //return from + (to - from) * amount;

            //// Premultiplied.
            //return (from * (1 - amount)) + to;
        }

        /// <summary>
        /// Computes the sum of adding two colors.
        /// </summary>
        /// <param name="left">The color on the left hand of the operand.</param>
        /// <param name="right">The color on the right hand of the operand.</param>
        /// <returns>
        /// The <see cref="Color"/>
        /// </returns>
        public static Color<T> operator +(Color<T> left, Color<T> right)
        {
            if (typeof(T) == typeof(byte))
            {
                return (Color<T>)(object)new Color<byte>(
                 (byte)((byte)(object)left.R + (byte)(object)right.R),
                 (byte)((byte)(object)left.G + (byte)(object)right.G),
                 (byte)((byte)(object)left.B + (byte)(object)right.B),
                 (byte)((byte)(object)left.A + (byte)(object)right.A));
            }

            if (typeof(T) == typeof(sbyte))
            {
                return (Color<T>)(object)new Color<sbyte>(
                 (sbyte)((sbyte)(object)left.R + (sbyte)(object)right.R),
                 (sbyte)((sbyte)(object)left.G + (sbyte)(object)right.G),
                 (sbyte)((sbyte)(object)left.B + (sbyte)(object)right.B),
                 (sbyte)((sbyte)(object)left.A + (sbyte)(object)right.A));
            }

            if (typeof(T) == typeof(ushort))
            {
                return (Color<T>)(object)new Color<ushort>(
                 (ushort)((ushort)(object)left.R + (ushort)(object)right.R),
                 (ushort)((ushort)(object)left.G + (ushort)(object)right.G),
                 (ushort)((ushort)(object)left.B + (ushort)(object)right.B),
                 (ushort)((ushort)(object)left.A + (ushort)(object)right.A));
            }

            if (typeof(T) == typeof(short))
            {
                return (Color<T>)(object)new Color<short>(
                 (short)((short)(object)left.R + (short)(object)right.R),
                 (short)((short)(object)left.G + (short)(object)right.G),
                 (short)((short)(object)left.B + (short)(object)right.B),
                 (short)((short)(object)left.A + (short)(object)right.A));
            }

            if (typeof(T) == typeof(uint))
            {
                return (Color<T>)(object)new Color<uint>(
                  (uint)(object)left.R + (uint)(object)right.R,
                  (uint)(object)left.G + (uint)(object)right.G,
                  (uint)(object)left.B + (uint)(object)right.B,
                  (uint)(object)left.A + (uint)(object)right.A);
            }

            if (typeof(T) == typeof(int))
            {
                return (Color<T>)(object)new Color<int>(
                  (int)(object)left.R + (int)(object)right.R,
                  (int)(object)left.G + (int)(object)right.G,
                  (int)(object)left.B + (int)(object)right.B,
                  (int)(object)left.A + (int)(object)right.A);
            }

            if (typeof(T) == typeof(ulong))
            {
                return (Color<T>)(object)new Color<ulong>(
                 (ulong)(object)left.R + (ulong)(object)right.R,
                 (ulong)(object)left.G + (ulong)(object)right.G,
                 (ulong)(object)left.B + (ulong)(object)right.B,
                 (ulong)(object)left.A + (ulong)(object)right.A);
            }

            if (typeof(T) == typeof(long))
            {
                return (Color<T>)(object)new Color<long>(
                 (long)(object)left.R + (long)(object)right.R,
                 (long)(object)left.G + (long)(object)right.G,
                 (long)(object)left.B + (long)(object)right.B,
                 (long)(object)left.A + (long)(object)right.A);
            }

            if (typeof(T) == typeof(float))
            {
                return (Color<T>)(object)new Color<float>(
                 (float)(object)left.R + (float)(object)right.R,
                 (float)(object)left.G + (float)(object)right.G,
                 (float)(object)left.B + (float)(object)right.B,
                 (float)(object)left.A + (float)(object)right.A);
            }

            if (typeof(T) == typeof(double))
            {
                return (Color<T>)(object)new Color<double>(
                 (double)(object)left.R + (double)(object)right.R,
                 (double)(object)left.G + (double)(object)right.G,
                 (double)(object)left.B + (double)(object)right.B,
                 (double)(object)left.A + (double)(object)right.A);
            }

            throw new NotSupportedException("Specified type is not supported");
        }

        /// <summary>
        /// Computes the difference left by subtracting one color from another.
        /// </summary>
        /// <param name="left">The color on the left hand of the operand.</param>
        /// <param name="right">The color on the right hand of the operand.</param>
        /// <returns>
        /// The <see cref="Color"/>
        /// </returns>
        //public static Color operator -(Color left, Color right)
        //{
        //    return new Color(left.R - right.R, left.G - right.G, left.B - right.B, left.A - right.A);
        //}

        public bool Equals(Color<T> other)
        {
            throw new NotImplementedException();
        }
    }
}
