using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
    public record struct Worker (
        int Id,
        string FName,
        string LName,
        string Password,
        string AccountType
    );

    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
        }
        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {

            var incoming = new List<Worker>();
            
            // Haetaan pplData.json ja luetaan se c# objektiksi
            using (StreamReader r = new StreamReader("pplData.json"))
            {
                string json = r.ReadToEnd();
                incoming = JsonSerializer.Deserialize<List<Worker>>(json);
            }

            bool kirjautuminenOnnistui = false;

            // Tarkistetaan että oikeasti löytyy dataa millä toimia
            if (incoming != null && incoming.Count > 0)
            {
                try
                {
                    int Username = Int32.Parse(txtUsername.Text);
                    string Password = txtPassword.Password;
                    
                    // Jokaisen työntekijän tiedot käydään läpi ja etsitään mätsi salasana ja id
                    foreach (var tt in incoming)
                    {
                        if (tt.Id == Username && tt.Password == Password)
                        {
                            // Tarkista Käyttäjätyyppi
                            if (tt.AccountType == "TT")
                                {

                                }
                            else
                                {

                                }

                            MessageBox.Show("Kirjautuminen onnistui!");
                            kirjautuminenOnnistui = true;
                            break;
                        }
                    }

                    if (!kirjautuminenOnnistui)
                    {
                        MessageBox.Show("Kirjautuminen epäonnistui!");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Käyttäjätunnuksessa virheellisiä arvoja!");
                }
            }

        }
    }
}
