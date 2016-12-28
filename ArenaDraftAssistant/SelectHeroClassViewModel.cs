using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class SelectHeroClassViewModel : ViewModelBase
    {
        public SelectHeroClassModel Model { get; }

        public SelectHeroClassViewModel(SelectHeroClassModel model)
        {
            Model = model;
        }

        public IList<HeroClass> AllHeroClasses => Model.AllHeroClasses;
    }
}
