namespace CardsMap
{
    public class FindResult
    {
        Card firstCard = null;
        bool isHasArrivalNull = false;

        public Card FirstCard
        {
            get { return firstCard; }
            set { firstCard = value; }
        }

        public bool IsHasArrivalNull
        {
            get { return isHasArrivalNull; }
            set { isHasArrivalNull = value; }
        }
        
    }
}