﻿using FileParse;

namespace Day5;

internal sealed class ConsoleApplication
{
    private readonly IReadFileContents _readFileContents;
    private readonly IParser _parser;
    public ConsoleApplication(IReadFileContents readFileContents, IParser parser)
    {
        _readFileContents = readFileContents;
        _parser = parser;
    }
    public void Run()
    {
        var input = _readFileContents.AsLines("C:\\GitHub\\Advent-Of-Code-2024\\data\\inputDay5.txt");

        var total = _parser.Part1(input);
        Console.WriteLine("Part 1: " + total); //5248 

        total = _parser.Part2(input);
        Console.WriteLine("Part 2: " + total); //!4201

    }
}
