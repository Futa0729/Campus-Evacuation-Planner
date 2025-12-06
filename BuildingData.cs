using System.Collections.Generic;

public static class BuildingData
{
    //Room -> Start Node
    public static Dictionary<string, string> GetRoomStartNodes()
    {
        return new Dictionary<string, string>
        {
            //-------- First Floor --------
            ["122"] = "B",
            ["123"] = "B",
            ["124"] = "B",
            ["142"] = "H",
            ["143"] = "G",
            ["151"] = "H",
            ["154"] = "F",

            //-------- Second Floor --------
            ["223"] = "BB",
            ["225"] = "CC",
            ["243"] = "EE",
            ["251"] = "FF",
            ["254"] = "EE",

            //-------- Third Floor --------
            ["323"] = "BBB",
            ["324"] = "BBB",
            ["341"] = "FFF",
            ["342"] = "FFF",
            ["343"] = "EEE",
            ["351"] = "FFF",
            ["353"] = "EEE",
            ["354"] = "DDD",
        };
    }

    //Set of all exit nodes
    public static HashSet<string> GetExits()
    {
        return new HashSet<string>
        {
            "Exit1",
            "Exit2",
            "Exit3",
            "Exit4",
            "Exit5"
        };
    }

    //Students per room(Part 2)
    public static int GetStudentsPerRoom()
    {
        return 30;
    }

    //nodes to stairwell type
    public static Dictionary<string, string> GetStairForNode()
    {
        return new Dictionary<string, string>
        {
            ["AA"] = "Side stairwells",
            ["GG"] = "Side stairwells",
            ["DD"] = "Center stairwell",
        };
    }

    //Capacity for all choke points (stairs + exits)
    public static Dictionary<string, int> GetCapacities()
    {
        return new Dictionary<string, int>
        {
            //Stairwells
            ["Side stairwells"] = 100,
            ["Center stairwell"] = 200,

            //Exits
            ["Exit1"] = 300,
            ["Exit2"] = 300,
            ["Exit3"] = 300,
            ["Exit4"] = 300,
            ["Exit5"] = 300,
        };
    }

    public static Dictionary<string, int> GetStudentForPart3()
    {
        return new Dictionary<string, int>
        {
            ["122"] = 30,
            ["123"] = 30,
            ["124"] = 30,
            ["142"] = 30,
            ["143"] = 30,
            ["151"] = 30,
            ["154"] = 30,
            ["223"] = 30,
            ["225"] = 30,
            ["243"] = 30,
            ["251"] = 30,
            ["254"] = 30,
            ["323"] = 30,
            ["324"] = 30,
            ["341"] = 30,
            ["342"] = 30,
            ["343"] = 30,
            ["351"] = 30,
            ["353"] = 30,
            ["354"] = 30,
        };
    }

}
