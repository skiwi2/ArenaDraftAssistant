using System.Collections.Generic;
using System.Collections.Immutable;

namespace ArenaDraftAssistant.Model
{
    public class ArenaDraftPick
    {
        public ImmutableDictionary<ArenaDraftPickOption, Card> Cards { get; }

        public ArenaDraftPickOption SelectedOption { get; }

        public Card SelectedCard => Cards[SelectedOption];

        public ArenaDraftPick(Card card1, Card card2, Card card3, ArenaDraftPickOption selectedOption)
        {
            Cards = new Dictionary<ArenaDraftPickOption, Card>
            {
                [ArenaDraftPickOption.One] = card1,
                [ArenaDraftPickOption.Two] = card2,
                [ArenaDraftPickOption.Three] = card3
            }.ToImmutableDictionary();
            SelectedOption = selectedOption;
        }
    }
}