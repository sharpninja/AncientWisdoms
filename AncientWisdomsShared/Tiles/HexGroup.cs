namespace AncientWisdoms.Tiles;

public struct HexGroup
{
    public HexTile Origin { get; }

    public HexGroup(int height, int width)
    {
        Origin = new HexTile(
            TileTerrainTypes.Beach,
            GenerateHexTiles(TileTerrainTypes.Beach,
                             HexTile.Default,
                             new Random().Next(0, 5)));

    }

    private static HexTile[] GenerateHexTiles(TileTerrainTypes tileType, HexTile predecessor, int next)
    {
        TileConnections nextConnection = (TileConnections)next;
        List<HexTile> result = new ();

        foreach (var conn in Enum.GetValues<TileConnections>())
        {

        }

        return result.ToArray();
    }
}