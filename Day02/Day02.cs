using System;
namespace AdventOfCock
{
    public class Day02 : IDay
    {
        private readonly List<string> against;
        private readonly List<string> chosen;
        public Day02(string file)
        {
            ReadInput(file, out against, out chosen);
        }
        public static void ReadInput(string path, out List<string> against, out List<string> chosen)
        {
            string input = File.ReadAllText(path);
            string[] groups = input.Split("\n");
            List<string> a = new List<string>();
            List<string> c = new List<string>();
            foreach (var item in groups)
            {
                var split = item.Split(" ");
                a.Add(split[0].ToString());
                c.Add(split[1].ToString());
            }
            against = a;
            chosen = c;
        }
        public enum Zahandzuo
        {
            rock, paper, scissors
        }
        public Dictionary<string, Zahandzuo> opponent = new()
        {
            {"A", Zahandzuo.rock}, {"B", Zahandzuo.paper}, {"C", Zahandzuo.scissors}
        };
        public Dictionary<string, Zahandzuo> self = new()
        {
            {"X", Zahandzuo.rock}, {"Y", Zahandzuo.paper}, {"Z", Zahandzuo.scissors}
        };
        public Dictionary<string, int> rig = new()
        {
            // X Lose, Y Draw, Z Win
            {"X", -1}, {"Y", 0}, {"Z", 1}
        };
        public int CalculateScore(Zahandzuo s, Zahandzuo o)
        {
            int score = 0;
            score = (4 + (int)s - (int)o) % 3; // 0 1 2
            score *= 3;
            score += ((int)s + 1);
            return score;
        }
        public void PartOne()
        {
            int totalScore = 0;
            for (int i = 0; i < chosen.Count; i++)
                totalScore += CalculateScore(self[chosen[i]], opponent[against[i]]);
            Console.WriteLine(totalScore);
        }
        public void PartTwo()
        {
            int totalScore = 0;
            for (int i = 0; i < chosen.Count; i++)
            {
                Zahandzuo o = opponent[against[i]];
                int rigResult = rig[chosen[i]];
                Zahandzuo c = (Zahandzuo)(((int)o + rigResult + 3) % 3);
                totalScore += CalculateScore(c, o);
            }
            Console.WriteLine(totalScore);
        }
        //    public int CalculateResult(string a, string c)
        //    {
        //        int score = 0;
        //        switch (c)
        //        {
        //            case "X":
        //                score = 1;
        //                if (a == "A")
        //                    score += 3;
        //                if (a == "C")
        //                    score += 6;
        //                break;
        //            case "Y":
        //                score = 2;
        //                if (a == "A")
        //                    score += 6;
        //                if (a == "B")
        //                    score += 3;
        //                break;
        //            case "Z":
        //                score = 3;
        //                if (a == "B")
        //                    score += 6;
        //                if (a == "C")
        //                    score += 3;
        //                break;
        //        }
        //        return score;
        //    }
        //    public void PartOne()
        //    {
        //        int totalScore = 0;
        //        for (int i = 0; i < chosen.Count; i++)
        //        {
        //            totalScore += CalculateResult(against[i], chosen[i]);
        //        }
        //        Console.WriteLine(totalScore);
        //    }
        //    public void ChangeChosen(string a, string c, out string o)
        //    {
        //        // X: Lose
        //        // Y: Draw
        //        // Z: Win
        //        o = "";
        //        switch (a)
        //        {
        //            case "A": //Rock
        //                switch (c)
        //                {
        //                    case "X":
        //                        o = "Z";
        //                        break;
        //                    case "Y":
        //                        o = "X";
        //                        break;
        //                    case "Z":
        //                        o = "Y";
        //                        break;
        //                }
        //                break;
        //            case "B": //Paper
        //                switch (c)
        //                {
        //                    case "X":
        //                        o = "X";
        //                        break;
        //                    case "Y":
        //                        o = "Y";
        //                        break;
        //                    case "Z":
        //                        o = "Z";
        //                        break;
        //                }
        //                break;
        //            case "C": //Scissors
        //                switch (c)
        //                {
        //                    case "X":
        //                        o = "Y";
        //                        break;
        //                    case "Y":
        //                        o = "Z";
        //                        break;
        //                    case "Z":
        //                        o = "X";
        //                        break;
        //                }
        //                break;
        //        }
        //    }
        //    public void PartTwo()
        //    {
        //        int totalScore = 0;
        //        List<string> changed = new();
        //        for (int i = 0; i < chosen.Count; i++)
        //        {
        //            ChangeChosen(against[i], chosen[i], out string o);
        //            changed.Add(o);
        //            totalScore += CalculateResult(against[i], changed[i]);
        //        }
        //        Console.WriteLine(totalScore);
        //    }
        //}
    }
}

