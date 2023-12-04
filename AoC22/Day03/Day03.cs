using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AoC22
{
    internal class Day03 : IDay
    {
        public List<string> rucksacks;
        public Day03(string file)
        {
            rucksacks = ReadInput(file);
        }
        public static List<string> ReadInput(string path)
        {
            string input = File.ReadAllText(path);
            List<string> list = new List<string>();
            list.AddRange(input.Split("\n"));
            return list;
        }


        public static int GetPriority(char i)
        {
            if (i >= 'a' && i <= 'z')
                return i - 'a' + 1; // 1-26
            if (i >= 'A' && i <= 'Z')
                return i - 'A' + 27; // 27-52
            return -1; // not an alphabet
        }
        public void PartOne()
        {
            int total = 0;
            for (int i = 0; i < rucksacks.Count; i++)
            {
                List<int> common = new();
                int halfIndex = rucksacks[i].Length / 2;
                for (int j = 0; j < halfIndex; j++)
                {
                    for (int k = halfIndex; k < rucksacks[i].Length; k++)
                    {
                        if (rucksacks[i][j] == rucksacks[i][k])
                            common.Add(GetPriority(rucksacks[i][k]));
                    }
                }
                total += common.Min();
            }
            Console.WriteLine(total);
        }

        public void PartTwo()
        {
            int total = 0;
            for (int i = 0; i < rucksacks.Count; i += 3)
            {
                List<int> common = new();
                foreach (var a in rucksacks[i])
                    foreach (var b in rucksacks[i + 1])
                        foreach (var c in rucksacks[i + 2])
                            if (a == b && a == c)
                                common.Add(GetPriority(a));
                total += common.Min();
            }
            Console.WriteLine(total);
        }
    }
}
