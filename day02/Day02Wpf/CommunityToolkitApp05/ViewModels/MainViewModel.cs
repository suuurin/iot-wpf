using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ControlzEx.Theming;
using MahApps.Metro.Controls.Dialogs;

namespace CommunityToolkitApp01.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private readonly IDialogCoordinator _dialogCoordinator;
        private string currentTheme = "현재 테마: Light";

        public string CurrentTheme
        {
            get => currentTheme;
            set => SetProperty(ref currentTheme, value);
        }

        public MainViewModel()
        {
            _dialogCoordinator = DialogCoordinator.Instance;
        }

        [RelayCommand]
        private async Task ShowDialog()
        {
            await _dialogCoordinator.ShowMessageAsync(this, "인사", "안녕하세요! MahApps 다이얼로그입니다.");
        }
    }
}
