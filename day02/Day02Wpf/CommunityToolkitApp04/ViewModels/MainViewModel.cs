using CommunityToolkit.Mvvm.ComponentModel;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using System.Collections.ObjectModel;
using System.Windows.Threading;

namespace CommunityToolkitApp01.ViewModels
{
    public partial class MainViewModel : ObservableObject
    {
        private ObservableCollection<double> _values;
        private DispatcherTimer _timer;
        private int _tick = 0;

        public ISeries[] LineSeries { get; set; }

        public MainViewModel()
        {
            _values = new ObservableCollection<double>();

            LineSeries = new ISeries[]
            {
                new LineSeries<double>
                {
                    Values = _values,
                    Fill = null // 선 그래프에 음영 제거
                }
            };

            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (s, e) =>
            {
                _values.Add(Math.Sin(_tick++ * 0.5)); // 예제용 사인파 데이터
                if (_values.Count > 30) _values.RemoveAt(0); // 슬라이딩 윈도우
            };
            _timer.Start();
        }
    }
}
