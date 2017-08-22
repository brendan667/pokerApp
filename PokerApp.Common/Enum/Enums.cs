namespace PokerApp.Common.Enums
{
    public enum Rank
    {
        None,
        Two,
        Three,
        Four,
        Five,
        Six,
        Seven,
        Eight,
        Nine,
        Ten,
        Jack,
        Queen,
        King,
        Ace
    }

    public enum Suit
    {
        None,
        Diamonds,
        Hearts,
        Clubs,
        Spades
    }

    public enum PokerHand
    {
        HighCard = 10,

        OnePair = 20,

        Straight = 30,

        Flush = 40,

        StraightFlush = 50
    }
}
