namespace AdventOfCock
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main(string[] args)
        {
            currentDay = new Day05("Day05/Input05a.txt", "Day05/Input05b.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}