namespace AoC23
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main()
        {
            currentDay = new Day04("Day04/Input04.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}