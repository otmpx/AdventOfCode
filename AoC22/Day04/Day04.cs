using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AoC22
{
    internal class Day04 : IDay
    {
        public List<List<int>> firstSection = new();
        public List<List<int>> secondSection = new();
        public Day04(string file)
        {
            ReadInput(file);
        }
        public void ReadInput(string path)
        {
            string input = File.ReadAllText(path);
            string[] byIndex = input.Split("\n");
            for (int i = 0; i < byIndex.Length; i++)
            {
                string[] byPos = byIndex[i].Split(",");
                firstSection.Add(new List<int>());
                secondSection.Add(new List<int>());
                for (int split = 0; split <= 1; split++)
                {
                    var sections = byPos[split].Split("-");
                    int firstIndex = int.Parse(sections[0]);
                    int lastIndex = int.Parse(sections[1]);
                    if (split == 0)
                        for (int f = firstIndex; f <= lastIndex; f++)
                            firstSection[i].Add(f);
                    else
                        for (int s = firstIndex; s <= lastIndex; s++)
                            secondSection[i].Add(s);
                }
            }
        }
        public void PartOne()
        {
            int duplicateCount = 0;
            for (int i = 0; i < firstSection.Count; i++)
            {
                if ((firstSection[i].First() >= secondSection[i].First() && firstSection[i].Last() <= secondSection[i].Last()) ||   // first inside second
                    (firstSection[i].First() <= secondSection[i].First() && firstSection[i].Last() >= secondSection[i].Last()))     // second inside first
                    duplicateCount++;
            }
            Console.WriteLine(duplicateCount);
        }
        public void PartTwo()
        {
            int overlapCount = 0;
            for (int i = 0; i < firstSection.Count; i++)
            {
                bool overlap = false;
                foreach (var item in firstSection[i])
                    if (secondSection[i].Contains(item))
                        overlap = true;
                foreach (var item in secondSection[i])
                    if (firstSection[i].Contains(item))
                        overlap = true;
                if (overlap)
                    overlapCount++;
            }
            Console.WriteLine(overlapCount);
        }
    }
}
