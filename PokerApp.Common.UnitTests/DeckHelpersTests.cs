using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerApp.Common.Enums;
using PokerApp.Common.Helper;

namespace PokerApp.Common.UnitTests
{
    [TestClass]
    public class DeckHelpersTests
    {
        [TestMethod]
        public void Test()
        {
            var deck = DeckHelpers.CreateNewDeck();
            deck[0].Rank.Should().Be(Rank.Two);
            deck[0].Suit.Should().Be(Suit.Diamonds);
        }
    }
}
