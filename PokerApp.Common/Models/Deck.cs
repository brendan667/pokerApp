using System;
using System.Linq;
using System.Text;

namespace PokerApp.Common.Models
{
    public class Deck
    {
        private int currentIndex = 0;
        public Card[] Cards { get; set; }

        public Deck(Card[] cards)
        {
            Cards = cards;
        }

        public override string ToString()
        {
            return Cards.Aggregate(new StringBuilder(),
                  (sb, a) => sb.AppendLine(String.Join(",", a)),
                  sb => sb.ToString()); ;
        }

        //  https://blog.codinghorror.com/shuffling/
        public void Shuffle()
        {
            currentIndex = 0;
            Cards = Cards.OrderBy(x => Guid.NewGuid()).ToArray();
        }

        public Card DealCard()
        {
            return Cards[currentIndex++];
        }
    }
}
