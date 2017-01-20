using System.Collections.Generic;
using CardsMap.Entity;

namespace CardsMap.Repository
{
    public class FakeRepository : IRepository
    {
        public IList<Card> GetCards()
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
    }
}