using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfRefApp02.ViewModels
{
    public class ShellViewModel : Screen
    {
        private readonly IDialogCoordinator _dialogCoordinator;

        public ShellViewModel(IDialogCoordinator dialogCoordinator)
        {
            _dialogCoordinator = dialogCoordinator;
        }

        public async Task ShowDialog()
        {
            await _dialogCoordinator.ShowMessageAsync(this, "확인", "정상적으로 다이얼로그가 표시되었습니다.");
        }
    }
}
