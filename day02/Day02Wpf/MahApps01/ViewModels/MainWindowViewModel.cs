using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MahApps01.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        // The DialogCoordinator
        private readonly IDialogCoordinator dialogCoordinator;

        public MainWindowViewModel(IDialogCoordinator coordinator)
        {
            this.dialogCoordinator = coordinator;
        }

        [RelayCommand]
        // Simple method which can be used on a Button
        public async Task FooMessage()
        {
            await this.dialogCoordinator.ShowMessageAsync(this, "Message Title", "Bar");
        }

        [RelayCommand]
        public async Task FooProgress()
        {
            var controller = await dialogCoordinator.ShowProgressAsync(this, "Wait", "Processing...");
            controller.SetIndeterminate();
            await Task.Delay(2000);
            await controller.CloseAsync();
        }
    }
}
