﻿using System;
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

        [JsonProperty("rarity")]
        private string Rarity { get; set; }

        [JsonProperty("set")]
        private string Set { get; set; }

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

        private static IDictionary<string, CardRarity> StringToCardRarityDictionary { get; } = new Dictionary<string, CardRarity>
        {
            ["FREE"] = CardRarity.Free,
            ["COMMON"] = CardRarity.Common,
            ["RARE"] = CardRarity.Rare,
            ["EPIC"] = CardRarity.Epic,
            ["LEGENDARY"] = CardRarity.Legendary
        };

        private readonly Lazy<CardRarity> _cardRarity;

        public CardRarity CardRarity => _cardRarity.Value;

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
            ["GANGS"] = CardSet.MeanStreetsOfGadgetzan
        };

        private readonly Lazy<CardSet> _cardSet;

        public CardSet CardSet => _cardSet.Value;

        public Card()
        {
            _heroClasses = new Lazy<IList<HeroClass>>(CalculateHeroClasses);

            _cardType = new Lazy<CardType>(() => StringToCardTypeDictionary[Type]);

            _cardRarity = new Lazy<CardRarity>(() => StringToCardRarityDictionary[Rarity]);

            _cardSet = new Lazy<CardSet>(() => StringToCardSetDictionary[Set]);
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