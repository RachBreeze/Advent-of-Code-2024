namespace Day3.Tests;

[TestFixture]
public class InstructionsTests
{

    [Test]
    public void TotalMultiplications_ValidMemory_ReturnsCorrectTotal()
    {
        // Arrange
        var instructions = new Instructions();
        string memory = "mul(2,3) mul(4,5)";

        // Act
        int result = instructions.TotalMultiplications(memory);

        // Assert
        Assert.AreEqual(26, result);
    }

    [Test]
    public void TotalMultiplications_NullOrEmptyMemory_ThrowsArgumentNullException()
    {
        // Arrange
        var instructions = new Instructions();
        string memory = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => instructions.TotalMultiplications(memory));
    }

    [Test]
    public void TotalWithConditionalStatements_ValidMemory_ReturnsCorrectTotal()
    {
        // Arrange
        var instructions = new Instructions();
        string memory = "do()mul(2,3)don't()mul(4,5)";

        // Act
        int result = instructions.TotalWithConditionalStatements(memory);

        // Assert
        Assert.AreEqual(6, result);
    }

    [Test]
    public void TotalWithConditionalStatements_NullMemory_ThrowsArgumentNullException()
    {
        // Arrange
        var instructions = new Instructions();
        string memory = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => instructions.TotalWithConditionalStatements(memory));
    }

    [Test]
    public void PatternTotal_ValidInstruction_ReturnsCorrectTotal()
    {
        // Arrange
        var instructions = new Instructions();
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
        var instructions = new Instructions();
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
        var instructions = new Instructions();
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
        var instructions = new Instructions();
        var result = instructions.TotalMultiplications("xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))");
        Assert.AreEqual(result, 161);
    }
    [Test]
    //https://adventofcode.com/2024/day/3#part2
    public void TotalWithConditionalStatements_WithSample()
    {
        var instructions = new Instructions();
        var result = instructions.TotalWithConditionalStatements("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))");
        Assert.AreEqual(48, result);
    }

    [Test]
    // hack to avoid repeat failures
    // wouldn't write this normally :-)
    public void TestFailedAnswers()
    {
        var instructions = new Instructions();
        var input = File.ReadAllText("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay3.txt");
        var total = instructions.TotalWithConditionalStatements(input);
        Assert.AreNotEqual(102631226, total);
    }

}
