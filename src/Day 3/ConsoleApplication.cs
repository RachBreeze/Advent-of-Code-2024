namespace Day3;

internal sealed class ConsoleApplication
{

    private readonly IParser _parser;
    public ConsoleApplication(IParser parser)
    {
        _parser = parser;
    }
    public void Run()
    {
        var input = File.ReadAllText("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay3.txt");

        var total = _parser.Part1(input);
        Console.WriteLine("Total Multiplications: " + total); //168539636 

        var newTotal = _parser.Part2(input);
        Console.WriteLine("Total Total With Conditional: " + newTotal); //97529391

        //not 102631226
    }
}
