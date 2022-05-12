namespace AncientWisdoms.Tiles;

public struct HexConnections : IReadOnlyDictionary<TileTerrainTypes, (TileTerrainTypes, float)[]>
{
    private readonly KeyValuePair<TileTerrainTypes, (TileTerrainTypes tileType, float chance)[]>[] _pairs;

    public IEnumerable<TileTerrainTypes> Keys => _pairs.Select(p => p.Key).ToList();
    public IEnumerable<(TileTerrainTypes, float)[]> Values => _pairs.Select(p => p.Value).ToList();
    public int Count { get; }
    public bool IsReadOnly { get; } = true;

    public (TileTerrainTypes, float)[] this[TileTerrainTypes key]
    {
        get => _pairs[(int)key].Value;
        set { }
    }

    public HexConnections()
    {
        Count = Enum.GetNames(typeof(TileTerrainTypes)).Length;
        _pairs = new KeyValuePair<TileTerrainTypes, (TileTerrainTypes tileType, float chance)[]>[]
        {
            new (
                TileTerrainTypes.WaterOcean,
                new[] {
                        (TileTerrainTypes.WaterOcean, 4f/6f),
                        (TileTerrainTypes.Beach, 1.9f/6f),
                        (TileTerrainTypes.OceanCliff, 0.1f/6f)
                }),
            new (
                TileTerrainTypes.RockyMountain,
                new[] {
                        (TileTerrainTypes.RockyMountain, 2f/6f),
                        (TileTerrainTypes.WoodedMountain, 1f/6f),
                        (TileTerrainTypes.WoodedHills, 1f/6f),
                        (TileTerrainTypes.RockyHills, 1.65f/6f),
                        (TileTerrainTypes.RiverMountain, 0.1f/6f),
                        (TileTerrainTypes.OceanCliff, 0.25f/6f),
                }),
            new (
                TileTerrainTypes.WoodedMountain,
                new[] {
                        (TileTerrainTypes.WoodedMountain, 3f/6f),
                        (TileTerrainTypes.RockyMountain, 2f/6f),
                        (TileTerrainTypes.WoodedHills, 0.65f/6f),
                        (TileTerrainTypes.RiverMountain, 0.1f/6f),
                        (TileTerrainTypes.OceanCliff, 0.25f/6f),
                }),
            new (
                TileTerrainTypes.RiverMountain,
                new[] {
                        (TileTerrainTypes.RiverMountain, 1.5f/6f),
                        (TileTerrainTypes.RockyMountain, 1.5f/6f),
                        (TileTerrainTypes.WoodedMountain, 1.5f/6f),
                        (TileTerrainTypes.RiverHills, 0.5f/6f),
                        (TileTerrainTypes.WoodedHills, 0.5f/6f),
                        (TileTerrainTypes.RockyHills, 0.5f/6f),
                }),
            new (
                TileTerrainTypes.RockyHills,
                new[] {
                        (TileTerrainTypes.RockyHills, 2f/6f),
                        (TileTerrainTypes.RockyMountain, 1f/6f),
                        (TileTerrainTypes.WoodedHills, .6f/6f),
                        (TileTerrainTypes.DesertHills, .4f/6f),
                        (TileTerrainTypes.RockyFlats, 1f/6f),
                        (TileTerrainTypes.RiverHills, 0.5f/6f),
                        (TileTerrainTypes.OceanCliff, 0.5f/6f),
                }),
            new (
                TileTerrainTypes.WoodedHills,
                new[] {
                        (TileTerrainTypes.WoodedHills, 2f/6f),
                        (TileTerrainTypes.WoodedMountain, 1f/6f),
                        (TileTerrainTypes.RockyHills, 1f/6f),
                        (TileTerrainTypes.WoodedFlats, 1f/6f),
                        (TileTerrainTypes.RiverHills, 0.5f/6f),
                        (TileTerrainTypes.OceanCliff, 0.5f/6f),
                }),
            new (
                TileTerrainTypes.DesertHills,
                new[] {
                        (TileTerrainTypes.DesertHills, 2f/6f),
                        (TileTerrainTypes.RockyMountain, 1f/6f),
                        (TileTerrainTypes.RockyHills, 1f/6f),
                        (TileTerrainTypes.DesertFlats, 1f/6f),
                        (TileTerrainTypes.RiverHills, 0.5f/6f),
                        (TileTerrainTypes.OceanCliff, 0.5f/6f),
                }),
            new (
                TileTerrainTypes.PlainsHills,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.GrassyHills,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.RiverHills,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.RockyFlats,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.WoodedFlats,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.DesertFlats,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.PlainsFlats,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.GrassyFlats,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.RiverFlat,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.Beach,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.Riverbank,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.OceanCliff,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
            new (
                TileTerrainTypes.RiverCliff,
new (TileTerrainTypes, float)[] { (TileTerrainTypes.WaterOcean, 0.75f), (TileTerrainTypes.Beach, 0.2f), (TileTerrainTypes.OceanCliff, 0.05f) }),
              };
    }

    public bool ContainsKey(TileTerrainTypes key)
    {
        return true;
    }

    public bool TryGetValue(TileTerrainTypes key, out (TileTerrainTypes, float)[] value)
    {
        value = this[key];
        return true;
    }

    public bool Contains(KeyValuePair<TileTerrainTypes, (TileTerrainTypes, float)[]> item)
    {
        return _pairs.Contains(item);
    }

    public void CopyTo(KeyValuePair<TileTerrainTypes, (TileTerrainTypes, float)[]>[] array, int arrayIndex)
    {
        foreach (KeyValuePair<TileTerrainTypes, (TileTerrainTypes, float)[]> pair in _pairs)
        {
            array[arrayIndex++] = pair;
        }
    }

    public IEnumerator<KeyValuePair<TileTerrainTypes, (TileTerrainTypes, float)[]>> GetEnumerator()
    {
        return (IEnumerator<KeyValuePair<TileTerrainTypes, (TileTerrainTypes, float)[]>>)_pairs.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _pairs.GetEnumerator();
    }
}



