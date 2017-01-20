using System.Collections.Generic;
using CardsMap.Entity;

namespace CardsMap.Repository
{
    public interface IRepository
    {
        IList<Card> GetCards();
    }
}