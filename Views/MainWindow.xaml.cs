using HWID_CHANGER.Helper;
using HWID_CHANGER.ViewModels;
using MahApps.Metro.Controls;

namespace HWID_CHANGER
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainWindowViewModel();
            ViewFinder.SetView(this);
        }
    }
}
