using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerApp.Common.Models;

namespace PokerApp.Common.UnitTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void Player_CTOR()
        {
            var player = new Player(1);
            player.Index.Should().Be(1);
            player.Score.Should().Be(0);
        }
    }
}
