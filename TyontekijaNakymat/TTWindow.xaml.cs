﻿using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Varasto.TyontekijaNakymat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TTWindow : Window
    {
        public TTWindow()
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
        

        private void Nelio_Click(object sender, MouseButtonEventArgs e)
        {
            var kerailyWindow = new YhteisetNakymat.KerailyWindow();
            var hyllytysWindow = new YhteisetNakymat.HyllytysWindow();
            if (sender is Rectangle rect)
            {
                switch (rect.Name)
                {
                    case "kerailyBtn": // Name of the first rectangle
                        kerailyWindow.Show();
                        MessageBox.Show($"Keraily nappula painettu: {rect.Name}");
                        break;

                    case "hyllytysBtn": // Name of the second rectangle
                        hyllytysWindow.Show();
                        MessageBox.Show($"Hyllytys nappula painettu: {rect.Name}");
                        break;

                    case "TTWindowReload": // Name of the reload rectangle
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
                        break;

                    default:
                        MessageBox.Show($"Muu nappula painettu??(ei mahdollista): {rect.Name}");
                        break;
                }
            }
        }

    }
}