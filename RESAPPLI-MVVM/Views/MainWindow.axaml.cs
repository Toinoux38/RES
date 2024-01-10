using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace RESAPPLI_MVVM.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
            // Trouvez le bouton "Cr�er mon entreprise" et abonnez-vous � son �v�nement Click
            var createCompanyButton = this.FindControl<Button>("CreateCompanyButton");
            createCompanyButton.Click += CreateCompanyButton_Click;
        }

        private void CreateCompanyButton_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
        {
            // Lorsque le bouton est cliqu�, ouvrez la nouvelle fen�tre CreateCompanyWindow
            var createCompanyWindow = new CreateCompanyWindow();
            createCompanyWindow.Show();
        }
    }
}
