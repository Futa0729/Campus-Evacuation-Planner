public class Dijkstra
{
    private readonly Dictionary<string, List<(string neighbor, int weight)>> _graph;

    public Dijkstra(Dictionary<string, List<(string neighbor, int weight)>> graph)
    {
        _graph = graph;
    }

    public PathResult ShortestPathToAnyExit(string RoomNumber, string startNode, HashSet<string> exitNodes)
    {
        Dictionary<string, int> distances = new Dictionary<string, int>();
        Dictionary<string, string> previousNodes = new Dictionary<string, string>();
        HashSet<string> unvisited = new HashSet<string>(_graph.Keys);

        // set all nodes infinite distance, meaning it hasn't reached yet
        foreach (var node in _graph.Keys)
        {
            distances[node] = int.MaxValue;
            previousNodes[node] = null;
        }
        //start node is 0
        distances[startNode] = 0;

        // Dijkstra
        while (unvisited.Count > 0)
        {
            // get smallest node
            string currentNode = null;
            int smallest = int.MaxValue;

            // look for the cloest node
            foreach (var node in unvisited)
            {
                if (distances[node] < smallest)
                {
                    smallest = distances[node];
                    currentNode = node;
                }
            }
            // if can't find any node -> break
            if (currentNode == null)
            {
                break;
            }
            unvisited.Remove(currentNode);

            // update neighbor connected to node above
            foreach (var nextNode in _graph[currentNode])
            {
                string neighbor = nextNode.neighbor;
                int weight = nextNode.weight;

                // new distance
                int newDistance = distances[currentNode] + weight;
                // if the new distance is smaller -> update
                if (newDistance < distances[neighbor])
                {
                    distances[neighbor] = newDistance;
                    previousNodes[neighbor] = currentNode;
                }
            }
        }
        // ↑now shortest distances (start -> exit)

        // closest exit
        string bestExit = null;
        int bestDistance = int.MaxValue;

        foreach (var exit in exitNodes)
        {
            int distance = distances[exit];

            if (distance < bestDistance)
            {
                bestDistance = distance;
                bestExit = exit;
            }
        }

        // build path: exit -> start
        List<string> path = new List<string>();
        string current = bestExit;

        while (current != null)
        {
            path.Add(current);
            if (current == startNode)
            {
                break;
            }

            current = previousNodes[current];
        }
        path.Reverse(); // now path is: start -> exit

        return new PathResult
        {
            RoomNumber = RoomNumber,
            StartNode = startNode,
            ExitNode = bestExit,
            TotalWeight = bestDistance,
            PathNodes = path
        };
    }
}