using PokerApp.Common.Models;

namespace PokerApp.Common.Extensions
{
    public static class Extensions
    {
        public static bool IsStraight(this Hand hand)
        {
            if (hand.Cards[0].Rank == hand.Cards[1].Rank - 1)
                return true;

            return false;
        }

        public static bool IsFlush(this Hand hand)
        {
            if (hand.Cards[0].Suit == hand.Cards[1].Suit)
                return true;

            return false;
        }

        public static bool IsOnePair(this Hand hand)
        {
            if (hand.Cards[0].Rank == hand.Cards[1].Rank)
                return true;

            return false;
        }

        public static bool IsStraightFlush(this Hand hand)
        {
            if (IsStraight(hand) && IsFlush(hand))
                return true;

            return false;
        }
    }
}
