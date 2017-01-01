using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaDraftAssistant.Model
{
    public class HeroClass
    {
        public string Name { get; }

        private readonly Lazy<ISet<Card>> _allAvailableCards;

        public ISet<Card> AllAvailableCards => _allAvailableCards.Value;

        private HeroClass(string name)
        {
            Name = name;
            _allAvailableCards = new Lazy<ISet<Card>>(CalculateAllAvailableCards);
        }

        private ISet<Card> CalculateAllAvailableCards()
        {
            return CardDatabase.AllCards.Where(card => card.HeroClasses.Contains(this)).ToImmutableHashSet();
        }

        public static HeroClass Druid { get; } = new HeroClass("Druid");
        public static HeroClass Hunter { get; } = new HeroClass("Hunter");
        public static HeroClass Mage { get; } = new HeroClass("Mage");
        public static HeroClass Paladin { get; } = new HeroClass("Paladin");
        public static HeroClass Priest { get; } = new HeroClass("Priest");
        public static HeroClass Rogue { get; } = new HeroClass("Rogue");
        public static HeroClass Shaman { get; } = new HeroClass("Shaman");
        public static HeroClass Warlock { get; } = new HeroClass("Warlock");
        public static HeroClass Warrior { get; } = new HeroClass("Warrior");

        public static IList<HeroClass> AllHeroClasses { get; } = new List<HeroClass>
        {
            Druid,
            Hunter,
            Mage,
            Paladin,
            Priest,
            Rogue,
            Shaman,
            Warlock,
            Warrior
        }.ToImmutableList();
    }
}
