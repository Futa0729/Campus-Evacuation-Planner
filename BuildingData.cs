using System.Collections.Generic;

public static class BuildingData
{
    public static Dictionary<string, string> GetRoomStartNodes()
    {
        return new Dictionary<string, string>
        {
            // -------- First Floor --------
            ["122"] = "B",
            ["123"] = "B",
            ["124"] = "B",
            ["142"] = "H",
            ["143"] = "G",
            ["151"] = "H",
            ["154"] = "F",

            // -------- Second Floor --------
            ["223"] = "BB",
            ["225"] = "CC",
            ["243"] = "EE",
            ["251"] = "FF",
            ["254"] = "EE",

            // -------- Third Floor --------
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
}