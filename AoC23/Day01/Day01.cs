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
                foreach (var c in item)
                {
                    if (char.IsNumber(c))
                        numbers.Add(c - '0');
                }
                if (numbers.Count > 0)
                    sums.Add(int.Parse(numbers.First().ToString() + numbers.Last().ToString()));
            }
            Console.WriteLine(sums.Sum());
        }

        public void PartTwo()
        {
            List<int> sums = new();
            foreach (var item in input)
            {
                List<int> numbers = new();
                foreach (var c in ConvertToNumber(item))
                {
                    if (char.IsNumber(c))
                        numbers.Add(c - '0');
                }
                if (numbers.Count > 0)
                    sums.Add(int.Parse(numbers.First().ToString() + numbers.Last().ToString()));
            }
            Console.WriteLine(sums.Sum());
        }
        string ConvertToNumber(string input)
        {
            string current = "";
            for (int i = 0; i < input.Length; i++)
            {
                current += input[i];
                current = current.Replace("one", "1");
                current = current.Replace("two", "2");
                current = current.Replace("three", "3");
                current = current.Replace("four", "4");
                current = current.Replace("five", "5");
                current = current.Replace("six", "6");
                current = current.Replace("seven", "7");
                current = current.Replace("eight", "8");
                current = current.Replace("nine", "9");
            }
            return current;
        }
    }
}
