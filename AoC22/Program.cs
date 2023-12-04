namespace AoC22
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main()
        {
            currentDay = new Day08("Day08/Input08.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}