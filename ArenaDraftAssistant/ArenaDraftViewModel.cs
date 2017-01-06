using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    class ArenaDraftViewModel : ViewModelBase
    {
        public ArenaDraftModel Model { get; }

        public ArenaDraftViewModel(ArenaDraftModel model)
        {
            PropertyChanged += HandlePropertyChanged;

            Model = model;
            DraftableCardsForOption1 = Model.DraftableCards;
            DraftableCardsForOption2 = Model.DraftableCards;
            DraftableCardsForOption3 = Model.DraftableCards;
        }

        public HeroClass SelectedHeroClass => Model.SelectedHeroClass;

        public ObservableCollection<Card> DraftableCards => Model.DraftableCards;

        public ObservableCollection<ObservableCollection<KeyValuePair<int, double>>> DropProbabilitiesForManaCost => Model.DropProbabilitiesForManaCost;

        public ObservableCollection<ArenaDraftPick> Picks => Model.Picks;

        public int MaxPicks => Model.MaxPicks;

        private ObservableCollection<Card> _draftableCardsForOption1;

        public ObservableCollection<Card> DraftableCardsForOption1
        {
            get { return _draftableCardsForOption1; }
            set
            {
                _draftableCardsForOption1 = value;
                OnPropertyChanged(nameof(DraftableCardsForOption1));
            }
        }

        private ObservableCollection<Card> _draftableCardsForOption2;

        public ObservableCollection<Card> DraftableCardsForOption2
        {
            get { return _draftableCardsForOption2; }
            set
            {
                _draftableCardsForOption2 = value;
                OnPropertyChanged(nameof(DraftableCardsForOption2));
            }
        }

        private ObservableCollection<Card> _draftableCardsForOption3;

        public ObservableCollection<Card> DraftableCardsForOption3
        {
            get { return _draftableCardsForOption3; }
            set
            {
                _draftableCardsForOption3 = value;
                OnPropertyChanged(nameof(DraftableCardsForOption3));
            }
        }

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

        private void HandlePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(SelectedCard1) || e.PropertyName == nameof(SelectedCard2) || e.PropertyName == nameof(SelectedCard3))
            {
                FilterAllCardOptions();
            }
        }

        private void FilterAllCardOptions()
        {
            if (SelectedCard1 == null && SelectedCard2 == null && SelectedCard3 == null)
            {
                DraftableCardsForOption1 = new ObservableCollection<Card>(DraftableCards);
                DraftableCardsForOption2 = new ObservableCollection<Card>(DraftableCards);
                DraftableCardsForOption3 = new ObservableCollection<Card>(DraftableCards);
            }
            else if (SelectedCard1 != null && SelectedCard2 == null && SelectedCard3 == null)
            {
                DraftableCardsForOption2 = new ObservableCollection<Card>(DraftableCards
                    .Where(card => card.CardRarity == SelectedCard1.CardRarity)
                    .Where(card => !Equals(card, SelectedCard1)));
                DraftableCardsForOption3 = new ObservableCollection<Card>(DraftableCards
                     .Where(card => card.CardRarity == SelectedCard1.CardRarity)
                     .Where(card => !Equals(card, SelectedCard1)));
            }
            else if (SelectedCard1 == null && SelectedCard2 != null && SelectedCard3 == null)
            {
                DraftableCardsForOption1 = new ObservableCollection<Card>(DraftableCards
                    .Where(card => card.CardRarity == SelectedCard2.CardRarity)
                    .Where(card => !Equals(card, SelectedCard2)));
                DraftableCardsForOption3 = new ObservableCollection<Card>(DraftableCards
                     .Where(card => card.CardRarity == SelectedCard2.CardRarity)
                     .Where(card => !Equals(card, SelectedCard2)));
            }
            else if (SelectedCard1 == null && SelectedCard2 == null && SelectedCard3 != null)
            {
                DraftableCardsForOption1 = new ObservableCollection<Card>(DraftableCards
                    .Where(card => card.CardRarity == SelectedCard3.CardRarity)
                    .Where(card => !Equals(card, SelectedCard3)));
                DraftableCardsForOption2 = new ObservableCollection<Card>(DraftableCards
                     .Where(card => card.CardRarity == SelectedCard3.CardRarity)
                     .Where(card => !Equals(card, SelectedCard3)));
            }
            else if (SelectedCard1 != null && SelectedCard2 != null && SelectedCard3 == null)
            {
                DraftableCardsForOption3 = new ObservableCollection<Card>(DraftableCards
                    .Where(card => card.CardRarity == SelectedCard1.CardRarity)
                    .Where(card => !Equals(card, SelectedCard1))
                    .Where(card => !Equals(card, SelectedCard2)));
            }
            else if (SelectedCard1 != null && SelectedCard2 == null && SelectedCard3 != null)
            {
                DraftableCardsForOption2 = new ObservableCollection<Card>(DraftableCards
                    .Where(card => card.CardRarity == SelectedCard1.CardRarity)
                    .Where(card => !Equals(card, SelectedCard1))
                    .Where(card => !Equals(card, SelectedCard3)));
            }
            else if (SelectedCard1 == null && SelectedCard2 != null && SelectedCard3 != null)
            {
                DraftableCardsForOption1 = new ObservableCollection<Card>(DraftableCards
                    .Where(card => card.CardRarity == SelectedCard2.CardRarity)
                    .Where(card => !Equals(card, SelectedCard2))
                    .Where(card => !Equals(card, SelectedCard3)));
            }
            else if (SelectedCard1 != null && SelectedCard2 != null && SelectedCard3 != null)
            {
                // nothing to filter, we have all data already
                return;
            }
        }
    }
}
