using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace ArenaDraftAssistant.Model
{
    public class CardList
    {
        private static readonly Lazy<IList<Card>> LazyAllCards = new Lazy<IList<Card>>(InitializeCards);

        public static IList<Card> AllCards => LazyAllCards.Value;

        private static IList<Card> InitializeCards()
        {
            using (var reader = new StreamReader(@"Resources/cards.collectible.json"))
            {
                return JsonConvert.DeserializeObject<List<Card>>(reader.ReadToEnd()).Where(card => card.CardType != CardType.Hero).ToImmutableList();
            }
        }
    }
}