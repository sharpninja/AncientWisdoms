using Size=MonoGame.Extended.Size;

namespace AncientWisdoms.Tiles;

public struct HexDistrict
{
    public HexTile Origin { get; }
    public Size Size { get; }
    public TileType PrimaryTileType { get; }

    public HexDistrict(TileType primaryTileType)
    {
        Origin = MakeOrigin(primaryTileType);
        PrimaryTileType = primaryTileType;
        Size = GenerateHexDistrict(this, Origin.HexTiles[TileConnections.E], TileConnections.SE);
    }

    private static HexTile MakeOrigin(TileType primaryTileType)
    {
        var origin = new HexTile(
            primaryTileType,
            new Dictionary<TileConnections, HexTile>()
            {
                { TileConnections.NE,CreateHexTile(primaryTileType) },
                { TileConnections.E, CreateHexTile(primaryTileType) },
                { TileConnections.SE, CreateHexTile(primaryTileType) },
                { TileConnections.SW, CreateHexTile(primaryTileType) },
                { TileConnections.W, CreateHexTile(primaryTileType) },
                { TileConnections.NW, CreateHexTile(primaryTileType) },
            });

        origin.HexTiles[TileConnections.NE].HexTiles[TileConnections.SW] = origin;

        return origin;
    }

    private static HexTile CreateHexTile(TileType primaryTileType)
        => HexTile.Default with { TileType = primaryTileType };

    private static Size GenerateHexDistrict(
        HexDistrict self,
        HexTile predecessor,
        TileConnections next)
    {
        Random rand = new((int)DateTime.Now.Ticks);
        Size min = new(5, 5);
        Size max = new(15, 15);
        Size actual = new(
            rand.Next(min.Width, max.Width),
            rand.Next(min.Height, max.Height));
        int originX = rand.Next(0, actual.Width - 2) + 1;
        int originY = rand.Next(0, actual.Height - 2) + 1;

        TileConnections direction = (TileConnections)rand.Next((int)TileConnections.NE, (int)TileConnections.NW);
        VertexPosition position;

        if (predecessor.Position == default)
        {
            position = new VertexPosition(new Vector3(new Vector2(originX, originY), 0));

            predecessor = self.Origin.HexTiles[direction];
            predecessor.Position = position;
        }
        else
        {
            position = predecessor.Position;
        }

#pragma warning disable CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.
        position = next switch
        {
            TileConnections.NE => new VertexPosition(new Vector3(new Vector2(position.Position.X + 1, position.Position.Y - 1), 0)),
            TileConnections.E => new VertexPosition(new Vector3(new Vector2(position.Position.X + 1, position.Position.Y), 0)),
            TileConnections.SE => new VertexPosition(new Vector3(new Vector2(position.Position.X + 1, position.Position.Y + 1), 0)),
            TileConnections.SW => new VertexPosition(new Vector3(new Vector2(position.Position.X - 1, position.Position.Y + 1), 0)),
            TileConnections.W => new VertexPosition(new Vector3(new Vector2(position.Position.X - 1, position.Position.Y), 0)),
            TileConnections.NW => new VertexPosition(new Vector3(new Vector2(position.Position.X - 1, position.Position.Y - 1), 0)),
        };
#pragma warning restore CS8524 // The switch expression does not handle some values of its input type (it is not exhaustive) involving an unnamed enum value.

        if (predecessor.HexTiles[direction].Equals(HexTile.Default))
        {
            var tileType = predecessor.TileType.TileTerrainType switch
            {
                TileTerrainTypes.Water => GetNextTerrain(position, predecessor, TileType.WaterTransitions),
                TileTerrainTypes.Hills => GetNextTerrain(position, predecessor, TileType.HillsTransitions),
                TileTerrainTypes.Flats => GetNextTerrain(position, predecessor, TileType.FlatsTransitions),
                TileTerrainTypes.Mountain => GetNextTerrain(position, predecessor, TileType.MountainTransitions),
                _ => GetNextTerrain(position, predecessor, TileType.TerrainTransitions),
            };

            predecessor.HexTiles[direction] = HexTile.Default with { TileType = tileType, Position = position };
        }

        return actual;
    }

    private static TileType GetNextTerrain(
        VertexPosition position,
        HexTile currentTile,
        TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] transitions)
    {
        return currentTile.TileType;
    }
}