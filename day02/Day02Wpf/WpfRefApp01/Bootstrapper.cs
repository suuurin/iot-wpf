using Caliburn.Micro;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfRefApp01.ViewModels;

namespace WpfRefApp01
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            _container.Instance<IWindowManager>(new WindowManager());
            _container.Instance<IEventAggregator>(new EventAggregator());

            // IDialogCoordinator 등록
            _container.Singleton<IDialogCoordinator, DialogCoordinator>();

            // MainViewModel 등록 (애플리케이션의 메인 ViewModel)
            _container.PerRequest<MainViewModel>(); // 또는 Singleton으로 등록 가능

            // 필요한 다른 ViewModel들도 여기에 등록합니다.
        }

        protected override object GetInstance(System.Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override System.Collections.Generic.IEnumerable<object> GetAllInstances(System.Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            try
            {
                DisplayRootViewForAsync<MainViewModel>();
            }
            catch (System.Exception ex)
            {
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.AppendLine($"Exception: {ex.Message}");
                sb.AppendLine($"StackTrace: {ex.StackTrace}");
                Exception inner = ex.InnerException;
                while (inner != null)
                {
                    sb.AppendLine($"InnerException: {inner.Message}");
                    sb.AppendLine($"InnerException StackTrace: {inner.StackTrace}");
                    inner = inner.InnerException;
                }
                MessageBox.Show(sb.ToString(), "Startup Error");
                // 또는 Debug.WriteLine(sb.ToString());
                throw; // 다시 예외를 던져서 디버거가 중단되도록 함
            }
        }
    }
}
