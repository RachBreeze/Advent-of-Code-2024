using System.Collections.Specialized;

namespace Day6;

internal sealed class Parser : IParser
{
    internal enum Direction
    {
        Unknown,
        Up,
        Down,
        Left,
        Right
    }
    public int Part1(StringCollection input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        if (input.Count == 0)
        {
            return 0;
        }

        if (input.Count == 1)
        {
            return 0;
        }
        var table = ReadTable(input);

        FindStartingPosition(table, out var row, out var column, out var direction);

        if (direction == Direction.Unknown)
        {
            throw new InvalidOperationException("No starting direction found");
        }

        var positionVisited = 1;
        var atEdge = false;
        while (!atEdge)
        {

            GetNextPosition(table, ref row, ref column, ref direction, ref atEdge);
            if (!atEdge)
            {
                positionVisited++;
            }

        }
        return positionVisited;
    }

    internal protected void GetNextPosition(string[,] table, ref int row, ref int column, ref Direction direction, ref bool atEdge)
    {
        if (table == null)
        {
            throw new ArgumentNullException(nameof(table));
        }

        if (table.GetLength(0) == 0)
        {
            throw new ArgumentException("Table has no rows", nameof(table));
        }
        if (table.GetLength(1) == 0)
        {
            throw new ArgumentException("Table has no columns", nameof(table));
        }
        if (table.GetLength(0) == 1)
        {
            throw new ArgumentException("Table has only one row", nameof(table));
        }
        if (table.GetLength(1) == 1)
        {
            throw new ArgumentException("Table has only one column", nameof(table));
        }
        switch (direction)
        {
            case Direction.Unknown:
                throw new InvalidOperationException("Unknown direction");
            case Direction.Up:
                GetNextPositionUp(table, ref row, ref column, ref direction, ref atEdge);
                return;
            case Direction.Down:
                GetNextPositionDown(table, ref row, ref column, ref direction, ref atEdge);
                return;
            case Direction.Left:
                GetNextPositionLeft(table, ref row, ref column, ref direction, ref atEdge);
                return;
            case Direction.Right:
                GetNextPositionRight(table, ref row, ref column, ref direction, ref atEdge);
                return;
        }
        throw new InvalidOperationException("Unknown direction");
    }

    private void GetNextPositionRight(string[,] table, ref int row, ref int column, ref Direction direction, ref bool atEdge)
    {
        var colCount = table.GetLength(1) - 1;

        if (column == colCount)
        {
            atEdge = true;
            return;
        }
        while (column < colCount)
        {
            if (table[row, column + 1] == "#")
            {
                direction = Direction.Down;
                return;
            }
            column++;

        }

        atEdge = true;
    }

    internal protected void GetNextPositionLeft(string[,] table, ref int row, ref int column, ref Direction direction, ref bool atEdge)
    {
        if (column == 0)
        {
            atEdge = true;
            return;
        }
        while (column > 0)
        {
            if (table[row, column - 1] == "#")
            {
                direction = Direction.Up;
                return;
            }
            column--;
        }

        atEdge = true;
    }

    internal protected void GetNextPositionDown(string[,] table, ref int row, ref int column, ref Direction direction, ref bool atEdge)
    {
        var rowCount = table.GetLength(0) - 1;

        if (row == rowCount)
        {
            atEdge = true;
            return;
        }
        while (row < rowCount)
        {
            if (table[row + 1, column] == "#")
            {
                direction = Direction.Left;
                return;
            }
            row++;
        }
        atEdge = true;
    }

    internal protected void GetNextPositionUp(string[,] table, ref int row, ref int column, ref Direction direction, ref bool atEdge)
    {
        if (row == 0)
        {
            atEdge = true;
            return;
        }
        while (row > 0)
        {
            if (row == 28)
            {
                System.Diagnostics.Debugger.Break();
            }
            if (table[row - 1, column] == "#")
            {
                direction = Direction.Right;
                row++;
                return;
            }
            row--;
        }

        atEdge = true;
    }

    internal protected Direction GetDirection(string v)
    {
        switch (v)
        {
            case "^":
                return Direction.Up;
            case "v":
                return Direction.Down;
            case "<":
                return Direction.Left;
            case ">":
                return Direction.Right;
        }

        return Direction.Unknown;
    }

    internal protected void FindStartingPosition(string[,] table, out int row, out int column, out Direction direction)
    {
        row = 0;
        column = 0;
        direction = Direction.Unknown;

        for (int i = 0; i < table.GetLength(0); i++)
        {
            for (int j = 0; j < table.GetLength(1); j++)
            {
                var testDirection = GetDirection(table[i, j]);
                if (testDirection != Direction.Unknown)
                {
                    row = i;
                    column = j;
                    direction = testDirection;
                    return;
                }
            }
        }

        throw new InvalidOperationException("No starting position found");
    }

    public int Part2(StringCollection input)
    {
        return 0;
    }
    internal protected string[,] ReadTable(StringCollection input)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }
        var table = new string[input.Count, input[0].Length];

        if (input.Count == 0)
        {
            return table;
        }

        for (int i = 0; i < input.Count; i++)
        {
            for (int j = 0; j < input[i].Length; j++)
            {
                table[i, j] = input[i][j].ToString();
            }
        }
        return table;
    }
}
