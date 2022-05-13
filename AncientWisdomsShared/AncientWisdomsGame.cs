using AncientWisdoms.Tiles;

namespace AncientWisdoms;

public enum GridType
{
    Triangle = 3,
    Square = 4,
    Hexagon = 6
}

public class AncientWisdomsGame : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    protected SpriteBatch SpriteBatch { get; private set; }
    protected SpriteFont SpriteFont { get; private set; }
    protected PrimitiveBatch PrimitiveBatch { get; }
    protected MouseState CurrentMouseState { get; private set; }
    protected MouseState PreviousMouseState { get; private set; }

    protected const float TriangleRatio = 0.86602540378443864676372317075294f;

    private static readonly GridType GridType = GridType.Hexagon;
    private static readonly Vector2 Scale = new(50);
    private static readonly Color BaseColor = Color.SaddleBrown;

    private readonly PrimitiveBatch primitiveBatch;
    private readonly float paintDistanceSquared;


    public AncientWisdomsGame()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;

        PrimitiveBatch = new PrimitiveBatch(this);
        Components.Add(PrimitiveBatch);

        primitiveBatch = new PrimitiveBatch(this);
        Components.Add(primitiveBatch);

        paintDistanceSquared = Scale.LengthSquared();
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    private void DrawTiles()
    {
        Vector2 ratio = GridType == GridType.Square ? Vector2.One : new Vector2(TriangleRatio, 1);

        float p = GridType == GridType.Triangle ? 2 :
                GridType == GridType.Hexagon ? 4f / 3 : 1;
        _ = (_graphics.PreferredBackBufferHeight / Scale.Y * p) + 1;
        _ = _graphics.PreferredBackBufferWidth / (int)(ratio.X * Scale.X);

        HexDistrict origin = new(
            new TileType(
                TileTerrainTypes.Water,
                TileEcologyTypes.Water,
                TileClimateTypes.Tropical,
                TileModifiers.Shallows)
            );

        (float x, float y, float z) = (50f, 50f, 0f);

        Vector2 position = new Vector2(x, y);

        switch (GridType)
        {
            case GridType.Triangle:
                position.X += Scale.X * ratio.X * 2 / 3;
                if (y % 2 == 1)
                {
                    position.X += -Scale.X * ratio.X / 3;
                }

                break;

            case GridType.Square:
                position += Scale / 2;
                break;

            case GridType.Hexagon:
                position.Y += -Scale.Y / 4;
                if (y % 2 == 1)
                {
                    position.X += Scale.X * ratio.X / 2;
                }

                break;

            default:
                throw new ArgumentOutOfRangeException();
        }

        HexTile tile = origin.Origin;
        var color =
                    (tile.TileType.TileTerrainType,
                     tile.TileType.TileEcologyType,
                     tile.TileType.TileEcologyType,
                     tile.TileType.Modifiers)
                    switch
                    {
                        (TileTerrainTypes.Water, _, _, TileModifiers.Shallows) => Color.LightBlue,
                        (TileTerrainTypes.Water, _, _, TileModifiers.Deep) => Color.Blue,
                        _ => Color.Green
                    };

        DrawTile(tile, position);

        void DrawTile(HexTile hexTile, Vector2 position)
        {
            (float X, float Y) = position;
            var even = X % 2 == 0;
            var polygon = new RegularPolygon((int)GridType)
            {
                Position = position,
                Stretch = Scale,
                Rotation = GridType != GridType.Square ? (float)(Math.PI * (even ? -1 : +1) / 2f) : 0,
                Fill = color,
                Stroke = Color.Black,
            };
            primitiveBatch.Primitives.Add(polygon);
            position.X += Scale.X * ratio.X * (GridType == GridType.Triangle ? (even ? 1 : 2) * 2f / 3 : 1);

            TileConnections[] array = Enum.GetValues<TileConnections>();
            for (int i = 0; i < array.Length; i++)
            {
                TileConnections conn = array[i];

                HexTile value = HexTile.Default;

                hexTile
                    .HexTiles?
                    .TryGetValue(conn, out value);

                bool gate = !value.Equals(HexTile.Default);

                if (gate)
                {
                    DrawTile(value!, position);
                }
                else
                {
                    continue;
                }
            }
        }
    }

    protected override void LoadContent()
    {
        base.LoadContent();

        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
        SpriteBatch = new SpriteBatch(GraphicsDevice);
        SpriteFont = Content.Load<SpriteFont>("Font");
        Components.Add(new FrameRateCounter(this, SpriteBatch, SpriteFont));
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back ==
            Microsoft.Xna.Framework.Input.ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
        {
            Exit();
        }

        // TODO: Add your update logic here

        base.Update(gameTime);

        //PreviousMouseState = CurrentMouseState;
        //CurrentMouseState = Mouse.GetState();

        //var scrollWheelOffset = CurrentMouseState.ScrollWheelValue - PreviousMouseState.ScrollWheelValue;
        //paintDistanceSquared += scrollWheelOffset / 2f;
        //if (paintDistanceSquared < 0) paintDistanceSquared = 0;

        //var toggleButtonPressed = CurrentMouseState.MiddleButton == ButtonState.Pressed && PreviousMouseState.MiddleButton != ButtonState.Pressed;

        //if (scrollWheelOffset != 0 || toggleButtonPressed || PreviousMouseState.Position != CurrentMouseState.Position || CurrentMouseState.LeftButton == ButtonState.Pressed || CurrentMouseState.RightButton == ButtonState.Pressed)
        //{
        //    var mousePosition = CurrentMouseState.Position.ToVector2();
        //    bool? visible = null;

        //    for (var i = 0; i < primitiveBatch.Primitives.Count; i++)
        //    {
        //        var primitive = primitiveBatch.Primitives[i];
        //        var shape = primitive as Shape;

        //        if (toggleButtonPressed && shape != null)
        //        {
        //            if (visible == null) visible = shape.Fill == Color.Transparent;
        //            shape.Fill = visible.Value ? GetRandomGridColor() : Color.Transparent;
        //        }

        //        if (Vector2.DistanceSquared(primitive.Position, mousePosition) < paintDistanceSquared)
        //        {
        //            if (shape != null)
        //            {
        //                if (CurrentMouseState.LeftButton == ButtonState.Pressed) shape.Fill = GetRandomGridColor();
        //                else if (CurrentMouseState.RightButton == ButtonState.Pressed) shape.Fill = Color.Transparent;
        //            }

        //            primitive.Stroke = Color.Red;
        //        }
        //        else
        //        {
        //            primitive.Stroke = Color.Transparent;
        //        }
        //    }
        //}
    }

    //private static Color GetRandomGridColor()
    //{
    //    return BaseColor.Darken(0, 0.75f).Lighten(0, 0.25f);
    //}

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Microsoft.Xna.Framework.Color.CornflowerBlue);

        // TODO: Add your drawing code here
        DrawTiles();

        base.Draw(gameTime);
    }
}
