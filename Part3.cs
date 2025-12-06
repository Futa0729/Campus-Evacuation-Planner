using System;
using System.Collections.Generic;

public static class Part3
{
    public static void Run(List<PathResult> pathResults)
    {
        Dictionary<string, List<(string neighbor, int weight)>> graph = Graph.CreateGraph();

        int studentsPerRoom = BuildingData.GetStudentsPerRoom();
        Dictionary<string, string> roomStartNodes = BuildingData.GetRoomStartNodes();
        Dictionary<string, string> stairForNode = BuildingData.GetStairForNode();
        Dictionary<string, int> capacities = BuildingData.GetCapacities();

        //store groups after spliting
        List<Group> groups = new List<Group>();
        HashSet<string> splitRooms = new HashSet<string>
        {
            "243", "251", "254",
            "341", "342", "343", "351", "353"
        };

        Dijkstra dijkstra = new Dijkstra(graph);

        foreach (PathResult baseResult in pathResults)
        {
            string room = baseResult.RoomNumber;

            // not splitting the group
            if (!splitRooms.Contains(room))
            {
                Group group = new Group
                {
                    RoomNumber = room,
                    ExitNode = baseResult.ExitNode,
                    Students = studentsPerRoom,
                    PathWeight = baseResult.TotalWeight,
                    PathNodes = new List<string>(baseResult.PathNodes)
                };
                groups.Add(group);
                continue;
            }
            // splitting the group into A and B
            else
            {
                int groupAStudents = studentsPerRoom / 2; //15
                int groupBStudents = studentsPerRoom - groupAStudents; //15

                //Group A uses the original path
                Group groupA = new Group
                {
                    RoomNumber = room,
                    ExitNode = baseResult.ExitNode,
                    Students = groupAStudents,
                    PathWeight = baseResult.TotalWeight,
                    PathNodes = new List<string>(baseResult.PathNodes)
                };
                groups.Add(groupA);

                //Group B uses Center stairwell to Exit4
                string startNode = baseResult.StartNode;

                if (roomStartNodes.ContainsKey(room))
                {
                    startNode = roomStartNodes[room];
                }

                HashSet<string> exit4Only = new HashSet<string> { "Exit4" };
                PathResult otherPath = dijkstra.ShortestPathToAnyExit(room, startNode, exit4Only);


                Group groupB = new Group
                {
                    RoomNumber = room,
                    ExitNode = otherPath.ExitNode,
                    Students = groupBStudents,
                    PathWeight = otherPath.TotalWeight,
                    PathNodes = new List<string>(otherPath.PathNodes)
                };
                groups.Add(groupB);
            }
        }

        // how many students per choke point
        Dictionary<string, int> chokeUsers = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> pair in capacities)
        {
            chokeUsers[pair.Key] = 0;
        }

        foreach (Group g in groups)
        {
            bool usesSide = false;
            bool usesCenter = false;

            //check which stairwells are used in the path
            foreach (var node in g.PathNodes)
            {
                if (stairForNode.TryGetValue(node, out string stairName))
                {
                    if (stairName == "Side stairwells")
                    {
                        usesSide = true; //just record side stairwell is used
                    }
                    else if (stairName == "Center stairwell")
                    {
                        usesCenter = true; //just record center stairwell is used
                    }
                }
            }
            if (usesSide)
            {
                chokeUsers["Side stairwells"] += g.Students;
            }
            if (usesCenter)
            {
                chokeUsers["Center stairwell"] += g.Students;
            }

            //each room uses exactly one exit
            chokeUsers[g.ExitNode] += g.Students;

        }
        Console.WriteLine("Students per choke point (after splitting)");
        foreach (var choke in chokeUsers)
        {
            Console.WriteLine($"{choke.Key}: {choke.Value} students");
        }
        Console.WriteLine();


        // compute penalty for each choke point (stairwell or exit)
        Dictionary<string, double> chokePenalty = new Dictionary<string, double>();

        foreach (var choke in chokeUsers)
        {
            int cap = capacities[choke.Key];

            double penalty;
            if (choke.Value <= cap)
            {
                penalty = 0;
            }
            else
            {
                penalty = (choke.Value - cap) / (double)cap;
            }

            chokePenalty[choke.Key] = penalty;
        }
        Console.WriteLine("Penalties per choke point (after splitting)");
        foreach (var choke in chokePenalty)
        {
            Console.WriteLine($"{choke.Key}: Penalty = {choke.Value}");
        }
        Console.WriteLine();

        // compute total penalty
        Console.WriteLine("Room results with congestion (after splitting)");
        

        foreach (Group g in groups)
        {
            bool usesSide = false;
            bool usesCenter = false;

            //same as above: check which stairwells are used in the path
            foreach (var node in g.PathNodes)
            {
                if (stairForNode.TryGetValue(node, out string stairName))
                {
                    if (stairName == "Side stairwells")
                    {
                        usesSide = true;
                    }
                    else if (stairName == "Center stairwell")
                    {
                        usesCenter = true;
                    }
                }
            }
            double totalPenalty = 0;

            if (usesSide)
            {
                totalPenalty += chokePenalty["Side stairwells"];
            }
            if (usesCenter)
            {
                totalPenalty += chokePenalty["Center stairwell"];
            }
            totalPenalty += chokePenalty[g.ExitNode];

            double adjustedTime = g.PathWeight * (1.0 + totalPenalty);

            Console.WriteLine("Room: " + g.RoomNumber);
            Console.WriteLine("Exit: " + g.ExitNode);
            Console.WriteLine("PathWeight: " + g.PathWeight);
            Console.WriteLine("PenaltySum: " + totalPenalty);
            Console.WriteLine("AdjustedTime: " + adjustedTime);
            Console.WriteLine();
        }
    }
}