namespace ArenaDraftAssistant.Model
{
    public class CardRarity
    {
        private CardRarity()
        {
            
        }

        public static CardRarity Free { get; } = new CardRarity();
        public static CardRarity Common { get; } = new CardRarity();
        public static CardRarity Rare { get; } = new CardRarity();
        public static CardRarity Epic { get; } = new CardRarity();
        public static CardRarity Legendary { get; } = new CardRarity();
    }
}