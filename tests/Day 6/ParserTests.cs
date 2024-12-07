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
    public void GetNextPosition_Up_AtEdge()
    {
        var parser = new Parser();
        var table = new string[,] { { ">", "v" }, { "^", "#" } };
        int row = 0, column = 1;
        var direction = Parser.Direction.Up;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPosition_Down_AtEdge()
    {
        var parser = new Parser();
        var table = new string[,] { { ">", "v" }, { "^", "#" } };
        int row = 1, column = 1;
        var direction = Parser.Direction.Down;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPosition_Left_AtEdge()
    {
        var parser = new Parser();
        var table = new string[,] { { ">", "v" }, { "^", "#" } };
        int row = 1, column = 0;
        var direction = Parser.Direction.Left;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPosition_Right_AtEdge()
    {
        var parser = new Parser();
        var table = new string[,] { { ">", "v" }, { "^", "#" } };
        int row = 0, column = 1;
        var direction = Parser.Direction.Right;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPosition_Up_NotAtEdge()
    {
        var parser = new Parser();
        var table = new string[,] { { ">", "v" }, { "^", "#" } };
        int row = 1, column = 1;
        var direction = Parser.Direction.Up;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsFalse(atEdge);
        Assert.AreEqual(0, row);
        Assert.AreEqual(1, column);
    }

    [Test]
    public void GetNextPosition_Down_NotAtEdge()
    {
        var parser = new Parser();
        var table = new string[,] { { ">", "v" }, { "^", "#" } };
        int row = 0, column = 0;
        var direction = Parser.Direction.Down;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsFalse(atEdge);
        Assert.AreEqual(1, row);
        Assert.AreEqual(0, column);
    }

    [Test]
    public void GetNextPosition_Left_NotAtEdge()
    {
        var parser = new Parser();
        var table = new string[,] { { ">", "v" }, { "^", "#" } };
        int row = 1, column = 1;
        var direction = Parser.Direction.Left;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsFalse(atEdge);
        Assert.AreEqual(1, row);
        Assert.AreEqual(0, column);
    }

    [Test]
    public void GetNextPosition_Right_NotAtEdge()
    {
        var parser = new Parser();
        var table = new string[,] { { ">", "v" }, { "^", "#" } };
        int row = 0, column = 0;
        var direction = Parser.Direction.Right;
        bool atEdge = false;

        parser.GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsFalse(atEdge);
        Assert.AreEqual(0, row);
        Assert.AreEqual(1, column);
    }
    [Test]
    public void GetNextPositionRight_AtEdge_SetsAtEdgeToTrue()
    {
        var parser = new Parser();
        var table = new string[,] { { ".", ".", "." }, { ".", ".", "." }, { ".", ".", "." } };
        int row = 0, column = 2;
        var direction = Parser.Direction.Right;
        bool atEdge = false;

        parser.GetNextPositionRight(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPositionRight_EncounterHash_ChangesDirectionToDown()
    {
        var parser = new Parser();
        var table = new string[,] { { ".", ".", "." }, { ".", ".", "#" }, { ".", ".", "." } };
        int row = 1, column = 1;
        var direction = Parser.Direction.Right;
        bool atEdge = false;

        parser.GetNextPositionRight(table, ref row, ref column, ref direction, ref atEdge);

        Assert.AreEqual(Parser.Direction.Down, direction);
    }

    [Test]
    public void GetNextPositionLeft_AtEdge_SetsAtEdgeToTrue()
    {
        var parser = new Parser();
        var table = new string[,] { { ".", ".", "." }, { ".", ".", "." }, { ".", ".", "." } };
        int row = 0, column = 0;
        var direction = Parser.Direction.Left;
        bool atEdge = false;

        parser.GetNextPositionLeft(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPositionLeft_EncounterHash_ChangesDirectionToUp()
    {
        var parser = new Parser();
        var table = new string[,] { { ".", ".", "." }, { ".", "#", "." }, { ".", ".", "." } };
        int row = 1, column = 2;
        var direction = Parser.Direction.Left;
        bool atEdge = false;

        parser.GetNextPositionLeft(table, ref row, ref column, ref direction, ref atEdge);

        Assert.AreEqual(Parser.Direction.Up, direction);
    }

    [Test]
    public void GetNextPositionDown_AtEdge_SetsAtEdgeToTrue()
    {
        var parser = new Parser();
        var table = new string[,] { { ".", ".", "." }, { ".", ".", "." }, { ".", ".", "." } };
        int row = 2, column = 0;
        var direction = Parser.Direction.Down;
        bool atEdge = false;

        parser.GetNextPositionDown(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPositionDown_EncounterHash_ChangesDirectionToLeft()
    {
        var parser = new Parser();
        var table = new string[,] { { ".", ".", "." }, { ".", ".", "." }, { ".", "#", "." } };
        int row = 1, column = 1;
        var direction = Parser.Direction.Down;
        bool atEdge = false;

        parser.GetNextPositionDown(table, ref row, ref column, ref direction, ref atEdge);

        Assert.AreEqual(Parser.Direction.Left, direction);
    }

    [Test]
    public void GetNextPositionUp_AtEdge_SetsAtEdgeToTrue()
    {
        var parser = new Parser();
        var table = new string[,] { { ".", ".", "." }, { ".", ".", "." }, { ".", ".", "." } };
        int row = 0, column = 0;
        var direction = Parser.Direction.Up;
        bool atEdge = false;

        parser.GetNextPositionUp(table, ref row, ref column, ref direction, ref atEdge);

        Assert.IsTrue(atEdge);
    }

    [Test]
    public void GetNextPositionUp_EncounterHash_ChangesDirectionToRight()
    {
        var parser = new Parser();
        var table = new string[,] { { ".", "#", "." }, { ".", ".", "." }, { ".", ".", "." } };
        int row = 1, column = 1;
        var direction = Parser.Direction.Up;
        bool atEdge = false;

        parser.GetNextPositionUp(table, ref row, ref column, ref direction, ref atEdge);

        Assert.AreEqual(Parser.Direction.Right, direction);
    }

    [Test]
    public void GetDirection_ValidInput_ReturnsCorrectDirection()
    {
        var parser = new Parser();
        Assert.AreEqual(Parser.Direction.Up, parser.GetDirection("^"));
        Assert.AreEqual(Parser.Direction.Down, parser.GetDirection("v"));
        Assert.AreEqual(Parser.Direction.Left, parser.GetDirection("<"));
        Assert.AreEqual(Parser.Direction.Right, parser.GetDirection(">"));
    }

    [Test]
    public void GetDirection_InvalidInput_ReturnsUnknownDirection()
    {
        var parser = new Parser();
        Assert.AreEqual(Parser.Direction.Unknown, parser.GetDirection("x"));
    }
}