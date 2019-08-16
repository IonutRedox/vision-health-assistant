using System.Windows;
using VisionHealthAssistant.UI.ViewModel;

namespace VisionHealthAssistant.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MainWindow app = new MainWindow();
            MainViewModel context = new MainViewModel();
            app.DataContext = context;
            app.Show();
        }
    }
}
