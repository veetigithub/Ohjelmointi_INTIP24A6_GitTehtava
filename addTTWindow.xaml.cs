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
            var addNewWorker = new Worker
            {
                Id = Int32.Parse(addUsername.Text),
                FName = addFName.Text,
                LName = addLName.Text,
                Password = addPassword.Text,
                AccountType = addAccountType.Text
            };
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(addNewWorker, options);
            MessageBox.Show("Työntekijä lisätty!");
        }
    }
}
