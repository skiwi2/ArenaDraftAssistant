using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace ArenaDraftAssistant.Model
{
    class ArenaDraft
    {
        public static ISet<Card> AllBannedCards { get; } = new HashSet<Card>
        {
            CardDatabase.GetCardById("EX1_112"),    // Gelbin Mekkatorque
            CardDatabase.GetCardById("PRO_001"),    // Elite Tauren Chieftain

            CardDatabase.GetCardById("OG_280"),     // C'Thun
            CardDatabase.GetCardById("OG_281"),     // Beckoner of Evil
            CardDatabase.GetCardById("OG_286"),     // Twilight Elder
            CardDatabase.GetCardById("OG_283"),     // C'Thun's Chosen
            CardDatabase.GetCardById("OG_293"),     // Dark Arakkoa
            CardDatabase.GetCardById("OG_339"),     // Skeram Cultist
            CardDatabase.GetCardById("OG_334"),     // Hooded Acolyte
            CardDatabase.GetCardById("OG_162"),     // Disciple of C'Thun
            CardDatabase.GetCardById("OG_282"),     // Blade of C'Thun
            CardDatabase.GetCardById("OG_284"),     // Twilight Geomancer
            CardDatabase.GetCardById("OG_255"),     // Doomcaller
            CardDatabase.GetCardById("OG_321"),     // Crazed Worshipper
            CardDatabase.GetCardById("OG_303"),     // Cult Sorcerer
            CardDatabase.GetCardById("OG_302"),     // Usher of Souls
            CardDatabase.GetCardById("OG_188"),     // Klaxxi Amber-Weaver
            CardDatabase.GetCardById("OG_301"),     // Ancient Shieldbearer
            CardDatabase.GetCardById("OG_096"),     // Twilight Darkmender
            CardDatabase.GetCardById("OG_131"),     // Twin Emperor Vek'lor

            CardDatabase.GetCardById("KAR_013"),    // Purify

            CardDatabase.GetCardById("LOE_002"),    // Forgotten Torch
            CardDatabase.GetCardById("GVG_002"),    // Snowchugger
            CardDatabase.GetCardById("OG_207"),     // Faceless Summoner
            CardDatabase.GetCardById("GVG_023"),    // Goblin Auto-Barber
            CardDatabase.GetCardById("AT_030"),     // Undercity Valiant
            CardDatabase.GetCardById("GVG_039"),    // Vitality Totem
            CardDatabase.GetCardById("EX1_243"),    // Dust Devil
            CardDatabase.GetCardById("EX1_244"),    // Totemic Might
            CardDatabase.GetCardById("CS2_041"),    // Ancestral Healing
            CardDatabase.GetCardById("GVG_066"),    // Dunemaul Shaman
            CardDatabase.GetCardById("EX1_587"),    // Windspeaker
            CardDatabase.GetCardById("GVG_077"),    // Anima Golem
            CardDatabase.GetCardById("NEW1_003"),   // Sacrificial Pact
            CardDatabase.GetCardById("LOE_007"),    // Curse of Rafaam
            CardDatabase.GetCardById("EX1_317"),    // Sense Demons
            CardDatabase.GetCardById("AT_023"),     // Void Crusher
            CardDatabase.GetCardById("LOE_116"),    // Reliquary Seeker
            CardDatabase.GetCardById("EX1_306"),    // Succubus
            CardDatabase.GetCardById("EX1_578"),    // Savagery
            CardDatabase.GetCardById("FP1_019"),    // Poison Seeds
            CardDatabase.GetCardById("EX1_158"),    // Soul of the Forest
            CardDatabase.GetCardById("EX1_155"),    // Mark of Nature
            CardDatabase.GetCardById("GVG_033"),    // Tree of Life
            CardDatabase.GetCardById("AT_043"),     // Astral Communion
            CardDatabase.GetCardById("EX1_084"),    // Warsong Commander
            CardDatabase.GetCardById("AT_086"),     // Bolster
            CardDatabase.GetCardById("CS2_103"),    // Charge
            CardDatabase.GetCardById("GVG_050"),    // Bouncing Blade
            CardDatabase.GetCardById("BRM_016"),    // Axe Flinger
            CardDatabase.GetCardById("CS2_104"),    // Rampage
            CardDatabase.GetCardById("GVG_054"),    // Ogre Warmaul
            CardDatabase.GetCardById("CS2_237"),    // Starving Buzzard
            CardDatabase.GetCardById("GVG_017"),    // Call Pet
            CardDatabase.GetCardById("DS1_175"),    // Timber Wolf
            CardDatabase.GetCardById("GVG_073"),    // Cobra Shot
            CardDatabase.GetCardById("AT_061"),     // Lock and Load
            CardDatabase.GetCardById("LOE_021"),    // Dart Trap
            CardDatabase.GetCardById("EX1_609"),    // Snipe
            CardDatabase.GetCardById("DS1_233"),    // Mind Blast
            CardDatabase.GetCardById("GVG_009"),    // Shadowbomber
            CardDatabase.GetCardById("EX1_341"),    // Lightwell
            CardDatabase.GetCardById("AT_013"),     // Power Word: Glory
            CardDatabase.GetCardById("AT_016"),     // Confuse
            CardDatabase.GetCardById("AT_015"),     // Convert
            CardDatabase.GetCardById("CS1_129")     // Inner Fire
        }.ToImmutableHashSet();

        public static double ProbabilityOfXDropByTurnX(int manaCost, int cardsInOpeningHand, int mulliganAmount, int xDropsInDeck, int cardsInDeck = 30)
        {
            if (manaCost < 0 || manaCost > 10)
            {
                throw new ArgumentException($"{nameof(manaCost)} should be between 0 and 10");
            }
            if (cardsInOpeningHand < 0 || cardsInOpeningHand > cardsInDeck + manaCost)
            {
                throw new ArgumentException($"{nameof(cardsInOpeningHand)} should be between 0 and {nameof(cardsInDeck)} - {nameof(manaCost)}");
            }
            if (mulliganAmount < 0 || mulliganAmount > cardsInOpeningHand)
            {
                throw new ArgumentException($"{nameof(mulliganAmount)} should be between 0 and {nameof(cardsInOpeningHand)}");
            }
            if (xDropsInDeck < 0 || xDropsInDeck > cardsInDeck)
            {
                throw new ArgumentException($"{nameof(xDropsInDeck)} should be between 0 and {nameof(cardsInDeck)}");
            }
            if (cardsInDeck < mulliganAmount || cardsInDeck < xDropsInDeck)
            {
                throw new ArgumentException($"{nameof(cardsInDeck)} should be greater or equal to {nameof(mulliganAmount)} and {nameof(xDropsInDeck)}");
            }

            var noSuccessInOpeningHand = Hypergeometric.PMF(cardsInDeck, xDropsInDeck, cardsInOpeningHand, 0);
            var noSuccessAfterMulligan = Hypergeometric.PMF(cardsInDeck - cardsInOpeningHand, xDropsInDeck, mulliganAmount, 0);
            var noSuccessInFirstXDrops = Hypergeometric.PMF(cardsInDeck - cardsInOpeningHand, xDropsInDeck, manaCost, 0);

            var successInOpeningHand = 1d - noSuccessInOpeningHand;
            var successAfterMulligan = 1d - noSuccessAfterMulligan;
            var successInFirstXDrops = 1d - noSuccessInFirstXDrops;

            return successInOpeningHand + (noSuccessInOpeningHand * successAfterMulligan) + (noSuccessInOpeningHand * noSuccessAfterMulligan * successInFirstXDrops);
        }
    }
}
