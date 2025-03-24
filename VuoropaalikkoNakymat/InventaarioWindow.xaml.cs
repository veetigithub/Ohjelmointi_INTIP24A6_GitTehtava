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

namespace Varasto.VuoropaalikkoNakymat
{
    public partial class InventaarioWindow : Window
    {
        public InventaarioWindow()
        {
            InitializeComponent();
            var incoming = new List<Product>();

            using (StreamReader r = new StreamReader("prodData.json"))
            {
                string json = r.ReadToEnd();
                incoming = JsonSerializer.Deserialize<List<Product>>(json);
            }

            if (incoming != null && incoming.Count > 0)
            {
                ProductsDataGrid.ItemsSource = incoming;

            }
        }
    }
}
