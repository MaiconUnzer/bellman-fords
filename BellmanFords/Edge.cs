namespace BellmanFords
{
    public class Edge(int sourceVertex, int destinationVertex, int weight)
    {
        public int SourceVertex { get; private set; } = sourceVertex;
        public int DestinationVertex { get; private set; } = destinationVertex;
        public int Weight { get; private set; } = weight;
    }
}