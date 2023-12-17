using IGOROTAC__PROJECT.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;
using IGOROTAC__PROJECT.Views;
using MahApps.Metro.Controls;
namespace IGOROTAC__PROJECT
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            // Set the initial view (StudentView)
            SetContent(new StudentView());
        }

        public void SetContent(UserControl view)
        {
            mainFrame.Content = view;
        }
    }
}