using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

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
        }


    }
}