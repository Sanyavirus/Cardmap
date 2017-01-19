using System.Collections;
using System.Collections.Generic;

namespace CardsMap
{
    public class CardComparer : IComparer<Card>
    {
        public int Compare(Card x, Card y)
        {
            //if (x.NextCard != null && y.PrevCard != null
            //    && x.NextCard.Equals(y.PrevCard))
            //{
            //    return 1;
            //}
            //else
            //{
            //    return -1;
            //}
            return -1;
        }
    }
}