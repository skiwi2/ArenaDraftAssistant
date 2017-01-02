using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    /// <summary>
    /// Interaction logic for ManaCostSelectorControl.xaml
    /// </summary>
    public partial class ManaCostSelectorControl : UserControl, INotifyPropertyChanged
    {
        public ManaCostSelectorControl()
        {
            Loaded += delegate
            {
                CalculateDropProbabilities();
                OnPropertyChanged(nameof(AvailableMulliganAmounts));

                NormalPickProbability = CalculateNormalPickProbability();
                SpecialPickProbability = CalculateSpecialPickProbability();
            };

            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(MulliganAmount))
                {
                    if (DropProbabilitiesForAmount != null)
                    {
                        CalculateDropProbabilities();
                    }
                }
            };

            InitializeComponent();
        }

        public static readonly DependencyProperty ManaCostProperty = DependencyProperty.Register(nameof(ManaCost),
            typeof(int), typeof(ManaCostSelectorControl));

        public int ManaCost
        {
            get { return (int) GetValue(ManaCostProperty); }
            set { SetValue(ManaCostProperty, value); }
        }

        public static readonly DependencyProperty DropProbabilitiesForAmountProperty =
            DependencyProperty.Register(nameof(DropProbabilitiesForAmount),
                typeof(ObservableCollection<KeyValuePair<int, double>>), typeof(ManaCostSelectorControl));

        public ObservableCollection<KeyValuePair<int, double>> DropProbabilitiesForAmount
        {
            get { return (ObservableCollection<KeyValuePair<int, double>>) GetValue(DropProbabilitiesForAmountProperty); }
            set { SetValue(DropProbabilitiesForAmountProperty, value); }
        }

        public static readonly DependencyProperty CardsInOpeningHandProperty =
            DependencyProperty.Register(nameof(CardsInOpeningHand), typeof(int), typeof(ManaCostSelectorControl));

        public int CardsInOpeningHand
        {
            get { return (int) GetValue(CardsInOpeningHandProperty); }
            set { SetValue(CardsInOpeningHandProperty, value); }
        }

        public static readonly DependencyProperty MaxMulliganProperty = DependencyProperty.Register(nameof(MaxMulligan), typeof(int), typeof(ManaCostSelectorControl));

        public int MaxMulligan
        {
            get { return (int) GetValue(MaxMulliganProperty); }
            set { SetValue(MaxMulliganProperty, value); }
        }

        public static readonly DependencyProperty DefaultMulliganProperty =
            DependencyProperty.Register(nameof(DefaultMulligan), typeof(int), typeof(ManaCostSelectorControl));

        public int DefaultMulligan
        {
            get { return (int) GetValue(DefaultMulliganProperty); }
            set { SetValue(DefaultMulliganProperty, value); }
        }

        public static readonly DependencyProperty HeroClassProperty =
            DependencyProperty.Register(nameof(HeroClass), typeof(HeroClass), typeof(ManaCostSelectorControl));

        public HeroClass HeroClass
        {
            get { return (HeroClass) GetValue(HeroClassProperty); }
            set { SetValue(HeroClassProperty, value); }
        }

        private int _mulliganAmount;

        public int MulliganAmount
        {
            get { return _mulliganAmount; }
            set
            {
                _mulliganAmount = value;
                OnPropertyChanged(nameof(MulliganAmount));
            }
        }

        private double _normalPickProbability;

        public double NormalPickProbability
        {
            get { return _normalPickProbability; }
            set
            {
                _normalPickProbability = value;
                OnPropertyChanged(nameof(NormalPickProbability));
            }
        }

        private double _specialPickProbability;

        public double SpecialPickProbability
        {
            get { return _specialPickProbability; }
            set
            {
                _specialPickProbability = value;
                OnPropertyChanged(nameof(SpecialPickProbability));
            }
        }

        public ObservableCollection<int> AvailableMulliganAmounts => new ObservableCollection<int>(Enumerable.Range(0, MaxMulligan + 1));

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CalculateDropProbabilities()
        {
            for (var i = 0; i <= 10; i++)
            {
                DropProbabilitiesForAmount[i] = new KeyValuePair<int, double>(i, ArenaDraft.ProbabilityOfXDropByTurnX(ManaCost, 3, MulliganAmount, i));
            }
        }

        private double CalculateNormalPickProbability()
        {
            var draftableCards = ArenaDraft.GetDraftableCardsForHeroClass(HeroClass);

            var commonProbability = ArenaDraft.ProbabilityOfAtLeastOneOptionConformingPredicate(
                draftableCards.Where(card => card.CardRarity == CardRarity.Free || card.CardRarity == CardRarity.Common), 
                card => card.ManaCost == ManaCost);
            var rareProbability = ArenaDraft.ProbabilityOfAtLeastOneOptionConformingPredicate(
                draftableCards.Where(card => card.CardRarity == CardRarity.Rare),
                card => card.ManaCost == ManaCost);
            var epicProbability = ArenaDraft.ProbabilityOfAtLeastOneOptionConformingPredicate(
                draftableCards.Where(card => card.CardRarity == CardRarity.Epic),
                card => card.ManaCost == ManaCost);
            var legendaryProbability = ArenaDraft.ProbabilityOfAtLeastOneOptionConformingPredicate(
                draftableCards.Where(card => card.CardRarity == CardRarity.Legendary),
                card => card.ManaCost == ManaCost);

            return CalculatePickProbability(ArenaPickOdds.Normal, commonProbability, rareProbability, epicProbability, legendaryProbability);
        }

        private double CalculateSpecialPickProbability()
        {
            var draftableCards = ArenaDraft.GetDraftableCardsForHeroClass(HeroClass);

            var commonProbability = ArenaDraft.ProbabilityOfAtLeastOneOptionConformingPredicate(
                draftableCards.Where(card => card.CardRarity == CardRarity.Free || card.CardRarity == CardRarity.Common),
                card => card.ManaCost == ManaCost);
            var rareProbability = ArenaDraft.ProbabilityOfAtLeastOneOptionConformingPredicate(
                draftableCards.Where(card => card.CardRarity == CardRarity.Rare),
                card => card.ManaCost == ManaCost);
            var epicProbability = ArenaDraft.ProbabilityOfAtLeastOneOptionConformingPredicate(
                draftableCards.Where(card => card.CardRarity == CardRarity.Epic),
                card => card.ManaCost == ManaCost);
            var legendaryProbability = ArenaDraft.ProbabilityOfAtLeastOneOptionConformingPredicate(
                draftableCards.Where(card => card.CardRarity == CardRarity.Legendary),
                card => card.ManaCost == ManaCost);

            return CalculatePickProbability(ArenaPickOdds.Special, commonProbability, rareProbability, epicProbability, legendaryProbability);
        }

        private double CalculatePickProbability(ArenaPickOdds arenaPickOdds, double commonProbability,
            double rareProbability, double epicProbability, double legendaryProbability)
        {
            return arenaPickOdds.CommonPickProbability * commonProbability +
                   arenaPickOdds.RarePickProbability * rareProbability +
                   arenaPickOdds.EpicPickProbability * epicProbability +
                   arenaPickOdds.LegendaryPickProbability * legendaryProbability;
        }
    }
}
