using System.Collections.Specialized;

namespace Day6.Tests;
[TestFixture]
public class ParserTests
{

    [Test]
    public void Part1_InputIsNull_ThrowsArgumentNullException()
    {
        var parser = new Parser();
        Assert.Throws<ArgumentNullException>(() => parser.Part1(null));
    }

    [Test]
    public void Part1_InputIsEmpty_ReturnsZero()
    {
        var parser = new Parser();
        var input = new StringCollection();
        var result = parser.Part1(input);
        Assert.AreEqual(0, result);
    }


    [Test]
    public void Part2_InputIsNull_ReturnsZero()
    {
        var parser = new Parser();
        var result = parser.Part2(null);
        Assert.AreEqual(0, result);
    }

    [Test]
    public void Part2_ValidInput_ReturnsExpectedResult()
    {
        var parser = new Parser();
        var input = new StringCollection { "v>v", "^<^" };
        var result = parser.Part2(input);
        Assert.AreEqual(0, result); // Adjust expected result based on actual logic
    }

    [Test]
    public void GetNextPosition_UpDirection_UpdatesRow()
    {
        var parser = new Parser();
        var table = new string[,]
        {
                { " ", " ", " " },
                { " ", "^", " " },
                { " ", " ", " " }
        };
        int row = 1, column = 1;
        var direction = Parser.Direction.Up;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.AreEqual(0, row);
        Assert.AreEqual(1, column);
        Assert.AreEqual(Parser.Direction.Up, direction);
        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPosition_DownDirection_UpdatesRow()
    {
        var parser = new Parser();
        var table = new string[,]
        {
                { " ", " ", " " },
                { " ", "v", " " },
                { " ", " ", " " }
        };
        int row = 1, column = 1;
        var direction = Parser.Direction.Down;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.AreEqual(2, row);
        Assert.AreEqual(1, column);
        Assert.AreEqual(Parser.Direction.Down, direction);
        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPosition_LeftDirection_UpdatesColumn()
    {
        var parser = new Parser();
        var table = new string[,]
        {
                { " ", " ", " " },
                { " ", "<", " " },
                { " ", " ", " " }
        };
        int row = 1, column = 1;
        var direction = Parser.Direction.Left;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.AreEqual(1, row);
        Assert.AreEqual(0, column);
        Assert.AreEqual(Parser.Direction.Left, direction);
        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPosition_RightDirection_UpdatesColumn()
    {
        var parser = new Parser();
        var table = new string[,]
        {
                { " ", " ", " " },
                { " ", ">", " " },
                { " ", " ", " " }
        };
        int row = 1, column = 1;
        var direction = Parser.Direction.Right;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.AreEqual(1, row);
        Assert.AreEqual(2, column);
        Assert.AreEqual(Parser.Direction.Right, direction);
        Assert.IsTrue(atEdge);
    }
}