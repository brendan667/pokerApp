namespace PokerApp.Common.Models
{
    public class Player
    {
        public Hand Hand { get; set; }

        public int Score { get; set; }
        public int Index { get; set; }

        public Player(int index)
        {
            Index = index;
            Score = 0;
        }
    }
}
