using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Varasto
{
    /// <summary>
    /// Interaction logic for ttTiedot.xaml
    /// </summary>
    public partial class ttTiedot : Window
    {
        public ttTiedot()
        {
            InitializeComponent();
            var incoming = new List<Worker>();

            using (StreamReader r = new StreamReader("pplData.json"))
            {
                string json = r.ReadToEnd();
                incoming = JsonSerializer.Deserialize<List<Worker>>(json);
            }

            if (incoming != null && incoming.Count > 0)
            {
                ttTietoPankki.ItemsSource = incoming;

            }
        }
    }
}
