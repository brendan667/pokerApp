using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokerApp.Common.Helper;
using PokerApp.Common.Models;
using System.Collections.Generic;
using System.Linq;

namespace PokerApp.Common.UnitTests
{
    [TestClass]
    public class DeckTests
    {
        [TestMethod]
        public void Deck_ToString()
        {
            //Generate a new deck 1000 times to show that each new deck is in same order
            Deck testingDeck = new Deck(DeckHelpers.CreateNewDeck());
            var fullToString = testingDeck.ToString();
            for (int i = 0; i < 1000; i++)
            {
                testingDeck = new Deck(DeckHelpers.CreateNewDeck());
                fullToString.Should().Be(testingDeck.ToString());
                fullToString = testingDeck.ToString();
            }
        }

        /// <summary>
        /// There is a small chance this could not pass...the chances are quite small though with 52! combinations
        /// </summary>
        [TestMethod]
        public void Deck_Shuffle_DifferentOrderEachTime()
        {
            //Generate a new deck 1000 times
            Deck testingDeck;
            var listOfFullToStrings = new List<string>();
            for (int i = 0; i < 100000; i++)
            {
                testingDeck = new Deck(DeckHelpers.CreateNewDeck());
                testingDeck.Shuffle();
                listOfFullToStrings.Add(testingDeck.ToString());   
            }
            listOfFullToStrings.Distinct().Count().Should().Be(100000);
        }
        
        [TestMethod]
        public void Deck_DealCard()
        {
            //Generate a new deck 1000 times
            Deck testingDeck = new Deck(DeckHelpers.CreateNewDeck());
            testingDeck.Shuffle();
            var firstCard = testingDeck.Cards[0];
            var secondCard = testingDeck.Cards[1];

            var dealFirstCard = testingDeck.DealCard();
            var dealSecondCard = testingDeck.DealCard();

            firstCard.Should().Be(dealFirstCard);
            secondCard.Should().Be(dealSecondCard);
        }
    }
}
