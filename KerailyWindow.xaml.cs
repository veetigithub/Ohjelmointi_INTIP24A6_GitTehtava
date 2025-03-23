using System;
using System.Collections.Generic;
using System.Formats.Asn1;
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
    public class Product
    {
        public int prodID { get; set; }
        public string prodName { get; set; }
        public string prodType { get; set; }
        public string prodMaker { get; set; }
        public decimal prodPrice { get; set; }
        public int prodAmount { get; set; }
        public string prodSafety { get; set; }
    }
    public partial class KerailyWindow : Window
    {
        public KerailyWindow()
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
                    int prodID = Int32.Parse(txtProdID.Text);
                    int prodAmount = Int32.Parse(txtProdAmount.Text);
                    string prodSafety = txtProdSafety.Text;

                    // Find and update product
                    bool productFound = false;

                    foreach (var product in incoming)
                    {
                        if (product.prodID == prodID && product.prodSafety == prodSafety)
                        {
                            if (product.prodAmount >= prodAmount)
                            {
                                product.prodAmount -= prodAmount;
                                productFound = true;
                            }
                            else
                            {
                                MessageBox.Show("Varastossa ei ole tarpeeksi tuotetta!");
                                return;
                            }
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
                    MessageBox.Show("Keräilytiedoissa virheellisiä arvoja!");
                }
            }
        }
    }
}
