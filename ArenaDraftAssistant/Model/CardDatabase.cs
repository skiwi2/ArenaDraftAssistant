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
        public static ISet<Card> AllCards => InitializeCards();

        private static ISet<Card> InitializeCards()
        {
            using (var reader = new StreamReader(@"Resources/cards.collectible.json"))
            {
                return JsonConvert.DeserializeObject<ISet<Card>>(reader.ReadToEnd()).Where(card => card.CardType != CardType.Hero).ToImmutableHashSet();
            }
        }

        private static IDictionary<string, Card> IdToCardDictionary => AllCards.ToImmutableDictionary(card => card.Id);

        public static Card GetCardById(string id) => IdToCardDictionary[id];
    }
}