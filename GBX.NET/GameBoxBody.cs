﻿using ManagedLZO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization;

namespace GBX.NET
{
    public class GameBoxBody<T> : GameBoxBody where T : Node
    {
        public int? CompressedSize { get; }
        public int UncompressedSize { get; }
        public byte[] Rest { get; }
        public bool Aborting { get; private set; }

        public new GameBox<T> GBX => (GameBox<T>)base.GBX;

        /// <summary>
        /// Body with uncompressed data with compression parameters
        /// </summary>
        /// <param name="data">UNCOMPRESSED</param>
        /// <param name="compressedSize"></param>
        /// <param name="uncompressedSize"></param>
        public GameBoxBody(GameBox<T> gbx, uint mainNodeID, byte[] data, int? compressedSize, int uncompressedSize) : base(gbx)
        {
            CompressedSize = compressedSize;
            UncompressedSize = uncompressedSize;

            using (var s = new MemoryStream(data))
            using (var gbxr = new GameBoxReader(s, this))
            {
                gbx.MainNode = Node.Parse<T>(this, gbxr, mainNodeID);
                Debug.WriteLine("Amount read: " + (s.Position / (float)s.Length).ToString("P"));

                byte[] restBuffer = new byte[s.Length - s.Position];
                gbxr.Read(restBuffer, 0, restBuffer.Length);
                Rest = restBuffer;
            }
        }

        public static GameBoxBody<T> DecompressAndConstruct(GameBox<T> gbx, uint mainNodeID, byte[] data, int compressedSize, int uncompressedSize)
        {
            byte[] buffer = new byte[uncompressedSize];
            MiniLZO.Decompress(data, buffer);
            return new GameBoxBody<T>(gbx, mainNodeID, buffer, compressedSize, uncompressedSize);
        }

        public void Write(GameBoxWriter w)
        {
            Write(w, ClassIDRemap.Latest);
        }

        public void Write(GameBoxWriter w, ClassIDRemap remap)
        {
            if(GBX.BodyCompression == 'C')
            {
                using (var msBody = new MemoryStream())
                using (var gbxwBody = new GameBoxWriter(msBody, this))
                {
                    GBX.MainNode.Write(gbxwBody, remap);
                    MiniLZO.Compress(msBody.ToArray(), out byte[] output);

                    w.Write((int)msBody.Length); // Uncompressed
                    w.Write(output.Length); // Compressed
                    w.Write(output, 0, output.Length); // Compressed body data
                }
            }
            else
                GBX.MainNode.Write(w);

            // ...
        }

        [Obsolete]
        public void Abort()
        {
            Aborting = true;
        }

        public new TChunk CreateChunk<TChunk>(byte[] data) where TChunk : Chunk<T>
        {
            return GBX.MainNode.Chunks.Create<TChunk>(data);
        }

        public new TChunk CreateChunk<TChunk>() where TChunk : Chunk<T>
        {
            return CreateChunk<TChunk>(new byte[0]);
        }

        public void InsertChunk(Chunk<T> chunk)
        {
            GBX.MainNode.Chunks.Add(chunk);
        }

        public new void DiscoverChunk<TChunk>() where TChunk : SkippableChunk<T>
        {
            foreach (var chunk in GBX.MainNode.Chunks)
                if (chunk is TChunk c)
                    c.Discover();
        }

        public new void DiscoverChunks<TChunk1, TChunk2>() where TChunk1 : SkippableChunk<T> where TChunk2 : SkippableChunk<T>
        {
            foreach (var chunk in GBX.MainNode.Chunks)
            {
                if (chunk is TChunk1 c1)
                    c1.Discover();
                if (chunk is TChunk2 c2)
                    c2.Discover();
            }
        }

        public new void DiscoverChunks<TChunk1, TChunk2, TChunk3>()
            where TChunk1 : SkippableChunk<T>
            where TChunk2 : SkippableChunk<T>
            where TChunk3 : SkippableChunk<T>
        {
            foreach (var chunk in GBX.MainNode.Chunks)
            {
                if (chunk is TChunk1 c1)
                    c1.Discover();
                if (chunk is TChunk2 c2)
                    c2.Discover();
                if (chunk is TChunk3 c3)
                    c3.Discover();
            }
        }

        public new void DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4>()
            where TChunk1 : SkippableChunk<T>
            where TChunk2 : SkippableChunk<T>
            where TChunk3 : SkippableChunk<T>
            where TChunk4 : SkippableChunk<T>
        {
            foreach (var chunk in GBX.MainNode.Chunks)
            {
                if (chunk is TChunk1 c1)
                    c1.Discover();
                if (chunk is TChunk2 c2)
                    c2.Discover();
                if (chunk is TChunk3 c3)
                    c3.Discover();
                if (chunk is TChunk4 c4)
                    c4.Discover();
            }
        }

        public new void DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4, TChunk5>()
            where TChunk1 : SkippableChunk<T>
            where TChunk2 : SkippableChunk<T>
            where TChunk3 : SkippableChunk<T>
            where TChunk4 : SkippableChunk<T>
            where TChunk5 : SkippableChunk<T>
        {
            foreach (var chunk in GBX.MainNode.Chunks)
            {
                if (chunk is TChunk1 c1)
                    c1.Discover();
                if (chunk is TChunk2 c2)
                    c2.Discover();
                if (chunk is TChunk3 c3)
                    c3.Discover();
                if (chunk is TChunk4 c4)
                    c4.Discover();
                if (chunk is TChunk5 c5)
                    c5.Discover();
            }
        }

        public new void DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4, TChunk5, TChunk6>()
            where TChunk1 : SkippableChunk<T>
            where TChunk2 : SkippableChunk<T>
            where TChunk3 : SkippableChunk<T>
            where TChunk4 : SkippableChunk<T>
            where TChunk5 : SkippableChunk<T>
            where TChunk6 : SkippableChunk<T>
        {
            foreach (var chunk in GBX.MainNode.Chunks)
            {
                if (chunk is TChunk1 c1)
                    c1.Discover();
                if (chunk is TChunk2 c2)
                    c2.Discover();
                if (chunk is TChunk3 c3)
                    c3.Discover();
                if (chunk is TChunk4 c4)
                    c4.Discover();
                if (chunk is TChunk5 c5)
                    c5.Discover();
                if (chunk is TChunk6 c6)
                    c6.Discover();
            }
        }

        public new void DiscoverAllChunks()
        {
            foreach (var chunk in GBX.MainNode.Chunks)
                if (chunk is SkippableChunk<T> s)
                    s.Discover();
        }

        public new TChunk GetChunk<TChunk>() where TChunk : Chunk<T>
        {
            foreach (var chunk in GBX.MainNode.Chunks)
            {
                if (chunk is TChunk t)
                {
                    if (chunk is SkippableChunk<T> s) s.Discover();
                    return t;
                }
            }
            return default;
        }

        public new bool TryGetChunk<TChunk>(out TChunk chunk) where TChunk : Chunk<T>
        {
            chunk = GetChunk<TChunk>();
            return chunk != default;
        }

        public void RemoveAllChunks()
        {
            GBX.MainNode.Chunks.Clear();
        }

        public new bool RemoveChunk<TChunk>() where TChunk : Chunk<T>
        {
            return GBX.MainNode.Chunks.Remove<TChunk>();
        }
    }

    public class GameBoxBody : GameBoxPart
    {
        [IgnoreDataMember]
        public List<Node> AuxilaryNodes { get; } = new List<Node>();

        public GameBoxBody(GameBox gbx) : base(gbx)
        {

        }

        public override T CreateChunk<T>(byte[] data)
        {
            throw new NotSupportedException();
        }

        public override T CreateChunk<T>()
        {
            throw new NotSupportedException();
        }

        public override void InsertChunk(Chunk chunk)
        {
            throw new NotSupportedException();
        }

        public override void DiscoverChunk<TChunk>()
        {
            (this as dynamic).DiscoverChunk<TChunk>();
        }

        public override void DiscoverChunks<TChunk1, TChunk2>()
        {
            (this as dynamic).DiscoverChunks<TChunk1, TChunk2>();
        }

        public override void DiscoverChunks<TChunk1, TChunk2, TChunk3>()
        {
            (this as dynamic).DiscoverChunks<TChunk1, TChunk2, TChunk3>();
        }

        public override void DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4>()
        {
            (this as dynamic).DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4>();
        }

        public override void DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4, TChunk5>()
        {
            (this as dynamic).DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4, TChunk5>();
        }

        public override void DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4, TChunk5, TChunk6>()
        {
            (this as dynamic).DiscoverChunks<TChunk1, TChunk2, TChunk3, TChunk4, TChunk5, TChunk6>();
        }

        public override void DiscoverAllChunks()
        {
            (this as dynamic).DiscoverAllChunks();
        }

        public override T GetChunk<T>()
        {
            throw new NotSupportedException();
        }

        public override bool TryGetChunk<T>(out T chunk)
        {
            throw new NotSupportedException();
        }

        public override bool RemoveChunk<T>()
        {
            throw new NotSupportedException();
        }
    }
}
