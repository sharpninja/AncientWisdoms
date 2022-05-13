using System.Collections.Generic;

namespace AncientWisdoms.Tiles;

#nullable enable

public record struct HexTile(TileType TileType, IDictionary<TileConnections, HexTile> HexTiles)
{
    public static HexTile Default { get; } = new HexTile(
        new TileType(
            0,
            0),
        new Dictionary<TileConnections, HexTile>()
        {
            { TileConnections.NE, HexTile.Default },
            { TileConnections.E, HexTile.Default },
            { TileConnections.SE, HexTile.Default },
            { TileConnections.SW, HexTile.Default },
            { TileConnections.W, HexTile.Default },
            { TileConnections.NW, HexTile.Default },
        });
    public VertexPosition Position { get; internal set; }
}
