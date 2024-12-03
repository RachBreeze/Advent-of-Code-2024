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
    public void TotalMultiplications_ValidMemory_ReturnsCorrectTotal()
    {
        var instructions = new Instructions();
        var memory = new StringCollection { "mul(2,3)", "mul(4,5)" };
        var result = instructions.TotalMultiplications(memory);
        Assert.AreEqual(26, result);
    }

    [Test]
    public void LineTotal_LineIsNullOrEmpty_ThrowsArgumentException()
    {
        var instructions = new Instructions();
        Assert.Throws<ArgumentException>(() => instructions.LineTotal(null));
        Assert.Throws<ArgumentException>(() => instructions.LineTotal(string.Empty));
    }

    [Test]
    public void LineTotal_ValidLine_ReturnsCorrectTotal()
    {
        var instructions = new Instructions();
        var result = instructions.LineTotal("mul(2,3) mul(4,5)");
        Assert.AreEqual(26, result);
    }

    [Test]
    public void PatternTotal_InstructionIsNullOrEmpty_ReturnsZero()
    {
        var instructions = new Instructions();
        var result = instructions.PatternTotal(null);
        Assert.AreEqual(0, result);

        result = instructions.PatternTotal(string.Empty);
        Assert.AreEqual(0, result);
    }

    [Test]
    public void PatternTotal_ValidInstruction_ReturnsCorrectTotal()
    {
        var instructions = new Instructions();
        var result = instructions.PatternTotal("mul(2,3)");
        Assert.AreEqual(6, result);
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
