using AoC23;
using System.Text.RegularExpressions;
public class Day06 : IDay
{
    List<int> time = new();
    List<int> distance = new();
    long totalTime;
    long totalDistance;
    public Day06(string file)
    {
        // Part 1:
        string[] input = File.ReadAllLines(file);
        string pattern1 = @"[0-9]+";

        var t1 = new Regex(pattern1).Matches(input[0]);
        foreach (Match item in t1.Cast<Match>())
            time.Add(int.Parse(item.Value));

        var d1 = new Regex(pattern1).Matches(input[1]);
        foreach (Match item in d1.Cast<Match>())
            distance.Add(int.Parse(item.Value));

        // Part 2:
        string pattern2 = @"[0-9]";

        var t2 = new Regex(pattern2).Matches(input[0]);
        string tBuilder = "";
        foreach (Match item in t2.Cast<Match>())
            tBuilder += item.Value;
        totalTime = long.Parse(tBuilder);

        var d2 = new Regex(pattern2).Matches(input[1]);
        string dBuilder = "";
        foreach (Match item in d2.Cast<Match>())
            dBuilder += item.Value;
        totalDistance = long.Parse(dBuilder);
    }

    public void PartOne()
    {
        List<int> allWins = new();
        for (int i = 0; i < time.Count; i++)
        {
            int wins = 0;
            for (int t = 0; t < time[i]; t++)
            {
                int chargeTime = t;
                int travelTime = time[i] - t;
                int travelDist = chargeTime * travelTime;
                if (travelDist > distance[i])
                    wins++;
            }
            allWins.Add(wins);
        }

        int margin = allWins.Count > 0 ? 1 : 0;
        for (int i = 0; i < allWins.Count; i++)
            margin *= allWins[i];

        Console.WriteLine(margin);
    }

    public void PartTwo()
    {
        long wins = 0;
        for (int i = 0; i < totalTime; i++)
        {
            long chargeTime = i;
            long travelTime = totalTime - i;
            long travelDist = chargeTime * travelTime;
            if (travelDist > totalDistance)
                wins++;
        }
        Console.WriteLine(wins);

        // Quadratic math way:
        // travelDist = chargeTime * (totalTime - chargeTime)
        // chargeTime^2 - chargeTime*totalTime + travelDist = 0
        // wins = roots of chargeTime: (higher time - lower time) + 1
    }
}