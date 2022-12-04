using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCock
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
                for (int split = 0; split <= 1; split++)
                {
                    var sections = byPos[split].Split("-");
                    int firstIndex = int.Parse(sections[0]);
                    int lastIndex = int.Parse(sections[1]);
                    if (split == 0)
                        for (int f = firstIndex; f <= lastIndex; f++)
                            firstSection[i][0].Add(f);
                    else
                        for (int s = firstIndex; s <= lastIndex; s++)
                            secondSection[i][1].Add(s);
                }
            }
        }
        public void PartOne()
        {
        }

        public void PartTwo()
        {
        }
    }
}
