using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkitApp01.Models;
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
        private string _currentTime = DateTime.Now.ToLongTimeString();
        public string CurrentTime {
            get => _currentTime; 
            set => SetProperty(ref _currentTime, value);
        }

        private readonly DispatcherTimer _timer;

        public MainViewModel()
        {
            CurrentTime = DateTime.Now.ToLongTimeString();

            _timer = new DispatcherTimer();
            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += (_, __) =>
            {
                CurrentTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                Debug.WriteLine($"[DEBUG] {CurrentTime}");
            };
            _timer.Start();
        }
    }
}
