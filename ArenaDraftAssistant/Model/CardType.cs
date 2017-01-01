namespace ArenaDraftAssistant.Model
{
    public class CardType
    {
        public string Description { get; }

        private CardType(string description)
        {
            Description = description;
        }

        public static CardType Minion { get; } = new CardType("Minion");
        public static CardType Spell { get; } = new CardType("Spell");
        public static CardType Weapon { get; } = new CardType("Weapon");
        public static CardType Hero { get; } = new CardType("Hero");
    }
}