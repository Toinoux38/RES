using System;
using Avalonia;
using Avalonia.Animation;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RESAPPLI_MVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var transition = new CrossFade(TimeSpan.FromMilliseconds(500));


        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            var createCompanyButton = this.FindControl<Button>("CreateCompanyButton");
            createCompanyButton.Click += CreateCompanyButton_Click;

            var seConnecterButton = this.FindControl<Button>("SeConnectionButton");
            seConnecterButton.Click += displayLoginPage;
        }

        private void CreateCompanyButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Lorsque le bouton est cliqué, ouvre la nouvelle fenetre CreateCompanyWindow
            var createCompanyWindow = new CreateCompanyWindow();
            createCompanyWindow.Show();
        }

        private void displayLoginPage(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            var loginWindows = new LoginWindow();
            loginWindows.Show();
        }
    }
}
