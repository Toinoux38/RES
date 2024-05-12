using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using RESAPPLI_MVVM.Context;
using RESAPPLI_MVVM.Services;
using RESAPPLI_MVVM.ViewModels;
using RESAPPLI_MVVM.Views;
using Splat;

namespace RESAPPLI_MVVM
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            Locator.CurrentMutable.Register(() => new ReservationService(new RESAPPLIContext()), typeof(iReservationService));
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainWindowViewModel(),
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}