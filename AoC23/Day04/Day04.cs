using AoC23;
public class Day04 : IDay
{
    public List<List<int>> winCards = new();
    public List<List<int>> drawnCards = new();
    public Day04(string file)
    {
        var lines = File.ReadAllLines(file);
        foreach (var line in lines)
        {
            string numbers = line.Replace(":  ", ": ").Split(": ")[1];
            string[] split = numbers.Replace(" |  ", " | ").Split(" | ");

            string[] win = split[0].Replace("  ", " ").Split(' ');
            List<int> winNumbers = new();
            foreach (var item in win)
                winNumbers.Add(int.Parse(item));
            winCards.Add(winNumbers);

            string[] drawn = split[1].Replace("  ", " ").Split(' ');
            List<int> drawnNumbers = new();
            foreach (var item in drawn)
                drawnNumbers.Add(int.Parse(item));
            drawnCards.Add(drawnNumbers);
        }
    }
    public void PartOne()
    {
        int total = 0;
        for (int i = 0; i < drawnCards.Count; i++)
        {
            List<int> matchingNumbers = new();
            foreach (var drawn in drawnCards[i])
            {
                foreach (var win in winCards[i])
                {
                    if (drawn == win)
                        matchingNumbers.Add(win);
                }
            }
            int scored = 0;
            if (matchingNumbers.Count > 0)
            {
                scored = (int)MathF.Pow(2, matchingNumbers.Count - 1);
            }
            total += scored;
        }
        Console.WriteLine(total);
    }
    public void PartTwo()
    {
        List<int> copies = new();
        for (int i = 0; i < drawnCards.Count; i++)
            copies.Add(1);

        for (int i = 0; i < drawnCards.Count; i++)
        {
            for (int j = 0; j < copies[i]; j++)
            {
                int wins = 0;
                foreach (var drawn in drawnCards[i])
                {
                    foreach (var win in winCards[i])
                    {
                        if (drawn == win)
                        {
                            wins++;
                        }
                    }
                }
                for (int k = 0; k < wins; k++)
                {
                    if (i + k + 1 < copies.Count)
                    {
                        copies[i + k + 1]++;
                    }
                }
            }
        }
        Console.WriteLine(copies.Sum());
    }
}
