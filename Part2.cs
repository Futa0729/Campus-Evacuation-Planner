using System;
using System.Collections.Generic;

public static class Part2
{
    public static void Run(List<PathResult> results)
    {
        int studentsPerRoom = BuildingData.GetStudentsPerRoom();
        Dictionary<string, string> stairForNode = BuildingData.GetStairForNode();
        Dictionary<string, int> capacities = BuildingData.GetCapacities();

        Dictionary<string, int> chokeUsers = new Dictionary<string, int>();
        foreach (KeyValuePair<string, int> pair in capacities)
        {
            chokeUsers[pair.Key] = 0;
        }

        // Count students per choke points.
        foreach (var result in results)
        {
            bool usesSide = false;
            bool usesCenter = false;

            //check which stairwells are used in the path
            foreach (var node in result.PathNodes)
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
                chokeUsers["Side stairwells"] += studentsPerRoom;
            }
            if (usesCenter)
            {
                chokeUsers["Center stairwell"] += studentsPerRoom;
            }

            //each room uses exactly one exit
            chokeUsers[result.ExitNode] += studentsPerRoom;
        }

        Console.WriteLine("Students per choke point");
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

        Console.WriteLine("Penalties per choke point");
        foreach (var choke in chokePenalty)
        {
            Console.WriteLine($"{choke.Key}: {choke.Value} penalty");
        }
        Console.WriteLine();

        //compute adjusted time
        Console.WriteLine("Room results with congestion");

        foreach (var result in results)
        {
            bool usesSide = false;
            bool usesCenter = false;

            //same as above: check which stairwells are used in the path
            foreach (var node in result.PathNodes)
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
            totalPenalty += chokePenalty[result.ExitNode];

            double adjustedTime = result.TotalWeight * (1.0 + totalPenalty);

            Console.WriteLine("Room: " + result.RoomNumber);
            Console.WriteLine("Exit: " + result.ExitNode);
            Console.WriteLine("PathWeight: " + result.TotalWeight);
            Console.WriteLine("PenaltySum: " + totalPenalty);
            Console.WriteLine("AdjustedTime: " + adjustedTime);
            Console.WriteLine();
        }

    }
}