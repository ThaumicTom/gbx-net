﻿namespace GBX.NET.Engines.Game
{
    /// <summary>
    /// Puzzle piece list (0x0301B000)
    /// </summary>
    /// <remarks>A list of puzzle pieces.</remarks>
    [Node(0x0301B000)]
    public class CGameCtnCollectorList : Node
    {
        public Collector[] CollectorStock { get; set; }

        #region Chunks

        #region 0x000 chunk

        /// <summary>
        /// CGameCtnCollectorList 0x000 chunk
        /// </summary>
        [Chunk(0x0301B000)]
        public class Chunk0301B000 : Chunk<CGameCtnCollectorList>
        {
            public override void ReadWrite(CGameCtnCollectorList n, GameBoxReaderWriter rw)
            {
                n.CollectorStock = rw.Array(n.CollectorStock,
                i => new Collector()
                {
                    Meta = rw.Reader.ReadMeta(),
                    Count = rw.Reader.ReadInt32()
                },
                x =>
                {
                    rw.Writer.Write(x.Meta);
                    rw.Writer.Write(x.Count);
                });
            }
        }

        #endregion

        #endregion

        public class Collector
        {
            public Meta Meta { get; set; }
            public int Count { get; set; }
        }
    }
}
