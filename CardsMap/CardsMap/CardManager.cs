using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardsMap
{
    public class CardManager
    {
    
        private static FindResult FindFirstCardAndCheckForArrival(IList<Card> cards)
        {
            FindResult findResult = new FindResult();

            foreach (Card card in cards)
            {
                if (card.DepartureCard == null)
                {
                    findResult.FirstCard = card;
                }
                if (card.ArrivalCard == null)
                {
                    findResult.IsHasArrivalNull = true;
                }
            }

            return findResult;
        }

        private static bool CheckSortConditions(FindResult findResult)
        {
            if (findResult.FirstCard != null && findResult.IsHasArrivalNull)
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
                currentCard = currentCard.ArrivalCard;
                Sort(currentCard, result);
            }
        }
        
        /// <summary>
        /// сортируем карточки
        /// </summary>
        /// <param name="cards"></param>
        /// <returns>отсортированный список</returns>
        public static IList<Card> SortCard(IList<Card> cards)
        {
            FindResult findResult = FindFirstCardAndCheckForArrival(cards);
            IList<Card> result = new List<Card>();
            if (!CheckSortConditions(findResult))
            {
                return null;
            }

            result.Add(findResult.FirstCard);

            if (findResult.FirstCard.ArrivalCard != null)
            {
                Sort(findResult.FirstCard, result);
            }

            return result;
        }
    }
}
