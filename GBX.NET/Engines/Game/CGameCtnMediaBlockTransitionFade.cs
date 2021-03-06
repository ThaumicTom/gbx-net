﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text;

namespace GBX.NET.Engines.Game
{
    [Node(0x030AB000)]
    public class CGameCtnMediaBlockTransitionFade : CGameCtnMediaBlock
    {
        public Key[] Keys { get; set; }

        public Vec3 Color { get; set; }

        [Chunk(0x030AB000)]
        public class Chunk030AB000 : Chunk<CGameCtnMediaBlockTransitionFade>
        {
            public override void ReadWrite(CGameCtnMediaBlockTransitionFade n, GameBoxReaderWriter rw)
            {
                n.Keys = rw.Array(n.Keys, i =>
                {
                    var time = rw.Reader.ReadSingle();
                    var opacity = rw.Reader.ReadSingle();

                    return new Key()
                    {
                        Time = time,
                        Opacity = opacity
                    };
                },
                x =>
                {
                    rw.Writer.Write(x.Time);
                    rw.Writer.Write(x.Opacity);
                });

                n.Color = rw.Vec3(n.Color);
                rw.Single(Unknown);
            }
        }

        public class Key : MediaBlockKey
        {
            public float Opacity { get; set; }
        }
    }
}
