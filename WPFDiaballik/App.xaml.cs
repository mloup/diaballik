using System.Windows;
using WPFDiaballik.ViewModels;
using WPFDiaballik.Views;

namespace WPFDiaballik
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow();
            window.DataContext = new MainViewModel();
            window.Show();
        }
    }
}
