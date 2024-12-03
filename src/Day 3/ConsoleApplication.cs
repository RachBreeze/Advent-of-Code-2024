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
        var input = File.ReadAllText("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay3.txt");

        var total = _instructions.TotalMultiplications(input);
        Console.WriteLine("Total Multiplications: " + total); //168539636 

        var newTotal = _instructions.TotalWithConditionalStatements(input);
        Console.WriteLine("Total Total With Conditional: " + newTotal); //97529391

        //not 102631226
    }
}
