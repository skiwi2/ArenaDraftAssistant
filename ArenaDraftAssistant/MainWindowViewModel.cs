using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaDraftAssistant
{
    class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            LoadSelectHeroClassPage();
        }

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        private void LoadSelectHeroClassPage() => CurrentViewModel = new SelectHeroClassViewModel(new SelectHeroClassModel());
    }
}
