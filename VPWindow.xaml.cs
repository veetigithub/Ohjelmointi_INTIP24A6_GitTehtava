using System;
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

namespace Varasto
{
    public partial class VPWindow : Window
    {
        public VPWindow()
        {
            InitializeComponent();
        }

        private void MenuList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (menuList.SelectedItem == null) return;

            string valinta = ((ListBoxItem)menuList.SelectedItem).Content.ToString();

            switch (valinta)
            {
                case "Keräily":
                    new KerailyWindow().Show();
                    break;
                case "Hyllytys":
                    new HyllytysWindow().Show();
                    break;
                case "Tuotteiden poisto":
                    new PoistoWindow().Show();
                    break;
                case "Inventaario":
                    new InventaarioWindow().Show();
                    break;
                case "Työntekijät":
                    new TTWindow().Show();
                    break;
            }
        }

        private void ListBoxItem_Selected(object sender, RoutedEventArgs e)
        {

        }
    }
}
