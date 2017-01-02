using System.Collections.Generic;
using System.Collections.Immutable;

namespace ArenaDraftAssistant.Model
{
    public class Card
    {
        public string Id { get; }

        public string Name { get; }

        public int ManaCost { get; }

        public IList<HeroClass> HeroClasses { get; }

        public CardType CardType { get; }

        public CardRarity CardRarity { get; }

        public CardSet CardSet { get; }

        public Card(string id, string name, int manaCost, IList<HeroClass> heroClasses, CardType cardType, CardRarity cardRarity, CardSet cardSet)
        {
            Id = id;
            Name = name;
            ManaCost = manaCost;
            HeroClasses = heroClasses.ToImmutableList();
            CardType = cardType;
            CardRarity = cardRarity;
            CardSet = cardSet;
        }

        protected bool Equals(Card other)
        {
            return string.Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Card) obj);
        }

        public override int GetHashCode()
        {
            return Id?.GetHashCode() ?? 0;
        }
    }
}