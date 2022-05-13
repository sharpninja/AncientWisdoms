namespace AncientWisdoms.Tiles;

public enum TileClimateTypes
{
    Frozen = 0b000001 << 5,
    Cold = 0b000010 << 5,
    Temperate = 0b000100 << 5,
    Savanah = 0b001000 << 5,
    Tropical = 0b010000 << 5,
    Desert = 0b100000 << 5,
}