using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Day4;

internal sealed class Parser : IParser
{
    public int Part1(StringCollection wordSearch)
    {
        if (wordSearch == null)
        {
            throw new ArgumentNullException(nameof(wordSearch));
        }

        var grid = ConvertoGrid(wordSearch);

        var total = CalculateTotalXmasByLine(wordSearch);
        total += CalculateTotalXmasByColumn(grid);
        total += CalculateTotalXmasByLeftToRightDiagonal(grid);
        total += CalculateTotalXmasByRightToLeftDiagonal(grid);
        return total;

    }

    internal protected int CalculateTotalXmasByRightToLeftDiagonal(Dictionary<int, char[]> grid)
    {
        var newGrid = new Dictionary<int, char[]>();
        foreach (var item in grid)
        {
            newGrid.Add(item.Key, item.Value.Reverse().ToArray());
        }

        return CalculateTotalXmasByLeftToRightDiagonal(newGrid);
    }

    internal protected int CalculateTotalXmasByLeftToRightDiagonal(Dictionary<int, char[]> grid)
    {
        var rows = ConvertLeftoRightDiagonalToRows(grid);
        return CalculateTotalXmasByLine(rows);
    }

    internal protected StringCollection ConvertLeftoRightDiagonalToRows(Dictionary<int, char[]> grid)
    {
        if (grid == null)
        {
            throw new ArgumentNullException(nameof(grid));
        }
        if (grid.Count == 0)
        {
            return new StringCollection();
        }
        var firstPass = true;
        var totalRows = grid.Count;
        var totalColumns = grid[0].Length;
        var rows = new StringCollection();

        for (int row = 0; row < totalRows; row++)
        {

            for (int column = 0; column < totalColumns; column++)
            {
                var line = GetDiagonal(grid, row, column);
                if (line.Length >= 4)
                {
                    rows.Add(line);
                }
                if (!firstPass)
                {
                    break;
                }
            }
            firstPass = false;
        }
        return rows;
    }

    internal protected string GetDiagonal(Dictionary<int, char[]> grid, int row, int column)
    {
        var line = string.Empty;
        if (row >= grid.Count || column >= grid[0].Length)
        {
            return line;
        }

        return grid[row][column].ToString() + GetDiagonal(grid, row + 1, column + 1);
    }

    internal protected int CalculateTotalXmasByColumn(Dictionary<int, char[]> grid)
    {
        var rows = ConvertColumnsToRows(grid);
        return CalculateTotalXmasByLine(rows);
    }

    internal protected StringCollection ConvertColumnsToRows(Dictionary<int, char[]> grid)
    {
        if (grid == null)
        {
            throw new ArgumentNullException(nameof(grid));
        }
        if (grid.Count == 0)
        {
            return new StringCollection();
        }
        var totalColumns = grid[0].Length;
        var rows = new StringCollection();

        for (int i = 0; i < totalColumns; i++)
        {
            var row = string.Empty;
            foreach (var column in grid)
            {
                row += column.Value[i];
            }
            rows.Add(row);
        }

        return rows;
    }

    internal protected Dictionary<int, char[]> ConvertoGrid(StringCollection wordSearch)
    {
        if (wordSearch == null)
        {
            throw new ArgumentNullException(nameof(wordSearch));
        }

        var grid = new Dictionary<int, char[]>();
        for (int i = 0; i < wordSearch.Count; i++)
        {
            grid.Add(i, wordSearch[i].ToCharArray());
        }
        return grid;
    }
    internal protected int CalculateTotalXmasByLine(StringCollection wordSearch)
    {
        int total = 0;
        foreach (var line in wordSearch)
        {
            total += CalculateNumberOfXmas(line);
            total += CalculateNumberOfXmas(Reverse(line));
        }
        return total;
    }

    internal protected int CalculateNumberOfXmas(string line)
    {
        line = line.Replace(".", "");
        var regex = new Regex(@"xmas", RegexOptions.IgnoreCase);
        var matches = regex.Matches(line);
        return matches.Count;
    }

    internal protected string Reverse(string line)
    {
        char[] charArray = line.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    public int Part2(StringCollection wordSearch)
    {
        if (wordSearch == null)
        {
            throw new ArgumentNullException(nameof(wordSearch));
        }

        var grid = ConvertoGrid(wordSearch);
        var totalRows = grid.Count - 1;
        var total = 0;
        for (int rowIndex = 1; rowIndex < totalRows; rowIndex++)
        {
            total += CountXMasInGrid(grid, rowIndex);
        }

        return total;
    }

    internal int CountXMasInGrid(Dictionary<int, char[]> grid, int rowIndex)
    {
        if (grid == null)
        {
            throw new ArgumentException(nameof(grid));
        }

        if (rowIndex < 0 || rowIndex > grid.Count - 2)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        }

        var row = grid[rowIndex];
        var colIndex = 0;
        var rowLength = row.Length;
        var total = 0;

        while (colIndex < rowLength)
        {
            var aIndex = Array.FindIndex(row, colIndex, c => c == 'A');
            if (aIndex == -1)
            {
                colIndex = rowLength;
                break;
            }

            if (IsValidXmas(grid, rowIndex, aIndex))
            {
                total++;
            }
            colIndex = aIndex + 1;
        }

        return total;
    }
    internal protected bool IsValidXmas(Dictionary<int, char[]> grid, int rowIndex, int aIndex)
    {
        if (grid == null)
        {
            throw new ArgumentException(nameof(grid));
        }

        if (rowIndex >= grid.Count)
        {
            throw new ArgumentOutOfRangeException(nameof(rowIndex));
        }
        if (aIndex == 0)
        {
            return false;
        }
        var previousRow = grid[rowIndex - 1];
        var nextRow = grid[rowIndex + 1];

        if (aIndex + 1 >= previousRow.Length || aIndex + 1 >= nextRow.Length)
        {
            return false;
        }

        var topLeftChar = previousRow[aIndex - 1];
        var topRightChar = previousRow[aIndex + 1];
        var bottomLeftChar = nextRow[aIndex - 1];
        var bottomRightChar = nextRow[aIndex + 1];

        if (!IsValidXmasValues(topLeftChar, bottomRightChar))
        {
            return false;
        }
        if (!IsValidXmasValues(topRightChar, bottomLeftChar))
        {
            return false;
        }
        return true;
    }

    private bool IsValidXmasValues(char char1, char char2)
    {
        if (char1 != 'M' && char1 != 'S')
        {
            return false;
        }
        if (char2 != 'M' && char2 != 'S')
        {
            return false;
        }

        return char1 != char2;
    }
}
