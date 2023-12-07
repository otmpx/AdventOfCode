using AoC23;
using System.Data;
public class Day07 : IDay
{
    readonly List<char> deck = new()
    {
        'A', 'K', 'Q', 'J', 'T', '9', '8', '7', '6', '5', '4', '3', '2'
    };
    public enum Result
    {
        FiveOfAKind,    //AAAAA
        FourOfAKind,    //AA8AA
        FullHouse,      //23332
        ThreeOfAKind,   //TTT98
        TwoPair,        //23432
        OnePair,        //A23A4
        HighCard,       //23456

        // If tied, compare strength of card starting from first card - last card in hand
        // Eg 33332 wins 2AAAA, 77888 wins 77788
    }
    public class Player
    {
        public readonly string draw;
        public readonly int bid;
        public string sortID;
        public Result result;
        public int position;
        public Player(string draw, string bid)
        {
            this.draw = draw;
            this.bid = int.Parse(bid);
        }
    }
    public List<Player> players = new();
    public Day07(string file)
    {
        string[] input = File.ReadAllLines(file);
        foreach (var item in input)
        {
            string[] split = item.Split(' ');
            Player player = new(split[0], split[1]);
            players.Add(player);
        }
    }
    string GetSortID(string hand, List<char> deck)
    {
        string sortedID = "";
        for (int i = 0; i < hand.Length; i++)
        {
            for (int j = 0; j < deck.Count; j++)
            {
                if (deck[j] == hand[i])
                {
                    sortedID += ((char)(j + 'a')).ToString(); // Convert to alphabetical for sorting
                }
            }
        }
        return sortedID;
    }
    string InverseSortID(string sortID, List<char> deck)
    {
        string hand = "";
        for (int i = 0; i < sortID.Length; i++)
        {
            for (int j = 0; j < deck.Count; j++)
            {
                if (deck[j] == (sortID[i] - 'a'))
                {
                    hand += deck[j];
                }
            }
        }
        return hand;
    }
    Result EvaluateResult(string hand)
    {
        string sortedHand = "";
        for (int i = 0; i < deck.Count; i++)
        {
            for (int j = 0; j < hand.Length; j++)
            {
                if (deck[i] == hand[j])
                {
                    sortedHand += hand[j];
                }
            }
        }

        var groupedHand = sortedHand.GroupBy(c => c).Where(group => group.Count() > 1);
        List<IGrouping<char, char>> groupedCards = [.. groupedHand]; // Same as below
        //List<IGrouping<char, char>> groupedCards = new();
        //foreach (var group in groupedHand)
        //    groupedCards.Add(group);

        if (groupedCards.Count == 0) return Result.HighCard;
        if (groupedCards[0].Count() == 5) return Result.FiveOfAKind;
        if (groupedCards[0].Count() == 4) return Result.FourOfAKind;
        if (groupedCards.Count == 2 && (groupedCards[0].Count() == 3 || groupedCards[1].Count() == 3)) return Result.FullHouse;
        if (groupedCards[0].Count() == 3) return Result.ThreeOfAKind;
        if (groupedCards.Count == 2) return Result.TwoPair;
        if (groupedCards[0].Count() == 2) return Result.OnePair;
        throw new Exception("Edge case detected: " + hand);
    }
    List<Player> EvaluatedPositions()
    {
        List<List<Player>> byResult = new();
        for (int i = Enum.GetNames(typeof(Result)).Length - 1; i >= 0; i--)
            byResult.Add(new List<Player>());


        for (int i = 0; i < byResult.Count; i++)
        {
            // Add players to grouped list by Result
            foreach (var player in players)
            {
                if ((int)player.result == i)
                    byResult[i].Add(player);
            }
            // Sort each group by card strength order
            byResult[i].Sort((x, y) => x.sortID.CompareTo(y.sortID));
        }

        List<Player> allPlayers = new();
        foreach (var players in byResult)
            allPlayers.AddRange(players);

        for (int i = 0; i < allPlayers.Count; i++)
            allPlayers[i].position = allPlayers.Count - i;

        return allPlayers;
    }
    public void PartOne()
    {
        foreach (var player in players)
        {
            player.sortID = GetSortID(player.draw, deck);
            player.result = EvaluateResult(player.draw);
        }
        int winnings = 0;
        List<Player> sortedPositions = EvaluatedPositions().OrderBy(p => p.position).ToList();
        foreach (var player in sortedPositions)
        {
            winnings += player.position * player.bid;
        }
        Console.WriteLine(winnings);
    }

    readonly List<char> jokerDeck = new()
    {
        'A', 'K', 'Q', 'T', '9', '8', '7', '6', '5', '4', '3', '2', 'J'
    };
    Result EvaluateJokerResult(string hand)
    {
        string sortedHand = "";
        int jokerCount = 0;
        for (int i = 0; i < jokerDeck.Count; i++)
        {
            for (int j = 0; j < hand.Length; j++)
            {
                if (deck[i] == hand[j])
                {
                    sortedHand += hand[j];
                    if (hand[j] == 'J')
                        jokerCount++;
                }
            }
        }

        if (jokerCount > 0)
        {

        }

        // Sort hand by strength
        string sortID = GetSortID(hand, jokerDeck);
        var sort = sortID.ToList();
        sort.Sort((x, y) => x.CompareTo(y));
        string newHand = InverseSortID(string.Concat(sort), jokerDeck);

        // Replace jokers and sort again


        var groupedHand = sortedHand.GroupBy(c => c).Where(group => group.Count() > 1);
        List<IGrouping<char, char>> groupedCards = [.. groupedHand];

        if (groupedCards.Count == 0) return Result.HighCard;
        if (groupedCards[0].Count() == 5) return Result.FiveOfAKind;
        if (groupedCards[0].Count() == 4) return Result.FourOfAKind;
        if (groupedCards.Count == 2 && (groupedCards[0].Count() == 3 || groupedCards[1].Count() == 3)) return Result.FullHouse;
        if (groupedCards[0].Count() == 3) return Result.ThreeOfAKind;
        if (groupedCards.Count == 2) return Result.TwoPair;
        if (groupedCards[0].Count() == 2) return Result.OnePair;
        throw new Exception("Edge case detected: " + hand);
    }
    public void PartTwo()
    {
        foreach (var player in players)
        {
            player.sortID = GetSortID(player.draw, jokerDeck);
            player.result = EvaluateJokerResult(player.draw);
        }
    }
}