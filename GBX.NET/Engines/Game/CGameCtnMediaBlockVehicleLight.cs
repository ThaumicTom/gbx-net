﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GBX.NET.Engines.Game
{
    [Node(0x03133000)]
    public class CGameCtnMediaBlockVehicleLight : CGameCtnMediaBlock
    {
        public float Start { get; set; }
        public float End { get; set; }
        public int Target { get; set; }

        public CGameCtnMediaBlockVehicleLight(ILookbackable lookbackable, uint classID) : base(lookbackable, classID)
        {

        }

        [Chunk(0x03133000)]
        public class Chunk03133000 : Chunk<CGameCtnMediaBlockVehicleLight>
        {
            public override void ReadWrite(CGameCtnMediaBlockVehicleLight n, GameBoxReaderWriter rw)
            {
                n.Start = rw.Single(n.Start);
                n.End = rw.Single(n.End);
            }
        }

        [Chunk(0x03133001)]
        public class Chunk03133001 : Chunk<CGameCtnMediaBlockVehicleLight>
        {
            public override void ReadWrite(CGameCtnMediaBlockVehicleLight n, GameBoxReaderWriter rw)
            {
                n.Target = rw.Int32(n.Target);
            }
        }
    }
}
