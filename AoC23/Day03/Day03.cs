using AoC23;
using System;

public class Day03 : IDay
{
    public Day03(string file)
    {
        var lines = File.ReadAllLines(file);
    }
    public struct Position
    {
        public int x;
        public int y;
    }
    public Position bounds;
    public class Transform
    {
        public Position pos;
    }
    public void PartOne()
    {
        throw new NotImplementedException();
    }

    public void PartTwo()
    {
        throw new NotImplementedException();
    }
}
