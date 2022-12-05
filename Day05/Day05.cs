using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCock
{
    internal class Day05 : IDay
    {
        readonly List<List<char>> formation = new();
        readonly List<int> moveQuantity = new();
        readonly List<int> moveFrom = new();
        readonly List<int> moveTo = new();
        readonly int iterations;
        public Day05(string inputA, string inputB)
        {
            string[] init = File.ReadAllLines(inputA);

            // Init list of formation length
            for (int i = 0; i < init[0].Length; i += 4)
                formation.Add(new List<char>());

            // Add char from index of init[i]
            for (int i = 0; i < init.Length - 1; i++) // Exclude the last line (that goes 0 1 2 3 4 5 6 7 8 9)
                for (int c = 0, v = 1; v < init[i].Length; c++, v += 4) // index of v by char: [1] [5] [9] [13]...
                    formation[c].Add(init[i][v]);

            // Reverse and remove empty spaces from formation list
            foreach (var item in formation)
            {
                item.Reverse();
                item.RemoveAll(c => c == ' ');
            }

            //formation = new List<List<char>>()
            //{
            //    new List<char>(){'J','H','P','M','S','F','N','V'},
            //    new List<char>(){'S','R','L','M','J','D','Q'},
            //    new List<char>(){'N','Q','D','H','C','S','W','B'},
            //    new List<char>(){'R','S','C','L'},
            //    new List<char>(){'M','V','T','P','F','B'},
            //    new List<char>(){'T','R','Q','N','C'},
            //    new List<char>(){'G','V','R'},
            //    new List<char>(){'C','Z','S','P','D','L','R'},
            //    new List<char>(){'D','S','J','V','G','P','B','F'}
            //};

            string[] cmds = File.ReadAllLines(inputB);
            iterations = cmds.Length;
            string[] splitOptions = new string[] { "move ", " from ", " to " };

            for (int i = 0; i < cmds.Length; i++)
            {
                // Split a string delimited by another string and return 3 non-empty elements: https://learn.microsoft.com/en-us/dotnet/api/system.string.split?view=net-7.0
                string[] instructions = cmds[i].Split(splitOptions, 3, StringSplitOptions.RemoveEmptyEntries);
                moveQuantity.Add(int.Parse(instructions[0]));
                moveFrom.Add(int.Parse(instructions[1]));
                moveTo.Add(int.Parse(instructions[2]));

                // Index offset cuz they start from 1 instead of 0 (cringe)
                moveFrom[i] -= 1;
                moveTo[i] -= 1;
            }
        }
        public void PartOne()
        {
            // Doing this will still mutate the original list:
            //List<List<char>> newFormation = new();
            //newFormation.AddRange(formation);

            // We need to do a deep copy for nested lists:
            List<List<char>> newFormation = new();
            foreach (var item in formation)
                newFormation.Add(new(item));

            for (int i = 0; i < iterations; i++)
            {
                int takeQuantity = (int)MathF.Min(newFormation[moveFrom[i]].Count, moveQuantity[i]);
                if (takeQuantity == 0) continue;
                var take = newFormation[moveFrom[i]].TakeLast(takeQuantity).Reverse();
                newFormation[moveTo[i]].AddRange(take);
                newFormation[moveFrom[i]].RemoveRange(newFormation[moveFrom[i]].Count - takeQuantity, takeQuantity);

                // 0 1 2 3 -> Count 4
                // 0 1     -> TakeLast 2 (index 2-3)
                // remove index from 2 -> Count - takeQuantity 
            }

            string output = "";
            foreach (var item in newFormation)
                output += item.Last();
            Console.WriteLine(output);
        }
        public void PartTwo()
        {
            List<List<char>> newFormation = new();
            foreach (var item in formation)
                newFormation.Add(new(item));

            for (int i = 0; i < iterations; i++)
            {
                int takeQuantity = (int)MathF.Min(newFormation[moveFrom[i]].Count, moveQuantity[i]);
                if (takeQuantity == 0) continue;
                var take = newFormation[moveFrom[i]].TakeLast(takeQuantity);
                newFormation[moveTo[i]].AddRange(take);
                newFormation[moveFrom[i]].RemoveRange(newFormation[moveFrom[i]].Count - takeQuantity, takeQuantity);
            }

            string output = "";
            foreach (var item in newFormation)
                output += item.Last();
            Console.WriteLine(output);
        }
    }
}
