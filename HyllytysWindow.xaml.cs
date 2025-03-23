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

    public partial class HyllytysWindow : Window
    {
        public HyllytysWindow()
        {
            InitializeComponent();
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            var incoming = new List<Product>();

            using (StreamReader r = new StreamReader("prodData.json"))
            {
                string json = r.ReadToEnd();
                incoming = JsonSerializer.Deserialize<List<Product>>(json);
            }

            if (incoming != null && incoming.Count > 0)
            {
                try
                {
                    int prodID = Int32.Parse(IDTextBox.Text);
                    int prodAmount = Int32.Parse(LukumaaraTextBox.Text);
                    string prodSafety = VarmennuskoodiTextBox.Text;

                    // Find and update product
                    bool productFound = false;

                    foreach (var product in incoming)
                    {
                        if (product.prodID == prodID && product.prodSafety == prodSafety)
                        {

                            product.prodAmount += prodAmount;
                            productFound = true;
                            break;
                        }
                    }

                    if (!productFound)
                    {
                        MessageBox.Show("Tuotetta ei löydy!");
                        return;
                    }

                    // Write updated JSON back to file
                    string updatedJson = JsonSerializer.Serialize(incoming, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("prodData.json", updatedJson);

                    MessageBox.Show("Tuotteen määrä päivitetty onnistuneesti!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Hyllytystiedoissa virheellisiä arvoja!");
                }
            }
        }
    }
}
