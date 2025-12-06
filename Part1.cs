using System;
using System.Collections.Generic;

public static class Part1
{
    public static List<PathResult> Run()
    {
        Dictionary<string, List<(string neighbor, int weight)>> graph = Graph.CreateGraph();
        Dictionary<string, string> roomStartNode = BuildingData.GetRoomStartNodes();
        HashSet<string> exits = BuildingData.GetExits();

        // Dijkstra
        Dijkstra dijkstra = new Dijkstra(graph);
        List<PathResult> results = new List<PathResult>();

        int totalTime = 0;

        foreach (var (roomNumber, startNode) in roomStartNode)
        {
            // Find shortest path to any exit
            PathResult result = dijkstra.ShortestPathToAnyExit(roomNumber, startNode, exits);

            results.Add(result);
            totalTime += result.TotalWeight;

            Console.WriteLine($"Room {roomNumber} starting at {result.StartNode}:");
            Console.WriteLine($"Exit: {result.ExitNode}");
            Console.WriteLine($"Total Weight: {result.TotalWeight}");
            Console.WriteLine($"Path: {string.Join(" -> ", result.PathNodes)}");
            Console.WriteLine();
        }
        
        Console.WriteLine($"Total time in all rooms: {totalTime}");

        return results;

    }
}