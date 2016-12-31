namespace ArenaDraftAssistant.Model
{
    public class CardRarity
    {
        private CardRarity()
        {
            
        }

        public static CardRarity Free = new CardRarity();
        public static CardRarity Common = new CardRarity();
        public static CardRarity Rare = new CardRarity();
        public static CardRarity Epic = new CardRarity();
        public static CardRarity Legendary = new CardRarity();
    }
}