using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ArenaDraftAssistant.Model;

namespace ArenaDraftAssistant
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            foreach (var card in ArenaDraft.AllBannedCards)
            {
                Console.WriteLine($"{card.Name}");
            }

            var window = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
                WindowState = WindowState.Maximized
            };
            window.Show();
        }
    }
}
