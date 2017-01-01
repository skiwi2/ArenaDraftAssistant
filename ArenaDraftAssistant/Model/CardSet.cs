namespace ArenaDraftAssistant.Model
{
    public class CardSet
    {
        private CardSet()
        {
            
        }

        public static CardSet Promo { get; } = new CardSet();
        public static CardSet Reward { get; }= new CardSet();
        public static CardSet Basic { get; }= new CardSet();
        public static CardSet Classic { get; } = new CardSet();
        public static CardSet CurseOfNaxxramas { get; } = new CardSet();
        public static CardSet GoblinsVsGnomes { get; } = new CardSet();
        public static CardSet BlackrockMountain { get; } = new CardSet();
        public static CardSet TheGrandTournament { get; } = new CardSet();
        public static CardSet LeagueOfExplorers { get; } = new CardSet();
        public static CardSet WhispersOfTheOldGods { get; } = new CardSet();
        public static CardSet OneNightInKarazhan { get; } = new CardSet();
        public static CardSet MeanStreetsOfGadgetzan { get; } = new CardSet();
    }
}