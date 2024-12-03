using System.Collections.Specialized;
namespace Day3.Tests;

[TestFixture]
public class InstructionsTests
{

    [Test]
    public void TotalMultiplications_MemoryIsNull_ThrowsArgumentNullException()
    {
        var instructions = new Instructions();
        Assert.Throws<ArgumentNullException>(() => instructions.TotalMultiplications(null));
    }

    [Test]
    public void TotalMultiplications_MemoryIsEmpty_ThrowsArgumentException()
    {
        var instructions = new Instructions();
        var memory = new StringCollection();
        Assert.Throws<ArgumentException>(() => instructions.TotalMultiplications(memory));
    }

    [Test]
    public void TotalMultiplications_NoInstructionsFound_ThrowsInvalidOperationException()
    {
        var instructions = new Instructions();
        var memory = new StringCollection { "invalid data" };
        Assert.Throws<InvalidOperationException>(() => instructions.TotalMultiplications(memory));
    }

    [Test]
    public void TotalMultiplications_ValidInstructions_ReturnsCorrectTotal()
    {
        var instructions = new Instructions();
        var memory = new StringCollection { "mul(2,3)", "mul(4,5)" };
        var result = instructions.TotalMultiplications(memory);
        Assert.AreEqual(26, result);
    }

    [Test]
    public void ReadInstructions_ValidMemory_ReturnsCorrectInstructions()
    {
        var instructions = new Instructions();
        var memory = new StringCollection { "mul(2,3)", "mul(4,5)" };
        var result = instructions.ReadInstructions(memory);
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(i => i.Key == 2 && i.Value == 3));
        Assert.IsTrue(result.Any(i => i.Key == 4 && i.Value == 5));
    }

    [Test]
    public void ReadInstructionsForLine_ValidLine_ReturnsCorrectInstructions()
    {
        var instructions = new Instructions();
        var line = "mul(2,3)mul(4,5)";
        var result = instructions.ReadInstructionsForLine(line);
        Assert.AreEqual(2, result.Count());
        Assert.IsTrue(result.Any(i => i.Key == 2 && i.Value == 3));
        Assert.IsTrue(result.Any(i => i.Key == 4 && i.Value == 5));
    }

    [Test]
    public void ReadInstruction_ValidInstruction_ReturnsCorrectInstruction()
    {
        var instructions = new Instructions();
        var instruction = "2,3)";
        var result = instructions.ReadInstruction(instruction);
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Key);
        Assert.AreEqual(3, result.Value);
    }

    [Test]
    public void ReadInstruction_InvalidInstruction_ReturnsNull()
    {
        var instructions = new Instructions();
        var instruction = "invalid";
        var result = instructions.ReadInstruction(instruction);
        Assert.IsNull(result);
    }

    [Test]
    // sample from https://adventofcode.com/2024/day/3
    public void ReadInstruction_TotalMultipications_Sample()
    {
        var instructions = new Instructions();
        var instruction = new StringCollection { "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))" };
        var result = instructions.TotalMultiplications(instruction);
        Assert.AreEqual(result, 161);
    }
}
