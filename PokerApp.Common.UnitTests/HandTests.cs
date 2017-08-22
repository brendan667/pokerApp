using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerApp.Common.Enums;
using PokerApp.Common.Models;

namespace PokerApp.Common.UnitTests
{
    [TestClass]
    public class HandTests
    {
        [TestMethod]
        public void Hand_ToString()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Ace, Suit.Clubs), new Card(Rank.King, Suit.Clubs) });
            hand.ToString().Should().Be("King of Clubs\r\nAce of Clubs\r\n");
        }
        
        [TestMethod]
        public void Hand_Sort()
        {
            var highCard = new Card(Rank.Ace, Suit.Clubs);
            var lowCard = new Card(Rank.King, Suit.Clubs);
            var hand = new Hand(new Card[] { highCard, lowCard });

            hand.Cards[0].Should().Be(lowCard);
            hand.Cards[1].Should().Be(highCard);
        }
        
        [TestMethod]
        public void Hand_AddCard()
        {
            var highCard = new Card(Rank.Ace, Suit.Clubs);
            var lowCard = new Card(Rank.King, Suit.Clubs);
            var hand = new Hand();
            hand.AddCard(highCard);
            hand.AddCard(lowCard);

            hand.Cards[0].Should().Be(lowCard);
            hand.Cards[1].Should().Be(highCard);
        }
        
        [TestMethod]
        public void Hand_RankingHand()
        {
            var highCard = new Card(Rank.Ace, Suit.Clubs);
            var lowCard = new Card(Rank.King, Suit.Clubs);
            var hand = new Hand();
            hand.AddCard(highCard);
            hand.AddCard(lowCard);

            hand.HandScore.Should().Be((int)PokerHand.StraightFlush);
        }
        
        [TestMethod]
        public void Hand_IsGreater_FirstCardIsHigher()
        {
            var highCard = new Card(Rank.Ace, Suit.Clubs);
            var lowCard = new Card(Rank.King, Suit.Clubs);
            var hand = new Hand();
            hand.AddCard(highCard);
            hand.AddCard(lowCard);

            var hand2 = new Hand(new Card[] { new Card(Rank.Eight, Suit.Clubs), new Card(Rank.Seven, Suit.Clubs) });

            hand.IsGreater(hand2).Should().Be(true);
        }
        
        [TestMethod]
        public void Hand_IsGreater_SecondCardIsHigher()
        {
            var highCard = new Card(Rank.Six, Suit.Clubs);
            var lowCard = new Card(Rank.Five, Suit.Clubs);
            var hand = new Hand();
            hand.AddCard(highCard);
            hand.AddCard(lowCard);

            var hand2 = new Hand(new Card[] { new Card(Rank.Eight, Suit.Clubs), new Card(Rank.Seven, Suit.Clubs) });

            hand.IsGreater(hand2).Should().Be(false);
        }
        
        [TestMethod]
        public void Hand_IsGreater_FirstHandSuitHigher()
        {
            var highCard = new Card(Rank.Six, Suit.Clubs);
            var lowCard = new Card(Rank.Five, Suit.Clubs);
            var hand = new Hand();
            hand.AddCard(highCard);
            hand.AddCard(lowCard);

            var hand2 = new Hand(new Card[] { new Card(Rank.Six, Suit.Hearts), new Card(Rank.Five, Suit.Hearts) });

            hand.IsGreater(hand2).Should().Be(true);
        }

        [TestMethod]
        public void Hand_IsGreater_SecondHandSuitHigher()
        {
            var highCard = new Card(Rank.Six, Suit.Clubs);
            var lowCard = new Card(Rank.Five, Suit.Clubs);
            var hand = new Hand();
            hand.AddCard(highCard);
            hand.AddCard(lowCard);

            var hand2 = new Hand(new Card[] { new Card(Rank.Six, Suit.Spades), new Card(Rank.Five, Suit.Spades) });

            hand.IsGreater(hand2).Should().Be(false);
        }
        
        [TestMethod]
        public void Hand_HighCard()
        {
            var highCard = new Card(Rank.Six, Suit.Clubs);
            var lowCard = new Card(Rank.Five, Suit.Clubs);
            var hand = new Hand();
            hand.AddCard(highCard);
            hand.AddCard(lowCard);

            hand.HighCard.Should().Be(highCard);
        }
    }
}
