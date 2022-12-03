namespace AdventOfCock
{
    internal class Program
    {
        static IDay? currentDay;
        static void Main(string[] args)
        {
            currentDay = new Day02("Day02/Input02.txt");
            currentDay.PartOne();
            currentDay.PartTwo();
            Console.ReadKey();
        }
    }
}