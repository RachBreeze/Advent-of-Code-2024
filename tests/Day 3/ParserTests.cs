namespace Day3.Tests;

[TestFixture]
public class ParserTests
{

    [Test]
    public void TotalMultiplications_ValidMemory_ReturnsCorrectTotal()
    {
        // Arrange
        var instructions = new Parser();
        string memory = "mul(2,3) mul(4,5)";

        // Act
        int result = instructions.Part1(memory);

        // Assert
        Assert.AreEqual(26, result);
    }

    [Test]
    public void TotalMultiplications_NullOrEmptyMemory_ThrowsArgumentNullException()
    {
        // Arrange
        var instructions = new Parser();
        string memory = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => instructions.Part1(memory));
    }

    [Test]
    public void Part2_ValidMemory_ReturnsCorrectTotal()
    {
        // Arrange
        var instructions = new Parser();
        string memory = "do()mul(2,3)don't()mul(4,5)";

        // Act
        int result = instructions.Part2(memory);

        // Assert
        Assert.AreEqual(6, result);
    }

    [Test]
    public void Part2_NullMemory_ThrowsArgumentNullException()
    {
        // Arrange
        var instructions = new Parser();
        string memory = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => instructions.Part2(memory));
    }

    [Test]
    public void PatternTotal_ValidInstruction_ReturnsCorrectTotal()
    {
        // Arrange
        var instructions = new Parser();
        string instruction = "mul(2,3)";

        // Act
        int result = instructions.PatternTotal(instruction);

        // Assert
        Assert.AreEqual(6, result);
    }

    [Test]
    public void PatternTotal_InvalidInstruction_ReturnsZero()
    {
        // Arrange
        var instructions = new Parser();
        string instruction = "mul(a,b)";

        // Act
        int result = instructions.PatternTotal(instruction);

        // Assert
        Assert.AreEqual(0, result);
    }

    [Test]
    public void GetValidEntries_ValidLine_ReturnsCorrectEntries()
    {
        // Arrange
        var instructions = new Parser();
        string line = "do()mul(2,3)don't()mul(4,5)";

        // Act
        string result = instructions.GetValidEntries(line);

        // Assert
        Assert.AreEqual("mul(2,3)", result);
    }

    [Test]
    //https://adventofcode.com/2024/day/3
    public void TotalMultiplications_WithSample()
    {
        var instructions = new Parser();
        var result = instructions.Part1("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))");
        Assert.AreEqual(result, 161);
    }
    [Test]
    //https://adventofcode.com/2024/day/3#part2
    public void Part2_WithSample()
    {
        var instructions = new Parser();
        var result = instructions.Part2("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");
        Assert.AreEqual(48, result);
    }

    [Test]
    // hack to avoid repeat failures
    // wouldn't write this normally :-)
    public void TestFailedAnswers()
    {
        var instructions = new Parser();
        var input = File.ReadAllText("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay3.txt");
        var total = instructions.Part2(input);
        Assert.AreNotEqual(102631226, total);
    }

}
