namespace AoC23
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main()
        {
            currentDay = new Day03("Day03/Input03.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}
