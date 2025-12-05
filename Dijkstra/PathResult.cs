public class PathResult
{
    public string RoomNumber { get; set; } = "";
    public string StartNode { get; set; } = "";
    public string ExitNode { get; set; } = "";
    public int TotalWeight { get; set; }
    public List<string> PathNodes { get; set; } = new List<string>();
}