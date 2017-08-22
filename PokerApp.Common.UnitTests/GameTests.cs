using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerApp.Common.Enums;
using PokerApp.Common.Models;

namespace PokerApp.Common.UnitTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Game_CTOR()
        {
            var game = new Game(1, 1);
            game.Players.Length.Should().Be(1);
            game.Players[0].Hand.Should().NotBeNull();
        }

        [TestMethod]
        public void Game_NewHand()
        {
            var game = new Game(1, 1);
            game.Players[0].Hand.HandScore = 5;
            game.NewHand();
            game.Players.Length.Should().Be(1);
            game.Players[0].Hand.Should().NotBeNull();
        }

        [TestMethod]
        public void Game_ResolveCloseHands()
        {
            var game = new Game(3, 1);

            game.Players[0].Hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            game.Players[0].Hand.AddCard(new Card(Rank.King, Suit.Clubs));

            game.Players[1].Hand.AddCard(new Card(Rank.King, Suit.Clubs));
            game.Players[1].Hand.AddCard(new Card(Rank.Queen, Suit.Clubs));

            game.Players[2].Hand.AddCard(new Card(Rank.Ace, Suit.Spades));
            game.Players[2].Hand.AddCard(new Card(Rank.King, Suit.Spades));

            game.ResolveCloseHands();

            game.Players[0].Hand.HandScore.Should().Be((int)PokerHand.StraightFlush+1);
            game.Players[1].Hand.HandScore.Should().Be((int)PokerHand.StraightFlush);
            game.Players[2].Hand.HandScore.Should().Be((int)PokerHand.StraightFlush+1);
        }

        [TestMethod]
        public void Game_PlayerHands()
        {
            var game = new Game(1, 1);

            game.Players[0].Hand.AddCard(new Card(Rank.Ace, Suit.Clubs));
            game.Players[0].Hand.AddCard(new Card(Rank.King, Suit.Clubs));

            game.PlayerHands.Should().Be("Player: 1's hand\r\nKing of Clubs\r\nAce of Clubs");
        }
    }
}
