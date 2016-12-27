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

        public ICommand ContinueButtonCommand { get; }

        public SelectHeroClassViewModel(SelectHeroClassModel model)
        {
            Model = model;

            ContinueButtonCommand = new DelegateCommand(o => Continue());
        }

        public IList<HeroClass> AllHeroClasses => Model.AllHeroClasses;

        public HeroClass SelectedHeroClass
        {
            get { return Model.SelectedHeroClass; }
            set
            {
                Model.SelectedHeroClass = value;
                OnPropertyChanged(nameof(SelectedHeroClass));
            }
        }

        private void Continue()
        {
            Console.WriteLine(SelectedHeroClass.Name);

            // TODO Actually continue
        }
    }
}
