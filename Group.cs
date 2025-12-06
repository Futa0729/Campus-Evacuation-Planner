using System.Collections.Generic;

public class Group
{
    public string RoomNumber { get; set; } = "";
    public string ExitNode { get; set; } = "";
    public int Students { get; set; }
    public int PathWeight { get; set; }
    public List<string> PathNodes { get; set; } = new List<string>();
    public double PenaltySum { get; set; }
    public double AdjustedTime { get; set; }
}
