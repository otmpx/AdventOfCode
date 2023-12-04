using System;
namespace AoC23
{
    public class Day01 : IDay
    {
        List<string> input;
        public Day01(string file)
        {
            input = new List<string>();
            var lines = File.ReadAllLines(file);
            foreach (var item in lines)
                input.Add(item);
        }
        public void PartOne()
        {
            List<int> sums = new List<int>();
            foreach (var item in input)
            {
                List<int> numbers = new();
                foreach (char c in item)
                {
                    //if (int.TryParse(c, out int num))
                    //    numbers.Add(num);
                }
                sums.Add(numbers.First() + numbers.Last());
            }
            Console.Write(sums.Sum());
        }

        public void PartTwo()
        {
        }
    }
}
