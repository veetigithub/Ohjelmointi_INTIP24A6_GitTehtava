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

namespace Varasto
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TTWindow : Window
    {
        public TTWindow()
        {
            InitializeComponent();
        }

        private void Nelio_Click(object sender, MouseButtonEventArgs e)
        {
            if (sender is Rectangle rect)
            {
                MessageBox.Show($"Rectangle clicked: {rect.Name}");
            }
        }

    }
}