using FileParse;

namespace Day4;

internal sealed class ConsoleApplication
{
    private readonly IReadFileContents _readFileContents;
    private readonly IParser _parser;
    public ConsoleApplication(IReadFileContents readFileContents, IParser parser)
    {
        _readFileContents = readFileContents;
        _parser = parser;
    }
    public void Run()
    {
        var input = _readFileContents.AsLines("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay4.txt");

        var total = _parser.Part1(input);
        Console.WriteLine("Part 1: " + total); //2569 

        total = _parser.Part2(input);
        Console.WriteLine("Part 2: " + total); //1998

    }
}
