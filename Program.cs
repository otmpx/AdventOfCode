namespace AdventOfCock
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main()
        {
            currentDay = new Day07("Day07/Sample07.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}