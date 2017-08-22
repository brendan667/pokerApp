using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerApp.Common.Enums;
using PokerApp.Common.Extensions;
using PokerApp.Common.Models;

namespace PokerApp.Common.UnitTests
{
    [TestClass]
    public class ExtensionsTests
    {
        #region IsStraight

        [TestMethod]
        public void Extensions_IsStraight_False()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Clubs), new Card(Rank.Three, Suit.Clubs) });
            var result = hand.IsStraight();

            result.Should().Be(false);
        }

        [TestMethod]
        public void Extensions_IsStraight_True()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Clubs), new Card(Rank.Ten, Suit.Clubs) });
            var result = hand.IsStraight();

            result.Should().Be(true);
        }

        #endregion

        #region IsFlush

        [TestMethod]
        public void Extensions_IsFlush_False()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Hearts), new Card(Rank.Three, Suit.Clubs) });
            var result = hand.IsFlush();

            result.Should().Be(false);
        }

        [TestMethod]
        public void Extensions_IsFlush_True()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Clubs), new Card(Rank.Ten, Suit.Clubs) });
            var result = hand.IsFlush();

            result.Should().Be(true);
        }

        #endregion

        #region IsOnePair

        [TestMethod]
        public void Extensions_IsOnePair_False()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Clubs), new Card(Rank.Three, Suit.Clubs) });
            var result = hand.IsOnePair();

            result.Should().Be(false);
        }

        [TestMethod]
        public void Extensions_IsOnePair_True()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Clubs), new Card(Rank.Nine, Suit.Hearts) });
            var result = hand.IsOnePair();

            result.Should().Be(true);
        }

        #endregion

        #region IsStraightFlush

        [TestMethod]
        public void Extensions_IsStraightFlush_IsFlush_ButNotStraightFlush()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Clubs), new Card(Rank.Three, Suit.Clubs) });
            var result = hand.IsStraightFlush();

            result.Should().Be(false);
        }

        [TestMethod]
        public void Extensions_IsStraightFlush_IsStright_ButNotStraightFlush()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Clubs), new Card(Rank.Ten, Suit.Hearts) });
            var result = hand.IsStraightFlush();

            result.Should().Be(false);
        }

        [TestMethod]
        public void Extensions_IsStraightFlusht_True()
        {
            var hand = new Hand(new Card[] { new Card(Rank.Nine, Suit.Clubs), new Card(Rank.Ten, Suit.Clubs) });
            var result = hand.IsStraightFlush();

            result.Should().Be(true);
        }

        #endregion
    }
}
