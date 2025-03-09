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
            var kerailyWindow = new KerailyWindow();
            var hyllytysWindow = new HyllytysWindow();
            if (sender is Rectangle rect)
            {
                switch (rect.Name)
                {
                    case "kerailyBtn": // Name of the first rectangle
                        kerailyWindow.Show();
                        MessageBox.Show($"Keraily nappula painettu: {rect.Name}");
                        break;

                    case "hyllytysBtn": // Name of the second rectangle
                        hyllytysWindow.Show();
                        MessageBox.Show($"Hyllytys nappula painettu: {rect.Name}");
                        break;

                    default:
                        MessageBox.Show($"Muu nappula painettu??: {rect.Name}");
                        break;
                }
            }
        }

    }
}