using MahApps.Metro.Controls.Dialogs;
using MahApps01.ViewModels;
using MahApps01.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace MahApps01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //base.OnStartup(e);
            // DialogCoordinator 인스턴스를 직접 주입
            var coordinator = DialogCoordinator.Instance;
            var viewModel = new MainWindowViewModel(coordinator);

            var mainWindow = new MainWindow
            {
                DataContext = viewModel
            };

            mainWindow.Show();
        }
    }

}
