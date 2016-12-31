using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Newtonsoft.Json;

namespace ArenaDraftAssistant.Model
{
    public class Card
    {
        [JsonProperty("id")]
        public string Id { get; private set; }

        [JsonProperty("name")]
        public string Name { get; private set; }

        [JsonProperty("cost")]
        public int ManaCost { get; private set; }

        [JsonProperty("playerClass")]
        private string PlayerClass { get; set; }

        [JsonProperty("classes")]
        private IList<string> Classes { get; set; }

        [JsonProperty("type")]
        private string Type { get; set; }

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

        private readonly Lazy<IList<HeroClass>> _heroClasses;

        public IList<HeroClass> HeroClasses => _heroClasses.Value;

        private static IDictionary<string, CardType> StringToCardTypeDictionary { get; } = new Dictionary<string, CardType>
        {
            ["MINION"] = CardType.Minion,
            ["SPELL"] = CardType.Spell,
            ["WEAPON"] = CardType.Weapon,
            ["HERO"] = CardType.Hero
        };

        private readonly Lazy<CardType> _cardType;

        public CardType CardType => _cardType.Value;

        public Card()
        {
            _heroClasses = new Lazy<IList<HeroClass>>(CalculateHeroClasses);

            _cardType = new Lazy<CardType>(() => StringToCardTypeDictionary[Type]);
        }

        private IList<HeroClass> CalculateHeroClasses()
        {
            if (Classes?.Count > 0)
            {
                return Classes.SelectMany(clas => StringToHeroClassDictionary[clas]).ToImmutableList();
            }
            return StringToHeroClassDictionary[PlayerClass].ToImmutableList();
        }
    }
}