namespace ArenaDraftAssistant.Model
{
    public class CardSet
    {
        private CardSet()
        {
            
        }

        public static readonly CardSet Promo = new CardSet();
        public static readonly CardSet Reward = new CardSet();
        public static readonly CardSet Basic = new CardSet();
        public static readonly CardSet Classic = new CardSet();
        public static readonly CardSet CurseOfNaxxramas = new CardSet();
        public static readonly CardSet GoblinsVsGnomes = new CardSet();
        public static readonly CardSet BlackrockMountain = new CardSet();
        public static readonly CardSet TheGrandTournament = new CardSet();
        public static readonly CardSet LeagueOfExplorers = new CardSet();
        public static readonly CardSet WhispersOfTheOldGods = new CardSet();
        public static readonly CardSet OneNightInKarazhan = new CardSet();
        public static readonly CardSet MeanStreetsOfGadgetzan = new CardSet();
    }
}