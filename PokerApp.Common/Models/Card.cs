using PokerApp.Common.Enums;
using System;

namespace PokerApp.Common.Models
{
    public class Card : IComparable
    {
        public Rank Rank { get; set; }
        public Suit Suit { get; set; }

        public Card(Rank rank, Suit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        public int CompareTo(object obj)
        {
            if (obj is Card)
            {
                Card c = (Card)obj;
                if (Rank < c.Rank)
                    return -1;
                else if (Rank > c.Rank)
                    return 1;
                return 0;
            }
            throw new ArgumentException("Object is not a Card");
        }
    }
}
