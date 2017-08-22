using PokerApp.Common.Helper;
using System;
using System.Linq;

namespace PokerApp.Common.Models
{
    public class Game
    {
        public Deck Deck { get; set; }
        public Player[] Players { get; set; }

        public int Rounds { get; set; }

        public Game(int amountOfPlayers, int rounds)
        {
            Deck = new Deck(DeckHelpers.CreateNewDeck());
            Players = new Player[amountOfPlayers];
            NewHand();
            Rounds = rounds;
        }

        public void NewHand()
        {
            for (int i = 0; i < Players.Length; ++i)
            {
                if(Players[i] == null)
                    Players[i] = new Player(i+1);

                Players[i].Hand = new Hand();
            }
        }

        public void ResolveCloseHands()
        {
            var groupedPlayers = Players.GroupBy(x => x.Hand.HandScore, y => y)
                    .Where(g => g.Count() > 1)
                    .Select(y => y)
                    .ToList();

            if (groupedPlayers.Any())
            {
                foreach (var grouping in groupedPlayers)
                {
                    var listOfPlayers = grouping.Select(x => x).ToList();

                    for (int i = 0; i < listOfPlayers.Count(); i++)
                    {
                        if (i + 1 == listOfPlayers.Count())
                            break;

                        if (listOfPlayers[i].Hand.IsGreater(listOfPlayers[i + 1].Hand))
                        {
                            listOfPlayers[i].Hand.HandScore++;
                        }
                        else
                        {
                            listOfPlayers[i + 1].Hand.HandScore++;
                        }
                    }
                }
            }
        }

        public string PlayerHands => string.Join(Environment.NewLine, Players.Select(x => $"Player: {x.Index}'s hand{Environment.NewLine}{x.Hand}"));

        public void AwardingPoints()
        {
            var finalGroup = Players.GroupBy(x => x.Hand.HandScore, y => y)
                     .Where(g => g.Count() > 0)
                     .OrderBy(x => x.Key)
                     .Select(y => y)
                     .ToList();
            var flatList = finalGroup.SelectMany(x => x).ToArray();

            for (int i = 0; i < flatList.Count(); i++)
            {
                flatList[i].Score += i;
            }
        }

        public void DealCards()
        {
            for (int dealRound = 0; dealRound < 2; dealRound++)
            {
                for (int i = 0; i < Players.Length; i++)
                {
                    Players[i].Hand.AddCard(Deck.DealCard());
                }
            }
        }

        public string PlayerScores => string.Join("|", Players.Select(x => $" P{x.Index}:{x.Score} "));

        public Player[] WinningPlayers => Players.GroupBy(x => x.Score, y => y)
                .OrderByDescending(x => x.Key)
                .Select(x => x)
                .First().ToArray();

        public string PrintWinningPlayers => string.Join("and", WinningPlayers.Select(x => $" P{x.Index} with score: {x.Score} "));
    }
}
