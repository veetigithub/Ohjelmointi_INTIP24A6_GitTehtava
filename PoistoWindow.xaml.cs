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
    /// Interaction logic for PoistoWindow.xaml
    /// </summary>
    public partial class PoistoWindow : Window
    {
        public PoistoWindow()
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
                    string prodSafety = txtProdSafety.Text;

                    // For checking if product is found
                    int beforeCount = incoming.Count;

                    // Creating a new list that will be used to overwrite the json file
                    List<Product> updatedList = new List<Product>();
                    foreach (var product in incoming)
                    {
                        if (!(product.prodID == prodID && product.prodSafety == prodSafety))
                        {
                            updatedList.Add(product); // Keep the product if it does NOT match
                        }
                    }
                    incoming = updatedList; // Assign filtered list back

                    // If the list is the same length it didnt remove a product
                    int afterCount = incoming.Count;
                    if (beforeCount == afterCount)
                    {
                        MessageBox.Show("Tuotetta ei löydy!");
                        return;
                    }

                    // Write updated JSON back to file
                    string updatedJson = JsonSerializer.Serialize(incoming, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("prodData.json", updatedJson);

                    MessageBox.Show("Tuote poistettu onnistuneesti!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Poistotiedoissa virheellisiä arvoja!");
                }
            }
        }
    }
}
