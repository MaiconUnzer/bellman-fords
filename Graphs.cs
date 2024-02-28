namespace BellmanFords
{
    public class Graph
    {
        public int AmountOfVertices => Vertices?.Count ?? 0;
        public int AmountOfEdges => Edges?.Count ?? 0;
        public List<Edge> Edges { get; private set; } = [];
        public HashSet<int> Vertices { get; private set; } = [];

        public void AddEdge(int sourceVertex, int destinationVertex, int weight) => AddEdge(new Edge(sourceVertex, destinationVertex, weight));

        public void AddEdge(Edge edge)
        {
            Edges.Add(edge);
            Vertices.Add(edge.SourceVertex);
            Vertices.Add(edge.DestinationVertex);
        }

        public void BellmanFord(int source)
        {
            int amountVertices = AmountOfVertices;
            int amountEdges = AmountOfEdges;
            var distance = new int[amountVertices];

            // Step 1: fill the distance array and predecessor array
            for (int i = 0; i < amountVertices; ++i)
                distance[i] = int.MaxValue;

            // Mark the source vertex
            distance[source] = 0;

            // Step 2: relax edges |V| - 1 times
            for (int i = 1; i < amountVertices; ++i)//O(V)
                for (int j = 0; j < amountEdges; ++j)//O(E) 
                {
                    //O(V . E) = O(N2) - worst than Dijkstra, but, can handle negative paths
                    var edge = Edges[j];
                    int sourceVertex = edge.SourceVertex;
                    int destinationVertex = edge.DestinationVertex;
                    int weight = edge.Weight;

                    var sourceVertexDistance = distance[sourceVertex];
                    var destinationVertexDistance = distance[destinationVertex];
                    var newDistance = sourceVertexDistance + weight;

                    if (sourceVertexDistance != int.MaxValue && newDistance < destinationVertexDistance)
                        distance[destinationVertex] = newDistance;
                }

            // Step 3: detect negative cycle
            // if the distance value of the destination is less than the source distance value,
            // then we have a negative cycle in the graph so we cannot find the shortest distances!
            for (int j = 0; j < amountEdges; ++j)
            {
                var edge = Edges[j];
                int sourceVertex = edge.SourceVertex;
                int destinationVertex = edge.DestinationVertex;
                int weight = edge.Weight;

                var sourceVertexDistance = distance[sourceVertex];
                var destinationVertexDistance = distance[destinationVertex];
                var newDistance = sourceVertexDistance + weight;

                if (sourceVertexDistance != int.MaxValue && newDistance < destinationVertexDistance)
                {
                    Console.WriteLine("This Graph contains negative Weight cycle");
                    return;
                }
            }

            // No negative Weight cycle found!
            // Print the distance and predecessor array
            PrintSolution(distance);
        }

        private void PrintSolution(int[] dist)
        {
            Console.WriteLine("Vertex Distance from Source");
            for (int i = 0; i < AmountOfVertices; ++i)
                Console.WriteLine(i + "\t\t" + dist[i]);
        }
    };
}