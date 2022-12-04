namespace AdventOfCock
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main(string[] args)
        {
            currentDay = new Day04("Day04/Sample04.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}