using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfRefApp01.ViewModels
{
    public class MainViewModel : Screen // 또는 Conductor<IScreen>, PropertyChangedBase 등 필요에 따라 변경
    {
        private readonly IWindowManager _windowManager;
        private readonly IDialogCoordinator _dialogCoordinator;
        private string _dialogResultText;

        public string DialogResultText
        {
            get => _dialogResultText;
            set
            {
                _dialogResultText = value;
                NotifyOfPropertyChange(() => DialogResultText);
            }
        }

        public MainViewModel(IWindowManager windowManager, IDialogCoordinator dialogCoordinator)
        {
            _windowManager = windowManager;
            _dialogCoordinator = dialogCoordinator; // 생성자 주입
            DisplayName = "MahApps.Metro & Caliburn.Micro"; // 창 제목 설정
        }

        public async Task ShowMessageDialog()
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "네",
                NegativeButtonText = "아니오",
                AnimateShow = true,
                AnimateHide = false
            };

            MessageDialogResult result = await _dialogCoordinator.ShowMessageAsync(this, "알림", "Caliburn.Micro와 MahApps.Metro를 사용한 메시지 다이어로그입니다. 계속하시겠습니까?",
                MessageDialogStyle.AffirmativeAndNegative, mySettings);

            DialogResultText = $"메시지 다이어로그 결과: {result}";
        }

        public async Task ShowInputDialog()
        {
            var result = await _dialogCoordinator.ShowInputAsync(this, "입력", "이름을 입력하세요:");

            if (result == null) // 사용자가 취소한 경우
            {
                DialogResultText = "입력 다이어로그: 취소됨";
            }
            else
            {
                DialogResultText = $"입력 다이어로그 결과: {result}";
            }
        }

        public async Task ShowProgressDialog()
        {
            // ShowProgressAsync는 IProgressDialogController를 반환합니다.
            ProgressDialogController controller = await _dialogCoordinator.ShowProgressAsync(this, "진행 중...", "작업을 처리하는 중입니다. 잠시만 기다려주세요...");
            controller.SetIndeterminate(); // 무한 진행률 표시

            // 비동기 작업 시뮬레이션
            await Task.Delay(3000);

            // 진행률 업데이트 (선택 사항)
            // double i = 0.0;
            // while (i < 100.0)
            // {
            //     i += 1.0;
            //     controller.SetProgress(i / 100.0);
            //     controller.SetMessage($"처리 중... {i:F0}%");
            //     await Task.Delay(50);
            // }

            await controller.CloseAsync();
            DialogResultText = "진행률 다이어로그: 완료됨";
        }

        public async Task ShowLoginDialog()
        {
            var loginDialogSettings = new LoginDialogSettings
            {
                ColorScheme = MetroDialogColorScheme.Accented,
                InitialUsername = "User",
                EnablePasswordPreview = true,
                RememberCheckBoxVisibility = Visibility.Visible
            };

            LoginDialogData result = await _dialogCoordinator.ShowLoginAsync(this, "로그인", "사용자 정보를 입력하세요.", loginDialogSettings);

            if (result == null)
            {
                DialogResultText = "로그인 다이어로그: 취소됨";
            }
            else
            {
                DialogResultText = $"로그인 다이어로그 결과: 사용자 이름 = {result.Username}, 암호 = {(string.IsNullOrEmpty(result.Password) ? "비어있음" : "입력됨")}, 기억하기 = {result.ShouldRemember}";
            }
        }

        // Caliburn.Micro Convention에 따라 버튼 이름과 동일한 public 메서드
        public async Task ShowInfoDialog()
        {
            await _dialogCoordinator.ShowMessageAsync(this, "정보", "이것은 WindowCommands를 통해 호출된 정보 다이어로그입니다.");
        }

        // 커스텀 다이어로그 예제 (선택 사항)
        // 1. 커스텀 다이어로그 UserControl (예: CustomDialogView.xaml) 생성
        // 2. 커스텀 다이어로그 ViewModel (예: CustomDialogViewModel.cs) 생성
        // 3. ShellViewModel에서 호출
        public async Task ShowCustomDialog()
        {
            // var customDialog = new CustomDialogView(); // 실제 UserControl 인스턴스
            // var customDialogViewModel = new CustomDialogViewModel(); // ViewModel이 있다면 설정
            // customDialog.DataContext = customDialogViewModel;

            // 또는 Caliburn.Micro의 ViewModelLocator를 사용하여 ViewModel을 자동으로 연결할 수도 있습니다.
            // var customDialogViewModel = IoC.Get<CustomDialogViewModel>(); // IoC 컨테이너에서 가져오기
            // var customDialog = ViewLocator.LocateForModel(customDialogViewModel, null, null) as CustomDialog; // View 찾기

            // if (customDialog == null)
            // {
            //     DialogResultText = "커스텀 다이어로그 View를 찾을 수 없습니다.";
            //     return;
            // }
            // customDialog.Title = "커스텀 다이어로그";

            // await _dialogCoordinator.ShowMetroDialogAsync(this, customDialog);
            // // 커스텀 다이어로그 내부에서 닫기 로직 필요
            // // 예: await _dialogCoordinator.HideMetroDialogAsync(this, customDialog);
            // DialogResultText = "커스텀 다이어로그가 표시되었습니다. (닫기 로직은 커스텀 다이어로그 내부에 구현)";

            // 간단한 메시지로 대체 (실제 커스텀 다이어로그 구현은 추가 작업 필요)
            await _dialogCoordinator.ShowMessageAsync(this, "커스텀 다이어로그", "커스텀 다이어로그를 표시하려면 별도의 UserControl과 ViewModel을 생성해야 합니다.");
            DialogResultText = "커스텀 다이어로그 예제 (간단 메시지로 대체)";
        }
    }
}
