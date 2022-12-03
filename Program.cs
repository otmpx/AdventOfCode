namespace AdventOfCock
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main(string[] args)
        {
            currentDay = new Day03("Day03/Input03.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}