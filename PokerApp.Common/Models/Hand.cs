using PokerApp.Common.Enums;
using PokerApp.Common.Extensions;
using System;
using System.Linq;
using System.Text;

namespace PokerApp.Common.Models
{
    public class Hand
    {
        public Card[] Cards { get; set; }

        public int HandScore { get; set; }

        public Hand(Card[] cards)
        {
            Cards = cards;
            if (IsBothCardsSet)
            {
                Sort();
                RankingHand();
            }
        }

        public Hand()
        {
            Cards = new Card[2];
        }

        public override string ToString()
        {
            return Cards.Aggregate(new StringBuilder(),
                  (sb, a) => sb.AppendLine(string.Join(",", a)),
                  sb => sb.ToString()); ;
        }

        public void Sort()
        {
            Array.Sort(Cards);
        }

        public void AddCard(Card card)
        {
            if(Cards[0] == null)
            {
                Cards[0] = card;
            }
            else
            {
                Cards[1] = card;
            }
            
            if(IsBothCardsSet)
            {
                Sort();
                RankingHand();
            }
        }

        public void RankingHand()
        {
            if (this.IsStraightFlush())
                HandScore = (int)PokerHand.StraightFlush;
            else if (this.IsFlush())
                HandScore = (int)PokerHand.Flush;
            else if (this.IsStraight())
                HandScore = (int)PokerHand.Straight;
            else if (this.IsOnePair())
                HandScore = (int)PokerHand.OnePair;
            else
                HandScore = (int)PokerHand.HighCard;
        }

        public bool IsGreater(Hand hand)
        {
            if (HighCard.Rank > hand.HighCard.Rank)
                return true;

            if (HighCard.Rank < hand.HighCard.Rank)
                return false;

            if (HighCard.Suit > hand.HighCard.Suit)
                return true;

            if (HighCard.Suit < hand.HighCard.Suit)
                return false;

            return false; //the rank and suit cannot be the same, so this shouldn't ever happen
        }
        
        public Card HighCard => Cards.GroupBy(x => x.Rank, y => y).OrderByDescending(x => x.Key).Select(x => x).First().First();

        //public Card LowCard => Cards.GroupBy(x => x.Rank, y => y).OrderByDescending(x => x.Key).Select(x => x).Last().First();

        private bool IsBothCardsSet => Cards[0] != null && Cards[1] != null;
    }
}
