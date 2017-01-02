using System.Collections.Generic;
using System.Collections.ObjectModel;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class ArenaDraftModel
    {
        public HeroClass SelectedHeroClass { get; }

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

        public ArenaDraftModel(HeroClass selectedHeroClass)
        {
            SelectedHeroClass = selectedHeroClass;
        }
    }
}
