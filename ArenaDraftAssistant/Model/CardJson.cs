using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace ArenaDraftAssistant.Model
{
    public class CardJson
    {
        [JsonProperty("id")]
        private string Id { get; set; }

        [JsonProperty("name")]
        private string Name { get; set; }

        [JsonProperty("cost")]
        private int ManaCost { get; set; }

        [JsonProperty("playerClass")]
        private string PlayerClass { get; set; }

        [JsonProperty("classes")]
        private IList<string> Classes { get; set; }

        [JsonProperty("type")]
        private string Type { get; set; }

        [JsonProperty("rarity")]
        private string Rarity { get; set; }

        [JsonProperty("set")]
        private string Set { get; set; }

        public Card ToCard()
        {
            return new Card(
                Id,
                Name,
                ManaCost,
                CalculateHeroClasses(),
                StringToCardTypeDictionary[Type],
                StringToCardRarityDictionary[Rarity],
                StringToCardSetDictionary[Set]
            );
        }

        private IList<HeroClass> CalculateHeroClasses()
        {
            if (Classes?.Count > 0)
            {
                return Classes.SelectMany(clas => StringToHeroClassDictionary[clas]).ToList();
            }
            return StringToHeroClassDictionary[PlayerClass];
        }

        private static IDictionary<string, IList<HeroClass>> StringToHeroClassDictionary { get; } = new Dictionary<string, IList<HeroClass>>
        {
            ["DRUID"] = new List<HeroClass> { HeroClass.Druid },
            ["HUNTER"] = new List<HeroClass> { HeroClass.Hunter },
            ["MAGE"] = new List<HeroClass> { HeroClass.Mage },
            ["PALADIN"] = new List<HeroClass> { HeroClass.Paladin },
            ["PRIEST"] = new List<HeroClass> { HeroClass.Priest },
            ["ROGUE"] = new List<HeroClass> { HeroClass.Rogue },
            ["SHAMAN"] = new List<HeroClass> { HeroClass.Shaman },
            ["WARLOCK"] = new List<HeroClass> { HeroClass.Warlock },
            ["WARRIOR"] = new List<HeroClass> { HeroClass.Warrior },
            ["NEUTRAL"] = HeroClass.AllHeroClasses
        };

        private static IDictionary<string, CardType> StringToCardTypeDictionary { get; } = new Dictionary<string, CardType>
        {
            ["MINION"] = CardType.Minion,
            ["SPELL"] = CardType.Spell,
            ["WEAPON"] = CardType.Weapon,
            ["HERO"] = CardType.Hero
        };

        private static IDictionary<string, CardRarity> StringToCardRarityDictionary { get; } = new Dictionary<string, CardRarity>
        {
            ["FREE"] = CardRarity.Free,
            ["COMMON"] = CardRarity.Common,
            ["RARE"] = CardRarity.Rare,
            ["EPIC"] = CardRarity.Epic,
            ["LEGENDARY"] = CardRarity.Legendary
        };

        private static IDictionary<string, CardSet> StringToCardSetDictionary { get; } = new Dictionary<string, CardSet>
        {
            ["PROMO"] = CardSet.Promo,
            ["REWARD"] = CardSet.Reward,
            ["CORE"] = CardSet.Basic,
            ["EXPERT1"] = CardSet.Classic,
            ["NAXX"] = CardSet.CurseOfNaxxramas,
            ["GVG"] = CardSet.GoblinsVsGnomes,
            ["BRM"] = CardSet.BlackrockMountain,
            ["TGT"] = CardSet.TheGrandTournament,
            ["LOE"] = CardSet.LeagueOfExplorers,
            ["OG"] = CardSet.WhispersOfTheOldGods,
            ["KARA"] = CardSet.OneNightInKarazhan,
            ["GANGS"] = CardSet.MeanStreetsOfGadgetzan,
            ["HERO_SKINS"] = null
        };
    }
}