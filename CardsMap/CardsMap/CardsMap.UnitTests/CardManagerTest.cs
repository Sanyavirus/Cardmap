using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CardsMap.Entity;
using CardsMap.Repository;
using CardsMap.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardsMap.UnitTests
{
    [TestClass]
    public class CardManagerTest
    {


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
            IRepository repository = new FakeRepository();
            IList<Card> cards = repository.GetCards();
            IList<Card> result = new List<Card>();
            //Act
            result = CardService.SortCard(cards).ToList();
            //Assert
            Assert.IsTrue(CheckCards(result));
        }

    }
}
