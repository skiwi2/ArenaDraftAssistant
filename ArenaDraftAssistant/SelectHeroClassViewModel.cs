using System.Collections.Generic;
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
