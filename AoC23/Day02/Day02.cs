using System;
using System.Drawing;

namespace AoC23
{
    public class Day02 : IDay
    {
        enum Colour { red, green, blue }
        Dictionary<Colour, int> maxCubes = new()
        {
            { Colour.red, 12 },
            { Colour.green, 13 },
            { Colour.blue, 14 },
        };
        List<List<Dictionary<Colour, int>>> games = new();
        public Day02(string file)
        {
            var lines = File.ReadAllLines(file);
            foreach (var item in lines)
            {
                string gameData = item.Split(": ")[1];
                string[] matches = gameData.Split("; ");
                List<Dictionary<Colour, int>> matchEntry = new();
                foreach (var scoreboard in matches)
                {
                    Dictionary<Colour, int> scoreEntry = new();
                    string[] scores = scoreboard.Split(", ");
                    foreach (var cubeCount in scores)
                    {
                        var split = cubeCount.Split(" ");
                        scoreEntry.Add(StringToEnum(split[1]), int.Parse(split[0]));
                    }
                    matchEntry.Add(scoreEntry);
                }
                games.Add(matchEntry);
            }
        }
        Colour StringToEnum(string col)
        {
            switch (col)
            {
                case "red": return Colour.red;
                case "green": return Colour.green;
                case "blue": return Colour.blue;
                default: throw new NotImplementedException();
            }
        }

        public void PartOne()
        {
            List<bool> possibleGames = new();
            foreach(var game in games)
            {
                bool result = true;
                foreach (var scoreboard in game)
                {
                    if (scoreboard.ContainsKey(Colour.red) && scoreboard[Colour.red] > maxCubes[Colour.red])
                        result = false;
                    if (scoreboard.ContainsKey(Colour.green) && scoreboard[Colour.green] > maxCubes[Colour.green])
                        result = false;
                    if (scoreboard.ContainsKey(Colour.blue) && scoreboard[Colour.blue] > maxCubes[Colour.blue])
                        result = false;
                }
                possibleGames.Add(result);
            }
            int indexSum = 0;
            for (int i = 0; i < possibleGames.Count; i++)
            {
                if (possibleGames[i])
                    indexSum += i;
            }
            Console.WriteLine(indexSum);
        }

        public void PartTwo()
        {
        }
    }
}
