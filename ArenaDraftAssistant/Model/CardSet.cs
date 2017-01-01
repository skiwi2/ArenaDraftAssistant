using System.Collections.Generic;
using System.Collections.Immutable;

namespace ArenaDraftAssistant.Model
{
    public class CardSet
    {
        public string Name { get; }

        private CardSet(string name)
        {
            Name = name;
        }

        public static CardSet Promo { get; } = new CardSet("Promo");
        public static CardSet Reward { get; }= new CardSet("Reward");
        public static CardSet Basic { get; }= new CardSet("Basic");
        public static CardSet Classic { get; } = new CardSet("Classic");
        public static CardSet CurseOfNaxxramas { get; } = new CardSet("Curse of Naxxramas");
        public static CardSet GoblinsVsGnomes { get; } = new CardSet("Goblins vs Gnomes");
        public static CardSet BlackrockMountain { get; } = new CardSet("Blackrock Mountain");
        public static CardSet TheGrandTournament { get; } = new CardSet("The Grand Tournament");
        public static CardSet LeagueOfExplorers { get; } = new CardSet("League of Explorers");
        public static CardSet WhispersOfTheOldGods { get; } = new CardSet("Whispers of the Old Gods");
        public static CardSet OneNightInKarazhan { get; } = new CardSet("One Night in Karazhan");
        public static CardSet MeanStreetsOfGadgetzan { get; } = new CardSet("Mean Streets of Gadgetzan");

        public static IList<CardSet> AllCardSets { get; } = new List<CardSet>
        {
            Promo,
            Reward,
            Basic,
            Classic,
            CurseOfNaxxramas,
            GoblinsVsGnomes,
            BlackrockMountain,
            TheGrandTournament,
            LeagueOfExplorers,
            WhispersOfTheOldGods,
            OneNightInKarazhan,
            MeanStreetsOfGadgetzan
        }.ToImmutableList();
    }
}