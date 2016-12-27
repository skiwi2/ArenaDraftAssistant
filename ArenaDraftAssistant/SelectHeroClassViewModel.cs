using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class SelectHeroClassViewModel : ViewModelBase
    {
        public SelectHeroClassModel Model { get; private set; }

        public SelectHeroClassViewModel(SelectHeroClassModel model)
        {
            Model = model;
        }

        public HeroClass SelectedHeroClass
        {
            get { return Model.SelectedHeroClass; }
            set
            {
                Model.SelectedHeroClass = value;
                OnPropertyChanged(nameof(SelectedHeroClass));
            }
        }
    }
}
