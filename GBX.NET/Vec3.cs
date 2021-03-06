﻿using System.Runtime.Serialization;

namespace GBX.NET
{
    public struct Vec3
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        [IgnoreDataMember]
        public Vec3 XZ => new Vec3(X, 0, Z);

        public Vec3(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public override string ToString() => $"({X}, {Y}, {Z})";
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode();
        public override bool Equals(object obj) => obj is Vec3 a && a == this;

        public static bool operator ==(Vec3 a, Vec3 b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z;
        public static bool operator !=(Vec3 a, Vec3 b) => !(a.X == b.X && a.Y == b.Y && a.Z == b.Z);

        public static Vec3 operator +(Vec3 a, Vec3 b) => new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vec3 operator +(Vec3 a, Int3 b) => new Vec3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        public static Vec3 operator +(Vec3 a, Vec2 b) => new Vec3(a.X + b.X, a.Y + b.Y, a.Z);
        public static Vec3 operator +(Vec3 a, Int2 b) => new Vec3(a.X + b.X, a.Y + b.Y, a.Z);
        public static Vec3 operator +(Vec3 a, int b) => new Vec3(a.X + b, a.Y + b, a.Z + b);
        public static Vec3 operator +(Vec3 a, float b) => new Vec3(a.X + b, a.Y + b, a.Z + b);

        public static Vec3 operator -(Vec3 a) => new Vec3(-a.X, -a.Y, -a.Z);
        public static Vec3 operator -(Vec3 a, Vec3 b) => new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vec3 operator -(Vec3 a, Int3 b) => new Vec3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        public static Vec3 operator -(Vec3 a, Vec2 b) => new Vec3(a.X - b.X, a.Y - b.Y, a.Z);
        public static Vec3 operator -(Vec3 a, Int2 b) => new Vec3(a.X - b.X, a.Y - b.Y, a.Z);
        public static Vec3 operator -(Vec3 a, int b) => new Vec3(a.X - b, a.Y - b, a.Z - b);
        public static Vec3 operator -(Vec3 a, float b) => new Vec3(a.X - b, a.Y - b, a.Z - b);

        public static Vec3 operator *(Vec3 a, Vec3 b) => new Vec3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vec3 operator *(Vec3 a, Int3 b) => new Vec3(a.X * b.X, a.Y * b.Y, a.Z * b.Z);
        public static Vec3 operator *(Vec3 a, Vec2 b) => new Vec3(a.X * b.X, a.Y * b.Y, a.Z);
        public static Vec3 operator *(Vec3 a, Int2 b) => new Vec3(a.X * b.X, a.Y * b.Y, a.Z);
        public static Vec3 operator *(Vec3 a, int b) => new Vec3(a.X * b, a.Y * b, a.Z * b);
        public static Vec3 operator *(Vec3 a, float b) => new Vec3(a.X * b, a.Y * b, a.Z * b);

        public static implicit operator Vec3(Int3 a) => new Vec3(a.X, a.Y, a.Z);
        public static implicit operator Vec3((float X, float Y, float Z) v) => new Vec3(v.X, v.Y, v.Z);
        public static implicit operator (float X, float Y, float Z)(Vec3 v) => (v.X, v.Y, v.Z);

        public static explicit operator Vec3(Byte3 a) => new Vec3(a.X, a.Y, a.Z);
        public static explicit operator Vec3(Int2 a) => new Vec3(a.X, 0, a.Y);
    }
}
