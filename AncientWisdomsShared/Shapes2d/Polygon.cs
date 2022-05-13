namespace AncientWisdoms;

public class Polygon : Shape
{
    public int Edges { get; private set; }

    public Polygon(IEnumerable<Vector2> vertices) : base(vertices)
    {
        Edges = Vertices.Count;
    }
}
