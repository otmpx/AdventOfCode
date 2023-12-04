using AoC23;
using System;

public class Day03 : IDay
{
    public Day03(string file)
    {
        var lines = File.ReadAllLines(file);
        bounds.x = lines[0].Length;
        bounds.y = lines.Length;

        for (int y = 0; y < bounds.y; y++)
        {
            for (int x = 0; x < bounds.x; x++)
            {
                Transform point = new Transform();
                point.pos.x = x;
                point.pos.y = y;
                point.value = lines[y][x];
            }
        }
    }
    public struct Position
    {
        public int x;
        public int y;
    }
    public class Transform
    {
        public Position pos;
        public char value;
        public bool marked = false;
    }
    public Position bounds;
    public List<Transform> points = new();
    char GetTransformValue(int x, int y)
    {
        var search = points.Where(p => p.pos.x == x && p.pos.y == y).First();
        if (search == null)
            return '.';
        else
            return search.value;
    }
    //string GetWholeNumber(Transform t)
    //{
    //    // do recursive
    //    if (t.marked) return "";
    //}
    void CheckAdjacent(Transform t)
    {
        if (GetTransformValue(t.pos.x, t.pos.y + 1) != '.') // N
        {

        }
        if (GetTransformValue(t.pos.x + 1, t.pos.y + 1) != '.') // NE
        {

        }
        if (GetTransformValue(t.pos.x + 1, t.pos.y) != '.') // E
        {

        }
        if (GetTransformValue(t.pos.x + 1, t.pos.y - 1) != '.') // SE
        {

        }
        if (GetTransformValue(t.pos.x, t.pos.y - 1) != '.') // S
        {

        }
        if (GetTransformValue(t.pos.x - 1, t.pos.y - 1) != '.') // SW
        {

        }
        if (GetTransformValue(t.pos.x - 1, t.pos.y) != '.') // W
        {

        }
        if (GetTransformValue(t.pos.x - 1, t.pos.y + 1) != '.') // NW
        {

        }
    }
    public void PartOne()
    {
        foreach (var item in points)
        {
            if (item.value != '.' && char.IsLetterOrDigit(item.value))
            {

            }
        }
    }

    public void PartTwo()
    {
        throw new NotImplementedException();
    }
}
