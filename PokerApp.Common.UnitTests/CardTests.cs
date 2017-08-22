using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerApp.Common.Enums;
using PokerApp.Common.Models;
using System.Linq;

namespace PokerApp.Common.UnitTests
{
    [TestClass]
    public class CardTests
    {
        [TestMethod]
        public void Card_ToString()
        {
            var card = new Card(Rank.Ace, Suit.Clubs);
            var toString = card.ToString();

            toString.Should().Be("Ace of Clubs");
        }

        [TestMethod]
        public void Card_Compare()
        {
            var lowCard = new Card(Rank.King, Suit.Clubs);
            var highCard = new Card(Rank.Ace, Suit.Clubs);

            var cards = new Card[] { highCard, lowCard };
            var hand = new Hand(cards);
            hand.Sort();

            hand.Cards.First().Should().Be(lowCard);
            hand.Cards.Last().Should().Be(highCard);
        }

        [TestMethod]
        public void Card_Compare_MoreThan2Cards()
        {
            var lowCard = new Card(Rank.Two, Suit.Clubs);
            var highCard = new Card(Rank.Ace, Suit.Clubs);
            var middleCard = new Card(Rank.Seven, Suit.Clubs);

            var cards = new Card[] { highCard, lowCard, middleCard };
            var hand = new Hand(cards);
            hand.Sort();

            hand.Cards.First().Should().Be(lowCard);
            hand.Cards.Skip(1).Take(1).First().Should().Be(middleCard);
            hand.Cards.Last().Should().Be(highCard);
        }
    }
}
