namespace AoC23
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main()
        {
            currentDay = new Day01("Day01/Input01.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}
