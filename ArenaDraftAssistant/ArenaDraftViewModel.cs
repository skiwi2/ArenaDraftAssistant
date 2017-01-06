using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
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

        public ObservableCollection<Card> DraftableCards => Model.DraftableCards;

        public ObservableCollection<ObservableCollection<KeyValuePair<int, double>>> DropProbabilitiesForManaCost => Model.DropProbabilitiesForManaCost;

        public ObservableCollection<ArenaDraftPick> Picks => Model.Picks;

        public int MaxPicks => Model.MaxPicks;

        private Card _selectedCard1;

        public Card SelectedCard1
        {
            get { return _selectedCard1; }
            set
            {
                _selectedCard1 = value;
                OnPropertyChanged(nameof(SelectedCard1));
            }
        }

        private Card _selectedCard2;

        public Card SelectedCard2
        {
            get { return _selectedCard2; }
            set
            {
                _selectedCard2 = value;
                OnPropertyChanged(nameof(SelectedCard2));
            }
        }

        private Card _selectedCard3;

        public Card SelectedCard3
        {
            get { return _selectedCard3; }
            set
            {
                _selectedCard3 = value;
                OnPropertyChanged(nameof(SelectedCard3));
            }
        }

        public ICommand SavePickCommand => new DelegateCommand(selectedOption =>
        {
            if (Picks.Count == 30)
            {
                return;
            }
            Picks.Add(new ArenaDraftPick(SelectedCard1, SelectedCard2, SelectedCard3, (ArenaDraftPickOption) selectedOption));
        });
    }
}
