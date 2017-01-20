using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardsMap.Entity;
using CardsMap.Repository;
using CardsMap.Service;

namespace CardsMap
{
    class Program
    {
        static void Main(string[] args)
        {
            IRepository repo = new FakeRepository();
            IList<Card> cards = repo.GetCards();
            

        }
    }
}
