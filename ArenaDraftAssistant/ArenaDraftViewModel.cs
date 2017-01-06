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

        private string _selectedCard1Text;

        public string SelectedCard1Text
        {
            get { return _selectedCard1Text; }
            set
            {
                _selectedCard1Text = value;
                OnPropertyChanged(nameof(SelectedCard1Text));
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

        private string _selectedCard2Text;

        public string SelectedCard2Text
        {
            get { return _selectedCard2Text; }
            set
            {
                _selectedCard2Text = value;
                OnPropertyChanged(nameof(SelectedCard2Text));
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

        private string _selectedCard3Text;

        public string SelectedCard3Text
        {
            get { return _selectedCard3Text; }
            set
            {
                _selectedCard3Text = value;
                OnPropertyChanged(nameof(SelectedCard3Text));
            }
        }

        public ICommand SavePickCommand => new DelegateCommand(selectedOption =>
        {
            if (Picks.Count == 30)
            {
                return;
            }
            Picks.Add(new ArenaDraftPick(SelectedCard1, SelectedCard2, SelectedCard3, (ArenaDraftPickOption) selectedOption));
            InitializeAutoCompleteBoxes();
        });

        private void InitializeAutoCompleteBoxes()
        {
            SelectedCard1 = null;
            SelectedCard1Text = "";
            SelectedCard2 = null;
            SelectedCard2Text = "";
            SelectedCard3 = null;
            SelectedCard3Text = "";
        }
    }
}
