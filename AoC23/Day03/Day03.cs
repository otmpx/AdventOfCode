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
                points.Add(point);
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
        if (x < 0 || x >= bounds.x || y < 0 || y >= bounds.y) return '.';
        var search = points.Where(p => p.pos.x == x && p.pos.y == y).First();
        if (search == null)
            return '.';
        else
            return search.value;
    }
    Transform GetTransform(int x, int y)
    {
        var search = points.Where(p => p.pos.x == x && p.pos.y == y).First();
        if (search == null)
            return null;
        else
            return search;
    }
    string GetFullNumber(Transform t)
    {
        if (t.marked) return "";
        t.marked = true;
        string concatenated = "";
        if (char.IsDigit(t.value))
            concatenated = t.value.ToString();
        if (GetTransformValue(t.pos.x - 1, t.pos.y) != '.')
            concatenated = GetFullNumber(GetTransform(t.pos.x - 1, t.pos.y)) + concatenated;
        if (GetTransformValue(t.pos.x + 1, t.pos.y) != '.')
            concatenated += GetFullNumber(GetTransform(t.pos.x + 1, t.pos.y));
        return concatenated;
    }
    int SumAdjacent(Transform t)
    {
        int sum = 0;

        char south = GetTransformValue(t.pos.x, t.pos.y + 1);
        if (south != '.' && char.IsDigit(south))
        {
            string number = GetFullNumber(GetTransform(t.pos.x, t.pos.y + 1));
            if (number != "")
                sum += int.Parse(number);
        }

        char southEast = GetTransformValue(t.pos.x + 1, t.pos.y + 1);
        if (southEast != '.' && char.IsDigit(southEast))
        {
            string number = GetFullNumber(GetTransform(t.pos.x + 1, t.pos.y + 1));
            if (number != "")
                sum += int.Parse(number);
        }

        char east = GetTransformValue(t.pos.x + 1, t.pos.y);
        if (east != '.' && char.IsDigit(east))
        {
            string number = GetFullNumber(GetTransform(t.pos.x + 1, t.pos.y));
            if (number != "")
                sum += int.Parse(number);
        }

        char northEast = GetTransformValue(t.pos.x + 1, t.pos.y - 1);
        if (northEast != '.' && char.IsDigit(northEast))
        {
            string number = GetFullNumber(GetTransform(t.pos.x + 1, t.pos.y - 1));
            if (number != "")
                sum += int.Parse(number);
        }

        char north = GetTransformValue(t.pos.x, t.pos.y - 1);
        if (north != '.' && char.IsDigit(north))
        {
            string number = GetFullNumber(GetTransform(t.pos.x, t.pos.y - 1));
            if (number != "")
                sum += int.Parse(number);
        }

        char northWest = GetTransformValue(t.pos.x - 1, t.pos.y - 1);
        if (northWest != '.' && char.IsDigit(northWest))
        {
            string number = GetFullNumber(GetTransform(t.pos.x - 1, t.pos.y - 1));
            if (number != "")
                sum += int.Parse(number);
        }

        char west = GetTransformValue(t.pos.x - 1, t.pos.y);
        if (west != '.' && char.IsDigit(west))
        {
            string number = GetFullNumber(GetTransform(t.pos.x - 1, t.pos.y));
            if (number != "")
                sum += int.Parse(number);
        }

        char southWest = GetTransformValue(t.pos.x - 1, t.pos.y + 1);
        if (southWest != '.' && char.IsDigit(southWest))
        {
            string number = GetFullNumber(GetTransform(t.pos.x - 1, t.pos.y + 1));
            if (number != "")
                sum += int.Parse(number);
        }

        return sum;
    }
    public void PartOne()
    {
        int sum = 0;
        foreach (var item in points)
        {
            if (item.value != '.' && !char.IsLetterOrDigit(item.value))
                sum += SumAdjacent(item);
        }
        Console.WriteLine(sum);
    }

    public void PartTwo()
    {
    }
}
