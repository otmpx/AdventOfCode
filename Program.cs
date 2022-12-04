namespace AdventOfCock
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main(string[] args)
        {
            currentDay = new Day04("Day04/Input04.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}