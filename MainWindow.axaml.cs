using Avalonia.Controls;

namespace RESAPPLI
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           InitializeComponent();
           logoImage.Source = new Avalonia.Media.Imaging.Bitmap("../../../asset/res-logo-sombre.png");


        }

        
    }
}