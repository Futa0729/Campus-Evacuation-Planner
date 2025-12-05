public class Graph
{
    public static Dictionary<string, List<(string neighbor, int weight)>> CreateGraph()
    {
        return new Dictionary<string, List<(string neighbor, int weight)>>()
        {
            // -------- First Floor --------
            ["A"] = new List<(string, int)>
            {
                ("B", 4),
                ("Exit1", 0),
                ("AA", 8),
            },

            ["B"] = new List<(string, int)>
            {
                ("A", 4),
                ("C", 4),
            },

            ["C"] = new List<(string, int)>
            {
                ("B", 4),
                ("D", 3),
                ("Exit2", 1),
            },

            ["D"] = new List<(string, int)>
            {
                ("C", 3),
                ("E", 3),
                ("Exit3", 2),
            },

            ["E"] = new List<(string, int)>
            {
                ("D", 3),
                ("F", 6),
                ("Exit4", 2),
                ("DD", 6),
            },

            ["F"] = new List<(string, int)>
            {
                ("E", 6),
                ("G", 2),
            },

            ["G"] = new List<(string, int)>
            {
                ("F", 2),
                ("H", 4),
            },

            ["H"] = new List<(string, int)>
            {
                ("G", 4),
                ("I", 3),
            },

            ["I"] = new List<(string, int)>
            {
                ("H", 3),
                ("Exit5", 0),
                ("GG", 8),
            },

            

            ["Exit1"] = new List<(string, int)>
            {
                ("A", 0),
            },

            ["Exit2"] = new List<(string, int)>
            {
                ("C", 1),
            },

            ["Exit3"] = new List<(string, int)>
            {
                ("D", 2),
            },

            ["Exit4"] = new List<(string, int)>
            {
                ("E", 2),
            },

            ["Exit5"] = new List<(string, int)>
            {
                ("I", 0),
            },


            // -------- Second Floor --------
            ["AA"] = new List<(string, int)>
            {
                ("BB", 6),
                ("A", 8),
                ("AAA", 8),
            },

            ["BB"] = new List<(string, int)>
            {
                ("AA", 6),
                ("CC", 2),
            },

            ["CC"] = new List<(string, int)>
            {
                ("BB", 2),
                ("DD", 6),
            },

            ["DD"] = new List<(string, int)>
            {
                ("CC", 6),
                ("EE", 8),
                ("E", 6),
                ("CCC", 6),
            },

            ["EE"] = new List<(string, int)>
            {
                ("DD", 8),
                ("FF", 3),
            },

            ["FF"] = new List<(string, int)>
            {
                ("EE", 3),
                ("GG", 2),
            },

            ["GG"] = new List<(string, int)>
            {
                ("FF", 2),
                ("I", 8),
                ("GGG", 8),
            },


            // -------- Third Floor --------
            ["AAA"] = new List<(string, int)>
            {
                ("BBB", 6),
                ("AA", 8),
            },

            ["BBB"] = new List<(string, int)>
            {
                ("AAA", 6),
                ("CCC", 8),
            },

            ["CCC"] = new List<(string, int)>
            {
                ("BBB", 8),
                ("DDD", 4),
                ("DD", 6),
            },

            ["DDD"] = new List<(string, int)>
            {
                ("CCC", 4),
                ("EEE", 4),
            },

            ["EEE"] = new List<(string, int)>
            {
                ("DDD", 4),
                ("FFF", 2),
            },

            ["FFF"] = new List<(string, int)>
            {
                ("EEE", 2),
                ("GGG", 3),
            },

            ["GGG"] = new List<(string, int)>
            {
                ("FFF", 3),
                ("GG", 8),
            },
        };
    }
}
