using System;
using System.Collections.Generic;
using System.Text;
using CardsMap.Entity;

namespace CardsMap.Service
{
    public class CardService
    {
        private static FindCardResult FindFirstCardAndCheckForArrival(IList<Card> cards)
        {
            FindCardResult findCardResult = new FindCardResult();

            foreach (Card card in cards)
            {
                if (card.DepartureCard == null)
                {
                    findCardResult.FirstCard = card;
                }
                if (card.ArrivalCard == null)
                {
                    findCardResult.IsHasArrivalNull = true;
                }
            }

            return findCardResult;
        }

        private static bool CheckSortConditions(FindCardResult findCardResult)
        {
            if (findCardResult.FirstCard != null && findCardResult.IsHasArrivalNull)
            {
                return true;
            }
            Console.WriteLine("Ошибка! начальный либо конечный элемент не был найден, сортировка не возможна!");
            return false;
        }

        private static void Sort(Card currentCard, IList<Card> result)
        {
            if (currentCard.ArrivalCard != null)
            {
                result.Add(currentCard.ArrivalCard);
                Sort(currentCard.ArrivalCard, result);
            }
        }

        public static string GetCardInformation(IEnumerable<Card> cards)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Card card in cards)
            {
                sb.AppendFormat("Текущая карточка город {0}", card.CityName);
                sb.AppendFormat("Город отправления - {0}",
                    card.DepartureCard != null ? card.DepartureCard.CityName : "Пусто");
                sb.AppendFormat("Город прибытия - {0}",
                      card.ArrivalCard != null ? card.ArrivalCard.CityName : "Пусто");
            }

            return sb.ToString();
        }

        /// <summary>
        /// сортируем карточки
        /// </summary>
        /// <param name="cards"></param>
        /// <returns>отсортированный список</returns>
        public static IList<Card> SortCard(IList<Card> cards)
        {
            FindCardResult findCardResult = FindFirstCardAndCheckForArrival(cards);
            IList<Card> result = new List<Card>();
            if (!CheckSortConditions(findCardResult))
            {
                return null;
            }
            
            result.Add(findCardResult.FirstCard);

            if (findCardResult.FirstCard.ArrivalCard != null)
            {
                Sort(findCardResult.FirstCard, result);
            }

            return result;
        }
    }
}
