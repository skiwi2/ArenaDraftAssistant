namespace ArenaDraftAssistant.Model
{
    public class CardRarity
    {
        public string Description { get; }

        private CardRarity(string description)
        {
            Description = description;
        }

        public static CardRarity Free { get; } = new CardRarity("Free");
        public static CardRarity Common { get; } = new CardRarity("Common");
        public static CardRarity Rare { get; } = new CardRarity("Rare");
        public static CardRarity Epic { get; } = new CardRarity("Epic");
        public static CardRarity Legendary { get; } = new CardRarity("Legendary");
    }
}