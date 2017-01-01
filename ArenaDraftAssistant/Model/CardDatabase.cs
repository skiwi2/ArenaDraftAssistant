using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ArenaDraftAssistant.Model
{
    public class CardDatabase
    {
        private static readonly Lazy<ISet<Card>> LazyAllCards = new Lazy<ISet<Card>>(InitializeCards);

        public static ISet<Card> AllCards => LazyAllCards.Value;

        private static ISet<Card> InitializeCards()
        {
            using (var reader = new StreamReader(@"Resources/cards.collectible.json"))
            {
                return JsonConvert.DeserializeObject<ISet<Card>>(reader.ReadToEnd()).Where(card => card.CardType != CardType.Hero).ToImmutableHashSet();
            }
        }

        private static readonly Lazy<IDictionary<string, Card>> LazyIdToCardDictionary = 
            new Lazy<IDictionary<string, Card>>(() => AllCards.ToImmutableDictionary(card => card.Id));

        private static IDictionary<string, Card> IdToCardDictionary => LazyIdToCardDictionary.Value;

        public static Card GetCardById(string id) => IdToCardDictionary[id];
    }
}