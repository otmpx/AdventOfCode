namespace AoC23
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main()
        {
            currentDay = new Day05("Day05/Input05.txt");
            //currentDay.PartOne();
            currentDay.PartTwo();
        }
    }
}