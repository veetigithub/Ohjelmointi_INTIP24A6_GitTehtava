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
    /// <summary>
    /// Interaction logic for addProduct.xaml
    /// </summary>
    public partial class addProduct : Window
    {
        public addProduct()
        {
            InitializeComponent();
        }

        private void btnAddProd_Click(object sender, RoutedEventArgs e)
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
                    int newProdId = Int32.Parse(addProdId.Text);

                    //Tarkista ID matchejä
                    foreach (var product in incoming)
                    {
                        if (product.prodID == newProdId)
                        {
                            MessageBox.Show("ID Käytössä! Yritä toista!");
                            return;
                        }
                    }

                    // uusi product annetuista arvoista
                    var addNewProduct = new Product
                    {
                        prodID = newProdId,
                        prodName = addProdName.Text,
                        prodType = addProdType.Text,
                        prodMaker = addProdMaker.Text,
                        prodPrice = Convert.ToDecimal(addProdPrice.Text),
                        prodAmount = Int32.Parse(addProdAmount.Text),
                        prodSafety = addProdSafety.Text
                    };

                    // Pistä tuleva pituus talteen
                    int beforeCount = incoming.Count;

                    incoming.Add(addNewProduct); // Lisää uusi tuote

                    // jos samanpituinen et lisännyt tuotetta
                    int afterCount = incoming.Count;
                    if (beforeCount == afterCount)
                    {
                        MessageBox.Show("Et lisännyt tuotetta!");
                        return;
                    }

                    // Kirjoita takaisin tiedostoon
                    string updatedJson = JsonSerializer.Serialize(incoming, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("prodData.json", updatedJson);

                    MessageBox.Show("Tuote lisätty!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Virheellisiä arvoja!");
                }
            }
        }
    }
}
