using AoC23;
public class Day03 : IDay
{
    public struct Position
    {
        public int x;
        public int y;
    }
    public Position bounds;
    public List<Position> dir8 = new()
    {
        new Position{x = 0, y = 1},
        new Position{x = 1, y = 1},
        new Position{x = 1, y = 0},
        new Position{x = 1, y = -1},
        new Position{x = 0, y = -1},
        new Position{x = -1, y = -1},
        new Position{x = -1, y = 0},
        new Position{x = -1, y = 1}
    };
    public class Transform
    {
        public Position pos;
        public char value;
        public bool marked;
    }
    public List<Transform> points = new();
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
    Transform GetTransform(int x, int y) => points.Where(p => p.pos.x == x && p.pos.y == y).FirstOrDefault();
    Transform GetAdjacent(Position from, Position to) => points.Where(p => p.pos.x == from.x + to.x && p.pos.y == from.y + to.y).FirstOrDefault();
    string GetFullNumber(Transform t)
    {
        if (t.marked) return "";
        t.marked = true;
        string concatenated = "";

        if (char.IsDigit(t.value))
            concatenated = t.value.ToString();

        Transform left = GetTransform(t.pos.x - 1, t.pos.y);
        if (left != null && char.IsDigit(left.value))
            concatenated = GetFullNumber(left) + concatenated;

        Transform right = GetTransform(t.pos.x + 1, t.pos.y);
        if (right != null && char.IsDigit(right.value))
            concatenated += GetFullNumber(right);

        return concatenated;
    }
    int SumAdjacent(Transform t)
    {
        int sum = 0;
        foreach (var dir in dir8)
        {
            Transform adjacent = GetAdjacent(t.pos, dir);
            if (adjacent != null && char.IsDigit(adjacent.value))
            {
                string number = GetFullNumber(adjacent);
                if (number != "")
                    sum += int.Parse(number);
            }
        }
        return sum;
    }
    public void PartOne()
    {
        int sum = 0;
        foreach (var item in points)
        {
            item.marked = false;

            if (item.value != '.' && !char.IsLetterOrDigit(item.value))
                sum += SumAdjacent(item);
        }
        Console.WriteLine(sum);
    }
    int SumRatio(Transform t)
    {
        List<string> numbers = new();
        foreach (var dir in dir8)
        {
            Transform adjacent = GetAdjacent(t.pos, dir);
            if (adjacent != null && char.IsDigit(adjacent.value))
            {
                string number = GetFullNumber(adjacent);
                if (number != "")
                    numbers.Add(number);
            }
        }
        int sum = 0;
        if (numbers.Count > 1)
        {
            sum = 1;
            foreach (var number in numbers)
                sum *= int.Parse(number);
        }
        return sum;
    }
    public void PartTwo()
    {
        int gearRatio = 0;
        foreach (var item in points)
        {
            item.marked = false;

            if (item.value == '*')
                gearRatio += SumRatio(item);
        }
        Console.WriteLine(gearRatio);
    }
}