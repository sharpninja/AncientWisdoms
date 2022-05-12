namespace AncientWisdoms.Tiles;

public struct TileType
{
    public TileTerrainTypes TileTerrainType { get; }
    public TileEcologyTypes TileEcologyType { get; }
    public TileClimateTypes TileClimateType { get; }
    public TileModifiers Modifiers { get; }

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

    public static bool Validate(TileType toValidate)
    {
        var valid = true;

        const TileModifiers OceanModifiers =
            TileModifiers.Ocean |
            TileModifiers.InlandSea;

        const TileModifiers LakeModifiers =
            TileModifiers.Lake & TileModifiers.Fresh;

        const TileClimateTypes SwampClimates =
            TileClimateTypes.Tropical |
            TileClimateTypes.Temperate;

        const TileModifiers SwampModifiers =
            (TileModifiers.River & TileModifiers.Delta) |
            TileModifiers.River;

        const TileModifiers RiverModifiers =
            (TileModifiers.River & TileModifiers.Delta) |
            TileModifiers.River;

        const TileTerrainTypes LandTerrain =
            TileTerrainTypes.Hills |
            TileTerrainTypes.Mountain |
            TileTerrainTypes.Flats;

        const TileClimateTypes AnyClimate =
            TileClimateTypes.Cold |
            TileClimateTypes.Temperate |
            TileClimateTypes.Savanah |
            TileClimateTypes.Tropical |
            TileClimateTypes.Desert;

        const TileClimateTypes OceanClimate =
            TileClimateTypes.Cold |
            TileClimateTypes.Temperate |
            TileClimateTypes.Savanah |
            TileClimateTypes.Tropical;

        const TileTerrainTypes ElevatedTerrain =
            TileTerrainTypes.Mountain | TileTerrainTypes.Hills;

        const TileEcologyTypes WoodedEcology =
            TileEcologyTypes.Conifer |
            TileEcologyTypes.Deciduous |
            TileEcologyTypes.Mixed |
            TileEcologyTypes.Jungle;

        const TileEcologyTypes TreelessEcology =
            TileEcologyTypes.Grassland |
            TileEcologyTypes.Plains |
            TileEcologyTypes.Rocky |
            TileEcologyTypes.Steppes |
            TileEcologyTypes.Desert;

        const TileEcologyTypes AnyEcology =
            WoodedEcology |
            TreelessEcology;

        valid &= (
            toValidate.TileTerrainType,
            toValidate.TileEcologyType,
            toValidate.TileClimateType,
            toValidate.Modifiers) switch
        {
            (TileTerrainTypes.Water, TileEcologyTypes.Water, TileClimateTypes.Frozen, OceanModifiers & TileModifiers.Tundra) => true,
            (TileTerrainTypes.Water, TileEcologyTypes.Water, OceanClimate, OceanModifiers) => true,
            (TileTerrainTypes.Water, TileEcologyTypes.Water, _, LakeModifiers) => true,
            (TileTerrainTypes.Flats, TileEcologyTypes.Swamp, SwampClimates, SwampModifiers) => true,
            (ElevatedTerrain, AnyEcology, AnyClimate,
                (TileModifiers.Caves | TileModifiers.Cliff) |
                (TileModifiers.River & TileModifiers.Waterfall) |
                RiverModifiers) => true,
            (LandTerrain, AnyEcology, AnyClimate, TileModifiers.None | RiverModifiers) => true,
            _ => false
        };

        return valid;
    }
}


