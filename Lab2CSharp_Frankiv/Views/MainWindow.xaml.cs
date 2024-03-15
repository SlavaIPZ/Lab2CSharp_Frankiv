using System.Windows;
using Lab2CSharp_Frankiv.ViewModels;

namespace Lab2CSharp_Frankiv.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}
