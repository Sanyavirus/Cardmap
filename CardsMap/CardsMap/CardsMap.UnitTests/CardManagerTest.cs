using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardsMap.Entity;
using CardsMap.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardsMap.UnitTests
{
    [TestClass]
    public class CardManagerTest
    {
        private List<Card> InitializeCards()
        {
            List<Card> cards = new List<Card>();

            Card parisCard = new Card("Париж");

            Card moscowCard = new Card("Москва");

            Card melburnCard = new Card("Мельбурн");

            Card kolnCard = new Card("Кёльн");

            moscowCard.ArrivalCard = parisCard;
            moscowCard.DepartureCard = kolnCard;
            cards.Add(moscowCard);

            parisCard.ArrivalCard = null;
            parisCard.DepartureCard = moscowCard;
            cards.Add(parisCard);

            kolnCard.ArrivalCard = moscowCard;
            kolnCard.DepartureCard = melburnCard;
            cards.Add(kolnCard);

            melburnCard.DepartureCard = null;
            melburnCard.ArrivalCard = kolnCard;
            cards.Add(melburnCard);

            return cards;
        }

        private bool CheckCards(IList<Card> cards)
        {
            if (cards == null || cards.Count != 4)
            {
                return false;
            }
            if (!cards[0].ArrivalCard.CityName.Equals("Кёльн"))
            {
                return false;
            }
            if (!cards[1].ArrivalCard.CityName.Equals("Москва"))
            {
                return false;
            }
            if (!cards[2].ArrivalCard.CityName.Equals("Париж"))
            {
                return false;
            }
            if (cards[3].ArrivalCard != null)
            {
                return false;
            }

            return true;
        } 
         
        [TestMethod]
        public void SortCard_Test()
        {
            //Arrange
            List<Card> cards = InitializeCards();
            List<Card> result = new List<Card>();
            //Act
            result = CardService.SortCard(cards).ToList();
            //Assert
            Assert.IsTrue(CheckCards(result));
        }

    }
}
