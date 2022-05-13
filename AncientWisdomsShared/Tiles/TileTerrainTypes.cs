using System;

namespace AncientWisdoms.Tiles;

[Flags]
public enum TileTerrainTypes
{
    None = 0,
    Water = 0b0001,
    Mountain = 0b0010,
    Hills = 0b0100,
    Flats = 0b1000,
}
