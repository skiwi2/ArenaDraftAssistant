using System.Windows;

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

            var window = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
                WindowState = WindowState.Maximized
            };
            window.Show();
        }
    }
}
