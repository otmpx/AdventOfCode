using System;
using AoC23;
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
                numbers.Add(c - '0');
            if (numbers.Count > 0)
                sums.Add(int.Parse(numbers.First().ToString() + numbers.Last().ToString()));
        }
        Console.WriteLine(sums.Sum());
    }
    string ConvertToNumber(string input)
    {
        string current = "";
        string output = "";

        for (int i = 0; i < input.Length; i++)
        {
            if (char.IsNumber(input[i]))
            {
                output += input[i];
                continue;
            }

            current += input[i];
            if (current.Contains("one"))
            {
                output += "1";
                current = current.Substring(current.IndexOf("one") + 1);
            }
            if (current.Contains("two"))
            {
                output += "2";
                current = current.Substring(current.IndexOf("two") + 1);
            }
            if (current.Contains("three"))
            {
                output += "3";
                current = current.Substring(current.IndexOf("three") + 1);
            }
            if (current.Contains("four"))
            {
                output += "4";
                current = current.Substring(current.IndexOf("four") + 1);
            }
            if (current.Contains("five"))
            {
                output += "5";
                current = current.Substring(current.IndexOf("five") + 1);
            }
            if (current.Contains("six"))
            {
                output += "6";
                current = current.Substring(current.IndexOf("six") + 1);
            }
            if (current.Contains("seven"))
            {
                output += "7";
                current = current.Substring(current.IndexOf("seven") + 1);
            }
            if (current.Contains("eight"))
            {
                output += "8";
                current = current.Substring(current.IndexOf("eight") + 1);
            }
            if (current.Contains("nine"))
            {
                output += "9";
                current = current.Substring(current.IndexOf("nine") + 1);
            }
        }
        return output;
    }
}