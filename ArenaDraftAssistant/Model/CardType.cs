namespace ArenaDraftAssistant.Model
{
    public class CardType
    {
        private CardType()
        {
            
        }

        public static CardType Minion = new CardType();
        public static CardType Spell = new CardType();
        public static CardType Weapon = new CardType();
        public static CardType Hero = new CardType();
    }
}