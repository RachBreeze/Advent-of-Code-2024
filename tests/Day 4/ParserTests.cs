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

    [Test]
    public void ConvertoGrid_ValidInput_ReturnsCorrectGrid()
    {
        // Arrange
        var parser = new Parser();
        var wordSearch = new StringCollection { "xmas", "test", "grid" };

        // Act
        var result = parser.ConvertoGrid(wordSearch);

        // Assert
        Assert.AreEqual(3, result.Count);
        Assert.AreEqual(new char[] { 'x', 'm', 'a', 's' }, result[0]);
        Assert.AreEqual(new char[] { 't', 'e', 's', 't' }, result[1]);
        Assert.AreEqual(new char[] { 'g', 'r', 'i', 'd' }, result[2]);
    }

    [Test]
    public void ConvertoGrid_EmptyInput_ReturnsEmptyGrid()
    {
        // Arrange
        var parser = new Parser();
        var wordSearch = new StringCollection();

        // Act
        var result = parser.ConvertoGrid(wordSearch);

        // Assert
        Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void ConvertoGrid_NullInput_ThrowsArgumentNullException()
    {
        // Arrange
        var parser = new Parser();
        StringCollection wordSearch = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => parser.ConvertoGrid(wordSearch));
    }

    [Test]
    public void ConvertColumnsToRows_ValidGrid_ReturnsCorrectRows()
    {
        // Arrange
        var parser = new Parser();
        var grid = new Dictionary<int, char[]>
            {
                { 0, new char[] { 'a', 'b', 'c' } },
                { 1, new char[] { 'd', 'e', 'f' } },
                { 2, new char[] { 'g', 'h', 'i' } }
            };

        var expected = new StringCollection { "adg", "beh", "cfi" };

        // Act
        var result = parser.ConvertColumnsToRows(grid);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void ConvertColumnsToRows_EmptyGrid_ReturnsEmptyStringCollection()
    {
        // Arrange
        var parser = new Parser();
        var grid = new Dictionary<int, char[]>();

        var expected = new StringCollection();

        // Act
        var result = parser.ConvertColumnsToRows(grid);

        // Assert
        Assert.AreEqual(expected, result);
    }

    [Test]
    public void ConvertColumnsToRows_NullGrid_ThrowsArgumentNullException()
    {
        // Arrange
        var parser = new Parser();
        Dictionary<int, char[]> grid = null;

        // Act & Assert
        Assert.Throws<ArgumentNullException>(() => parser.ConvertColumnsToRows(grid));
    }

    [Test]
    public void CalculateTotaleXmasByColumn_ValidGrid_ReturnsCorrectTotal()
    {
        var parser = new Parser();
        var grid = new Dictionary<int, char[]>
            {
                { 0, new char[] { 'x', 'm', 'a', 's', 'x', 's' } },
                { 1, new char[] { 's', 'a', 'm', 'x', 'm', 'a' } },
                { 2, new char[] { 'a', 'x', 's', 'm', 'a', 'm' } },
                { 3, new char[] { 'm', 's', 'x', 'a', 's', 'x' } }
            };

        var result = parser.CalculateTotaleXmasByColumn(grid);

        Assert.AreEqual(2, result);
    }

    [Test]
    public void CalculateTotaleXmasByColumn_EmptyGrid_ReturnsZero()
    {
        var grid = new Dictionary<int, char[]>();
        var parser = new Parser();
        var result = parser.CalculateTotaleXmasByColumn(grid);

        Assert.AreEqual(0, result);
    }

    [Test]
    public void CalculateTotaleXmasByColumn_NullGrid_ThrowsArgumentNullException()
    {
        var parser = new Parser();
        Assert.Throws<ArgumentNullException>(() => parser.CalculateTotaleXmasByColumn(null));
    }
}
