using System.Windows;
using System.Windows.Input;
using ArenaDraftAssistant.Model;

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

        public ICommand CloseApplicationCommand => new DelegateCommand(o => Application.Current.Shutdown());

        public ICommand LoadArenaDraftPageCommand => new DelegateCommand(parameter => LoadArenaDraftPage(parameter as HeroClass));

        private void LoadSelectHeroClassPage() => CurrentViewModel = new SelectHeroClassViewModel(new SelectHeroClassModel());

        private void LoadArenaDraftPage(HeroClass selectedHeroClass) => CurrentViewModel = new ArenaDraftViewModel(new ArenaDraftModel(selectedHeroClass));
    }
}
