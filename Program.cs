namespace AdventOfCock
{
    internal class Program
    {
        static IDay currentDay;
        static void Main(string[] args)
        {
            currentDay= new Day01("Day01/Input01.txt", 3);
            currentDay.PartOne();
            currentDay.PartTwo();
            Console.ReadLine();
        }
    }
}