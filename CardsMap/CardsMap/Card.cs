using System;

namespace CardsMap
{
    public class Card 
    {
        private string cityName;
        private Card arrivalCard;
        private Card departureCard;

    #region public props
        public string CityName
        {
            get { return cityName; }
            set { cityName = value; }
        }

        public Card ArrivalCard
        {
            get { return arrivalCard; }
            set { arrivalCard = value; }
        }

        public Card DepartureCard
        {
            get { return departureCard; }
            set { departureCard = value; }
        }
        #endregion

    #region public Ctors

        public Card() { }
        public Card(string cityName)
        {
            this.cityName = cityName;
        }
        
     #endregion

    }
}