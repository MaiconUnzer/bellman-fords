// See https://aka.ms/new-console-template for more information
using BellmanFords;

var graph = new Graph();


#region Graph with NO negative cycle

graph.AddEdge(0, 1, 5);
graph.AddEdge(0, 2, 4);
graph.AddEdge(1, 3, 3);
graph.AddEdge(2, 1, 6);
graph.AddEdge(3, 2, 2);

graph.BellmanFord(0);

#endregion

Console.WriteLine("\n\n");

#region Graph WITH negative cycle. Referencia: https://www.programiz.com/dsa/bellman-ford-algorithm#negative-weights

graph.AddEdge(0, 1, 2);
graph.AddEdge(1, 3, 1);
graph.AddEdge(1, 2, 2);
graph.AddEdge(2, 3, -4);
graph.AddEdge(3, 1, 1);
graph.AddEdge(3, 4, 3);

graph.BellmanFord(0);
#endregion