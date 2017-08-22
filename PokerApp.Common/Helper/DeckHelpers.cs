using PokerApp.Common.Enums;
using PokerApp.Common.Models;
using System;

namespace PokerApp.Common.Helper
{
    public static class DeckHelpers
    {
        public static Card[] CreateNewDeck()
        {
            var deck = new Card[52];
            var counter = 0;
            foreach (Suit s in Enum.GetValues(typeof(Suit)))
            {
                foreach (Rank r in Enum.GetValues(typeof(Rank)))
                {
                    if (r != Rank.None && s != Suit.None)
                    {
                        deck[counter++] = new Card(r, s);
                    }
                }
            }

            return deck;
        }
    }
}
