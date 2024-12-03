using Day3.Model;
using System.Collections.Specialized;

namespace Day3;

internal class Instructions : IInstructions
{
    public int TotalMultiplications(StringCollection memory)
    {
        if (memory == null)
        {
            throw new ArgumentNullException(nameof(memory));
        }

        if (memory.Count == 0)
        {
            throw new ArgumentException("Memory is empty", nameof(memory));
        }

        var instructions = ReadInstructions(memory);

        if (!instructions.Any())
        {
            throw new InvalidOperationException("No instructions found");
        }

        var total = 0;

        foreach (var instruction in instructions)
        {
            total += instruction.Key * instruction.Value;
        }
        return total;
    }
    public IEnumerable<MulInstruction> ReadInstructions(StringCollection memory)
    {
        var returnValues = new List<MulInstruction>();

        foreach (var line in memory)
        {
            var instructions = ReadInstructionsForLine(line);
            if (instructions != null)
            {
                returnValues = returnValues.Union(instructions).ToList<MulInstruction>();
            }
        }

        return returnValues;
    }
    public IEnumerable<MulInstruction> ReadInstructionsForLine(string line)
    {
        if (string.IsNullOrEmpty(line))
        {
            throw new ArgumentException("Line cannot be null or empty", nameof(line));
        }
        var returnValues = new List<MulInstruction>();
        var availabileInstructions = line.Split("mul(");
        foreach (var availabileInstruction in availabileInstructions)
        {
            var instruction = ReadInstruction(availabileInstruction);
            if (instruction != null)
            {
                returnValues.Add(instruction);
            }
        }

        return returnValues;
    }

    public MulInstruction ReadInstruction(string availabileInstruction)
    {
        if (string.IsNullOrEmpty(availabileInstruction))
        {
            return null;
        }

        var posCloseBracket = availabileInstruction.IndexOf(")");

        if (posCloseBracket == -1)
        {
            return null;
        }

        var availableValues = availabileInstruction.Substring(0, posCloseBracket);

        var values = availableValues.Split(",");

        if (values.Length != 2)
        {
            return null;
        }

        if (!int.TryParse(values[0], out var key))
        {
            return null;
        }

        if (!int.TryParse(values[1], out var value))
        {
            return null;
        }

        return new MulInstruction { Key = key, Value = value };
    }
}
