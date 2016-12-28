using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ArenaDraftAssistant
{
    /// <summary>
    /// Interaction logic for ManaCostSelector.xaml
    /// </summary>
    public partial class ManaCostSelectorControl : UserControl
    {
        public ManaCostSelectorControl()
        {
            InitializeComponent();

            DataContext = this;
        }

        public static readonly DependencyProperty ManaCostProperty = DependencyProperty.Register(nameof(ManaCost), typeof(int), typeof(ManaCostSelectorControl));

        public int ManaCost
        {
            get { return (int) GetValue(ManaCostProperty); }
            set { SetValue(ManaCostProperty, value); }
        }
    }
}
