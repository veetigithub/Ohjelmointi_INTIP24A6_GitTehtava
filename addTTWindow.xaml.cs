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
    /// Interaction logic for addTTWindow.xaml
    /// </summary>
    public partial class addTTWindow : Window
    {
        public addTTWindow()
        {
            InitializeComponent();
        }
        // kirjoitetaan jsonille uusi työntekijä
        private void btnAddWorker_Click(object sender, RoutedEventArgs e)
        {
            var incoming = new List<Worker>();

            using (StreamReader r = new StreamReader("pplData.json"))
            {
                string json = r.ReadToEnd();
                incoming = JsonSerializer.Deserialize<List<Worker>>(json);
            }

            if (incoming != null && incoming.Count > 0)
            {
                try
                {
                    var addNewWorker = new Worker
                    {
                        Id = Int32.Parse(addUsername.Text),
                        FName = addFName.Text,
                        LName = addLName.Text,
                        Password = addPassword.Text,
                        AccountType = addAccountType.Text
                    };

                    // Pistä tuleva pituus talteen
                    int beforeCount = incoming.Count;

                    // Uusi worker lista vanhan tilalle
                    List<Worker> updatedList = new List<Worker>();

                    updatedList.Add(addNewWorker); // Lisää uusi työntekijä

                    incoming = updatedList; // Pistä uusi lista vanhan tilalle

                    // jos samanpituinen et lisännyt työntekijää
                    int afterCount = incoming.Count;
                    if (beforeCount == afterCount)
                    {
                        MessageBox.Show("Et lisännyt työntekijää!");
                        return;
                    }

                    // Kirjoita takaisin tiedostoon
                    string updatedJson = JsonSerializer.Serialize(incoming, new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText("pplData.json", updatedJson);

                    MessageBox.Show("Työntekijä lisätty!");
                }
                catch (Exception)
                {
                    MessageBox.Show("Virheellisiä arvoja!");
                }
            }
        }
    }
}
