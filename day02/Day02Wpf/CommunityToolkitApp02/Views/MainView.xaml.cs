using CommunityToolkitApp01.ViewModels;
using MahApps.Metro.Controls;
using System.Windows;

namespace CommunityToolkitApp01.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : MetroWindow
    {
        public MainView()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }
}