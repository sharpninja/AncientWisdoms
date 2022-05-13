namespace AncientWisdoms.Tiles;

public record struct TileTransitionPair<TType>(TType Start, TType Target, float[] Odds);


public struct TileType
{
    public const long OceanModifiers =
        (long)(TileModifiers.Ocean | TileModifiers.InlandSea);

    public const long LakeModifiers =
        (long)(TileModifiers.Lake & TileModifiers.Fresh);

    public const long SwampClimates =
        (long)(TileClimateTypes.Tropical | TileClimateTypes.Temperate);

    public const long SwampModifiers =
        (long)((TileModifiers.River & TileModifiers.Delta) |
        TileModifiers.River);

    public const long RiverModifiers =
        (long)((TileModifiers.River & TileModifiers.Delta) |
        TileModifiers.River);

    public const long LandTerrain =
        (long)(TileTerrainTypes.Hills |
        TileTerrainTypes.Mountain |
        TileTerrainTypes.Flats);

    public const long AnyClimate =
        (long)(TileClimateTypes.Cold |
        TileClimateTypes.Temperate |
        TileClimateTypes.Savanah |
        TileClimateTypes.Tropical |
        TileClimateTypes.Desert);

    public const long OceanClimate =
        (long)(TileClimateTypes.Cold |
        TileClimateTypes.Temperate |
        TileClimateTypes.Savanah |
        TileClimateTypes.Tropical);

    public const long ElevatedTerrain =
        (long)(TileTerrainTypes.Mountain | TileTerrainTypes.Hills);

    public const long WoodedEcology =
        (long)(TileEcologyTypes.Conifer |
        TileEcologyTypes.Deciduous |
        TileEcologyTypes.Mixed |
        TileEcologyTypes.Jungle);

    public const long TreelessEcology =
        (long)(TileEcologyTypes.Grassland |
        TileEcologyTypes.Plains |
        TileEcologyTypes.Rocky |
        TileEcologyTypes.Steppes |
        TileEcologyTypes.Desert);

    public const long AnyEcology =
        WoodedEcology | TreelessEcology;

    public const long FrozenOceanTileType =
        (long)TileTerrainTypes.Water +
        (long)TileEcologyTypes.Water +
        (long)TileClimateTypes.Frozen;

    public const long OceanTileType =
        (long)TileTerrainTypes.Water +
        (long)TileEcologyTypes.Water +
        OceanClimate;

    public const long LakeTileType =
        (long)TileTerrainTypes.Water +
        (long)TileEcologyTypes.Water +
        AnyClimate;

    public const long SwampTileType =
        (long)TileTerrainTypes.Flats +
        (long)TileEcologyTypes.Swamp +
        SwampClimates;

    public const long ElevatedType =
        ElevatedTerrain +
        AnyEcology +
        AnyClimate;

    public const long ElevatedModifiers =
         (long)(TileModifiers.Caves | TileModifiers.Cliff |
                (TileModifiers.River & TileModifiers.Waterfall)) +
                RiverModifiers;

    public const long LandType =
             LandTerrain + AnyEcology + AnyClimate;

    public TileTerrainTypes TileTerrainType { get; }
    public TileEcologyTypes TileEcologyType { get; }
    public TileClimateTypes TileClimateType { get; }
    public TileModifiers Modifiers { get; }

    public static readonly TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] TerrainTransitions =
    {
        new ((TileTerrainTypes.Water,TileModifiers.Shallows), (TileTerrainTypes.Water,TileModifiers.Shallows), new float[] { 1f, 1f, 1f, 1f, 1f,  }),
        new ((TileTerrainTypes.Water,TileModifiers.Shallows), (TileTerrainTypes.Water,TileModifiers.Deep), new float[] { 0.7f, 0.91f, 0.7f, 0.77f, 0.84f,  }),
        new ((TileTerrainTypes.Water,TileModifiers.Deep), (TileTerrainTypes.Water,TileModifiers.Deep), new float[] { 1f, 0.91f, 1f, 0.97f, 1f,  }),
        new ((TileTerrainTypes.Water,TileModifiers.Deep), (TileTerrainTypes.Water,TileModifiers.Shallows), new float[] { 0.7f, 0.91f, 0.7f, 0.77f, 0.84f,  }),
        new ((TileTerrainTypes.Water,TileModifiers.Waterfall), (TileTerrainTypes.Water,TileModifiers.Shallows), new float[] { 1f, 1f, 1f, 1f, 1f,  }),
        new ((TileTerrainTypes.Water,TileModifiers.Shallows), (TileTerrainTypes.Flats,TileModifiers.Beach), new float[] { 0.05f, 0.91f, 0.05f, 0.336666666666667f, 0.623333333333333f,  }),
        new ((TileTerrainTypes.Water,TileModifiers.Shallows), (TileTerrainTypes.Hills,TileModifiers.Cliff), new float[] { 0.05f, 0.91f, 0.05f, 0.336666666666667f, 0.623333333333333f,  }),
        new ((TileTerrainTypes.Water,TileModifiers.Shallows), (TileTerrainTypes.Mountain,TileModifiers.Cliff), new float[] { 0.05f, 0.91f, 0.05f, 0.336666666666667f, 0.623333333333333f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.None), (TileTerrainTypes.Flats,TileModifiers.None), new float[] { 1f, 1f, 1f, 1f, 1f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.None), (TileTerrainTypes.Flats,TileModifiers.Riverbank), new float[] { 0.1f, 0f, 0.1f, 0.0666666666666667f, 0.0333333333333333f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.None), (TileTerrainTypes.Flats,TileModifiers.Tundra), new float[] { 0.2f, 0.75f, 0.2f, 0.383333333333333f, 0.566666666666667f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.Tundra), (TileTerrainTypes.Flats,TileModifiers.Tundra), new float[] { 0.2f, 1f, 0.2f, 0.466666666666667f, 0.733333333333333f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.None), new float[] { 0.2f, 0.75f, 0.2f, 0.383333333333333f, 0.566666666666667f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.Riverbank), new float[] { 0.1f, 0f, 0.1f, 0.0666666666666667f, 0.0333333333333333f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.Tundra), new float[] { 0.2f, 0.2f, 0.2f, 0.2f, 0.2f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.Tundra), (TileTerrainTypes.Hills,TileModifiers.Tundra), new float[] { 0.2f, 0.5f, 0.2f, 0.3f, 0.4f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.Riverbank), (TileTerrainTypes.Water,TileModifiers.River), new float[] { 1f, 1f, 1f, 1f, 1f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.Delta), (TileTerrainTypes.Water,TileModifiers.Ocean), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.Delta), (TileTerrainTypes.Water,TileModifiers.Lake), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Flats,TileModifiers.Delta), (TileTerrainTypes.Water,TileModifiers.InlandSea), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.None), new float[] { 1f, 1f, 1f, 1f, 1f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.Riverbank), new float[] { 0.05f, 0f, 0.05f, 0.0333333333333333f, 0.0166666666666667f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.Tundra), new float[] { 0.05f, 0.5f, 0.05f, 0.2f, 0.35f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Tundra), (TileTerrainTypes.Hills,TileModifiers.Tundra), new float[] { 0.55f, 0.82f, 0.55f, 0.64f, 0.73f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Flats,TileModifiers.None), new float[] { 0.2f, 0.75f, 0.2f, 0.383333333333333f, 0.566666666666667f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Flats,TileModifiers.Riverbank), new float[] { 0.05f, 0f, 0.05f, 0.0333333333333333f, 0.0166666666666667f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Flats,TileModifiers.Tundra), new float[] { 0.025f, 0.25f, 0.025f, 0.1f, 0.175f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Tundra), (TileTerrainTypes.Flats,TileModifiers.Tundra), new float[] { 0.275f, 0.41f, 0.275f, 0.32f, 0.365f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Mountain,TileModifiers.None), new float[] { 0.2f, 0.75f, 0.2f, 0.383333333333333f, 0.566666666666667f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Mountain,TileModifiers.Riverbank), new float[] { 0.05f, 0f, 0.05f, 0.0333333333333333f, 0.0166666666666667f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.None), (TileTerrainTypes.Mountain,TileModifiers.Tundra), new float[] { 0.025f, 0.25f, 0.025f, 0.1f, 0.175f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Tundra), (TileTerrainTypes.Mountain,TileModifiers.Tundra), new float[] { 0.275f, 0.41f, 0.275f, 0.32f, 0.365f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Riverbank), (TileTerrainTypes.Water,TileModifiers.River), new float[] { 0.25f, 0.25f, 0.25f, 0.25f, 0.25f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Waterfall), (TileTerrainTypes.Water,TileModifiers.Ocean), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Waterfall), (TileTerrainTypes.Water,TileModifiers.Lake), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Waterfall), (TileTerrainTypes.Water,TileModifiers.InlandSea), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Cliff), (TileTerrainTypes.Water,TileModifiers.Ocean), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Cliff), (TileTerrainTypes.Water,TileModifiers.Lake), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Hills,TileModifiers.Cliff), (TileTerrainTypes.Water,TileModifiers.InlandSea), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.None), (TileTerrainTypes.Mountain,TileModifiers.None), new float[] { 1f, 1f, 1f, 1f, 1f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.None), (TileTerrainTypes.Mountain,TileModifiers.Riverbank), new float[] { 0.05f, 0f, 0.05f, 0.0333333333333333f, 0.0166666666666667f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.None), (TileTerrainTypes.Mountain,TileModifiers.Tundra), new float[] { 0.05f, 0.6f, 0.05f, 0.233333333333333f, 0.416666666666667f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.Tundra), (TileTerrainTypes.Mountain,TileModifiers.Tundra), new float[] { 0.75f, 0.91f, 0.75f, 0.803333333333333f, 0.856666666666667f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.None), new float[] { 0.25f, 0.75f, 0.25f, 0.416666666666667f, 0.583333333333333f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.Riverbank), new float[] { 0.05f, 0f, 0.05f, 0.0333333333333333f, 0.0166666666666667f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.None), (TileTerrainTypes.Hills,TileModifiers.Tundra), new float[] { 0.05f, 0.6f, 0.05f, 0.233333333333333f, 0.416666666666667f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.Tundra), (TileTerrainTypes.Hills,TileModifiers.Tundra), new float[] { 0.25f, 0.75f, 0.25f, 0.416666666666667f, 0.583333333333333f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.Riverbank), (TileTerrainTypes.Water,TileModifiers.River), new float[] { 1f, 1f, 1f, 1f, 1f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.Cliff), (TileTerrainTypes.Water,TileModifiers.Ocean), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.Cliff), (TileTerrainTypes.Water,TileModifiers.Lake), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
        new ((TileTerrainTypes.Mountain,TileModifiers.Cliff), (TileTerrainTypes.Water,TileModifiers.InlandSea), new float[] { 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f, 0.333333333333333f,  }),
    };
    private static TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] _waterTransitions;
    private static TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] _flatsTransitions;
    private static TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] _hillsTransitions;
    private static TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] _mountainTransitions;
    public static TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] WaterTransitions
        => _waterTransitions
            ??= TerrainTransitions.Where(
                t => t.Start.terrainType == TileTerrainTypes.Water).ToArray();
    public static TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] FlatsTransitions
        => _flatsTransitions
            ??= TerrainTransitions.Where(
                t => t.Start.terrainType == TileTerrainTypes.Flats).ToArray();
    public static TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] HillsTransitions
        => _hillsTransitions
            ??= TerrainTransitions.Where(
                t => t.Start.terrainType == TileTerrainTypes.Hills).ToArray();
    public static TileTransitionPair<(TileTerrainTypes terrainType, TileModifiers modifier)>[] MountainTransitions
        => _mountainTransitions
            ??= TerrainTransitions.Where(
                t => t.Start.terrainType == TileTerrainTypes.Mountain).ToArray();

    public TileType(
        TileTerrainTypes tileTerrainType,
        TileEcologyTypes tileEcologyType,
        TileClimateTypes tileClimateType,
        TileModifiers modifiers = TileModifiers.None)
    {
        TileTerrainType = tileTerrainType;
        TileEcologyType = tileEcologyType;
        TileClimateType = tileClimateType;
        Modifiers = modifiers;
    }

    public TileType(
        long tileTerrainType,
        long tileEcologyType,
        long tileClimateType,
        long modifiers = (long)TileModifiers.None)
    {
        TileTerrainType = (TileTerrainTypes)tileTerrainType;
        TileEcologyType = (TileEcologyTypes)tileEcologyType;
        TileClimateType = (TileClimateTypes)tileClimateType;
        Modifiers = (TileModifiers)modifiers;
    }

    public TileType(
        long tileDefinition,
        long modifiers = (long)TileModifiers.None)
    {
        TileTerrainType = (TileTerrainTypes)(tileDefinition & 0b00000000000_000000_11111);
        TileClimateType = (TileClimateTypes)(tileDefinition & 0b00000000000_111111_00000);
        TileEcologyType = (TileEcologyTypes)(tileDefinition & 0b11111111111_000000_00000);
        Modifiers = (TileModifiers)modifiers;
    }

    public static bool Validate(TileType toValidate)
    {
        bool valid = true;

        long type =
            (long)toValidate.TileTerrainType +
            (long)toValidate.TileEcologyType +
            (long)toValidate.TileClimateType;

        long mods =
            (long)toValidate.Modifiers;

        (bool, bool, bool, bool, bool, bool) matrix = (
                (type & FrozenOceanTileType) == type && (mods & OceanModifiers) == mods,
                (type & OceanTileType) == type && mods == 0,
                (type & LakeTileType) == type && (mods & LakeModifiers) == mods,
                (type & SwampTileType) == type && (mods & SwampModifiers) == mods,
                (type & ElevatedType) == type && (mods & ElevatedModifiers) == mods,
                (type & LandType) == type && (mods & RiverModifiers) == mods
            );

        valid &= matrix switch
        {
            (true, _, _, _, _, _) => true,
            (_, true, _, _, _, _) => true,
            (_, _, true, _, _, _) => true,
            (_, _, _, true, _, _) => true,
            (_, _, _, _, true, _) => true,
            (_, _, _, _, _, true) => true,
            _ => false
        };

        return valid;
    }
}


