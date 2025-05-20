using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkitApp01.Models;
using ControlzEx.Theming;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace CommunityToolkitApp01.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private string currentTheme = "현재 테마: Light";

        public string CurrentTheme
        {
            get => currentTheme;
            set => SetProperty(ref currentTheme, value);
        }

        [RelayCommand]
        private void ToggleTheme()
        {
            var current = ThemeManager.Current.DetectTheme();

            if (current.BaseColorScheme == "Light")
            {
                ThemeManager.Current.ChangeTheme(App.Current, "Dark.Blue");
                CurrentTheme = "현재 테마: Dark";
            }
            else
            {
                ThemeManager.Current.ChangeTheme(App.Current, "Light.Blue");
                CurrentTheme = "현재 테마: Light";
            }
        }
    }
}
