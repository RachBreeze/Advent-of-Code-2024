using System.Collections.Specialized;
namespace Day4.Tests;

[TestFixture]
internal class ParserTests
{
    [Test]
    public void Part1_NullInput_ThrowsArgumentNullException()
    {
        var parser = new Parser();
        Assert.Throws<ArgumentNullException>(() => parser.Part1(null));
    }

    [Test]
    public void Part1_ValidInput_ReturnsCorrectTotal()
    {
        var parser = new Parser();
        var wordSearch = new StringCollection { "xmas", "xmas tree", "merry xmas", "happy holidays", "eert samx", "yrrem samx", "samxxmas" };
        var result = parser.Part1(wordSearch);
        Assert.AreEqual(7, result);
    }

    [Test]
    public void CalculateNumberOfXmas_ValidInput_ReturnsCorrectCount()
    {
        var parser = new Parser();
        var result = parser.CalculateNumberOfXmas("xmas xmas tree");
        Assert.AreEqual(2, result);
    }

    [Test]
    public void Reverse_ValidInput_ReturnsReversedString()
    {
        var parser = new Parser();
        var result = parser.Reverse("xmas");
        Assert.AreEqual("samx", result);
    }
}
