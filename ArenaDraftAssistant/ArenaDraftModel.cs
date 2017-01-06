using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class ArenaDraftModel
    {
        public HeroClass SelectedHeroClass { get; }

        public ObservableCollection<Card> DraftableCards { get; }

        public ObservableCollection<ObservableCollection<KeyValuePair<int, double>>> DropProbabilitiesForManaCost { get; } = 
            new ObservableCollection<ObservableCollection<KeyValuePair<int, double>>>
        {
            new ObservableCollection<KeyValuePair<int, double>>(new KeyValuePair<int, double>[11]),
            new ObservableCollection<KeyValuePair<int, double>>(new KeyValuePair<int, double>[11]),
            new ObservableCollection<KeyValuePair<int, double>>(new KeyValuePair<int, double>[11]),
            new ObservableCollection<KeyValuePair<int, double>>(new KeyValuePair<int, double>[11]),
            new ObservableCollection<KeyValuePair<int, double>>(new KeyValuePair<int, double>[11]),
            new ObservableCollection<KeyValuePair<int, double>>(new KeyValuePair<int, double>[11])
        };

        public ObservableCollection<ArenaDraftPick> Picks { get; } = new ObservableCollection<ArenaDraftPick>();

        public int MaxPicks { get; }

        public ArenaDraftModel(HeroClass selectedHeroClass, int maxPicks)
        {
            SelectedHeroClass = selectedHeroClass;
            DraftableCards = new ObservableCollection<Card>(
                ArenaDraft.GetDraftableCardsForHeroClass(SelectedHeroClass).OrderBy(card => card.Name));
            MaxPicks = maxPicks;
        }
    }
}
