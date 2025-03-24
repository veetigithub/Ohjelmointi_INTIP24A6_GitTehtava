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
                    string newAccountType = addAccountType.Text;
                    if(newAccountType != "TT" || newAccountType != "PP")
                    {
                        MessageBox.Show("Väärä tili! Kirjoita TT tai PP!");
                        return;
                    }

                    var addNewWorker = new Worker
                    {
                        Id = Int32.Parse(addUsername.Text),
                        FName = addFName.Text,
                        LName = addLName.Text,
                        Password = addPassword.Text,
                        AccountType = newAccountType
                    };

                    // Pistä tuleva pituus talteen
                    int beforeCount = incoming.Count;

                    incoming.Add(addNewWorker); // Lisää uusi työntekijä

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
