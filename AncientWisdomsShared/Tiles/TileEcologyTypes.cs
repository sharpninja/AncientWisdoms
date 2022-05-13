namespace AncientWisdoms.Tiles;

public enum TileEcologyTypes
{
    Water = 0b00000000001 << 11,
    Grassland = 0b00000000010 << 11,
    Plains = 0b00000000100 << 11,
    Rocky = 0b00000001000 << 11,
    Steppes = 0b00000010000 << 11,
    Desert = 0b00000100000 << 11,
    Swamp = 0b00001000000 << 11,
    Conifer = 0b00010000000 << 11,
    Deciduous = 0b00100000000 << 11,
    Mixed = 0b01000000000 << 11,
    Jungle = 0b10000000000 << 11,
}
