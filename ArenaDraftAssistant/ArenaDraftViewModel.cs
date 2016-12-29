using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class ArenaDraftViewModel : ViewModelBase
    {
        public ArenaDraftModel Model { get; }

        public ArenaDraftViewModel(ArenaDraftModel model)
        {
            Model = model;
        }

        public HeroClass SelectedHeroClass => Model.SelectedHeroClass;

        public ObservableCollection<ObservableCollection<KeyValuePair<int, double>>> DropProbabilitiesForManaCost => Model.DropProbabilitiesForManaCost;
    }
}
