namespace ArenaDraftAssistant.Model
{
    public class CardType
    {
        private CardType()
        {
            
        }

        public static CardType Minion { get; } = new CardType();
        public static CardType Spell { get; } = new CardType();
        public static CardType Weapon { get; } = new CardType();
        public static CardType Hero { get; } = new CardType();
    }
}