namespace AncientWisdoms.Tiles;

#nullable enable

public record struct HexTile(TileType TileType, List<HexTile> HexTiles)
{
    public static HexTile Default { get; } = new HexTile(
        new TileType(
            TileTerrainTypes.Water,
            TileEcologyTypes.Water,
            TileClimateTypes.Temperate,
            TileModifiers.Deep),
        new());
}
