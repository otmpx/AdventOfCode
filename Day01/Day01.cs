using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCock
{
    internal class Day01 : IDay
    {
        //Perfect dependancy injection
        private readonly int _iterations;
        private readonly List<List<int>> elves;
        public Day01(string file = "", int iterations = 0)
        {
            elves = InputHelper.ReadInput(file);
            _iterations = iterations;
        }
        //public List<int> calories()
        //{
        //    var sum = elves.Select(l => l.Sum());
        //    return sum.ToList();
        //}
        public int PartOne(out int index)
        {
            int maxCalories = 0;
            index = 0;
            for (int i = 0; i < elves.Count; i++)
            {
                int calories = elves[i].Sum();
                if (calories > maxCalories)
                {
                    maxCalories = calories;
                    index = i;
                }
            }
            return maxCalories;
            //return calories().Max();
        }
        public void PartOne()
        {
            int index = 0;
            Console.WriteLine(PartOne(out index));
            //return calories().Max();
        }
        public void PartTwo()
        {
            //var sorted = calories().OrderBy(a => -a);
            //var top3 = sorted.Take(3).Sum();
            int[] topIterations = new int[_iterations];
            for (int i = 0; i < _iterations; i++)
            {
                int index;
                topIterations[i] = PartOne(out index);
                elves.RemoveAt(index);
            }
            Console.WriteLine(topIterations.Sum());
        }
    }
}
