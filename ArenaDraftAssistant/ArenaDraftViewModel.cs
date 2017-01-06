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

        public Card SelectedCard1 { get; set; }

        public Card SelectedCard2 { get; set; }

        public Card SelectedCard3 { get; set; }

        public ICommand SavePickCommand => new DelegateCommand(o =>
        {
            if (Picks.Count == 30)
            {
                return;
            }
            Picks.Add(new ArenaDraftPick(SelectedCard1, SelectedCard2, SelectedCard3, ArenaDraftPickOption.One));
        });
    }
}
