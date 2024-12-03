using FileParse;

namespace Day3;

internal class ConsoleApplication
{
    private readonly IReadFileContents _readFileContents;
    private readonly IInstructions _instructions;
    public ConsoleApplication(IReadFileContents readFileContents, IInstructions instructions)
    {
        _readFileContents = readFileContents;
        _instructions = instructions;
    }
    public void Run()
    {
        var memoryEntries = _readFileContents.AsLines("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay3.txt");
        Console.WriteLine("Entries Found: " + memoryEntries.Count);

        var total = _instructions.TotalMultiplications(memoryEntries);
        Console.WriteLine("Total Multiplications: " + total);
    }
}
