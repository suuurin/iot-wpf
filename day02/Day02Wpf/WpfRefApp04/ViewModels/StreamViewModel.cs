using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.Timers;

namespace WpfRefApp04.ViewModels
{
    public class StreamViewModel : Screen
    {
        private readonly System.Timers.Timer _timer;
        private int _counter = 1;

        public ObservableCollection<string> Logs { get; set; }

        public StreamViewModel()
        {
            Logs = new ObservableCollection<string>();
            _timer = new System.Timers.Timer(1000); // 1초마다
            _timer.Elapsed += Timer_Elapsed;
            _timer.AutoReset = true;
        }

        public void StartStreaming()
        {
            if (!_timer.Enabled)
            {
                Logs.Clear();
                _counter = 1;
                _timer.Start();
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            Execute.OnUIThread(() =>
            {
                Logs.Add($"[{DateTime.Now:HH:mm:ss}] 스트리밍 데이터 {_counter++}");
            });
        }


        //protected override void OnDeactivate(bool close)
        //{
        //    _timer?.Stop();
        //    base.OnDeactivate(close);
        //}
    }
}
