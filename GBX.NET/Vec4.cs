﻿namespace GBX.NET
{
    public struct Vec4
    {
        public float X { get; }
        public float Y { get; }
        public float Z { get; }
        public float W { get; }

        public Vec4(float x, float y, float z, float w)
        {
            X = x;
            Y = y;
            Z = z;
            W = w;
        }

        public override string ToString() => $"({X}, {Y}, {Z}, {W})";
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Z.GetHashCode() ^ W.GetHashCode();
        public override bool Equals(object obj) => obj is Vec4 a && a == this;

        public static bool operator ==(Vec4 a, Vec4 b) => a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W;
        public static bool operator !=(Vec4 a, Vec4 b) => !(a.X == b.X && a.Y == b.Y && a.Z == b.Z && a.W == b.W);

        public static Vec4 operator +(Vec4 a, Vec4 b) => new Vec4(a.X + b.X, a.Y + b.Y, a.Z + b.Z, a.W + b.W);

        public static Vec4 operator -(Vec4 a) => new Vec4(-a.X, -a.Y, -a.Z, -a.W);

        public static Vec4 operator *(Vec4 a, Vec4 b) => new Vec4(a.X * b.X, a.Y * b.Y, a.Z * b.Z, a.W * a.W);

        public static implicit operator Vec4((float X, float Y, float Z, float W) v) => new Vec4(v.X, v.Y, v.Z, v.W);
        public static implicit operator (float X, float Y, float Z, float W)(Vec4 v) => (v.X, v.Y, v.Z, v.W);
    }
}
