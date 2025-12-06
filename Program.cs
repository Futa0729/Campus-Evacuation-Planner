class Program
{
    static void Main()
    {
        List<PathResult> part1Results = Part1.Run();
        Part2.Run(part1Results);
        Part3.Run(part1Results);

    }
}