namespace AdventOfCock
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main(string[] args)
        {
            currentDay = new Day06("Day06/Input06.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}