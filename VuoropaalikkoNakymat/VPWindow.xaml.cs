﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    public partial class VPWindow : Window
    {
        public VPWindow()
        {
            InitializeComponent();
        }

        private void MenuList_SelectionChanged(object sender,SelectionChangedEventArgs e)
        {
            if (menuList.SelectedItem is ListBoxItem selectedItem)
            {
                string selectedText = selectedItem.Content.ToString();

                switch (selectedText)
                {
                    case "Keräily":
                        YhteisetNakymat.KerailyWindow kerailyIkkuna = new();
                        kerailyIkkuna.Show();
                        break;

                    case "Hyllytys":
                        YhteisetNakymat.HyllytysWindow hyllytysIkkuna = new();
                        hyllytysIkkuna.Show();
                        break;

                    case "Tuotteiden poisto":
                        PoistoWindow poistoIkkuna = new PoistoWindow();
                        poistoIkkuna.Show();
                        break;
                    case "Tuotteiden lisäys":
                        addProduct addProduct = new addProduct();
                        addProduct.Show();
                        break;

                    case "Inventaario":
                        InventaarioWindow inventaarioIkkuna = new InventaarioWindow();
                        inventaarioIkkuna.Show();
                        break;

                    case "Työntekijät":
                        ttTiedot ttIkkuna = new ttTiedot();
                        ttIkkuna.Show();
                        break;
                }
            }
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
