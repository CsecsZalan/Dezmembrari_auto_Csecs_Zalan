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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dezmembrari_auto_Csecs_Zalan
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int mamericancalifornian = 0;
        private int mamericandetroit = 0;
        private int mitalianmargherita = 0;
        private int mitaliancapricciosa = 0;
        private int mitalianboscaiola = 0;
        private double Total = 0;
        private PizzaType selectedPizza;


        public MainWindow()
        {
       
        }

        private void californianMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mamericancalifornian++;
            txtCalAm.Text = mamericancalifornian.ToString();
        }

        private void detroitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mamericandetroit++;
            txtDitAm.Text = mamericandetroit.ToString();
        }

        private void margheritaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mitalianmargherita++;
            txtMarIt.Text = mitalianmargherita.ToString();
        }

        private void capricciosaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mitaliancapricciosa++;
            txtCapIt.Text = mitaliancapricciosa.ToString();
        }

        private void boscaiolaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            mitalianboscaiola++;
            txtBoscIt.Text = mitalianboscaiola.ToString();
        }
        private void FilledItemsShow_Click(object sender, RoutedEventArgs e)
        {
            string mesaj;
            MenuItem SelectedItem = (MenuItem)e.OriginalSource;
            mesaj = SelectedItem.Header.ToString() + " Pizza's are being cooked!";
            this.Title = mesaj;
        }

        private void exitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
         KeyValuePair<PizzaType, double>[] PriceList = {
  new KeyValuePair<PizzaType, double>(PizzaType.Californian, 30),
  new KeyValuePair<PizzaType, double>(PizzaType.Detroit,35),
  new KeyValuePair<PizzaType, double>(PizzaType.Margherita,22),
  new KeyValuePair<PizzaType, double>(PizzaType.Capricciosa,30),
  new KeyValuePair<PizzaType, double>(PizzaType.Boscaiota,37)

 };
        private void frmMain_Loaded(object sender, RoutedEventArgs e)
        {
            cmbType.ItemsSource = PriceList;
            cmbType.DisplayMemberPath = "Key";
            cmbType.SelectedValuePath = "Value";
        }
        private void cmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            txtPrice.Text = cmbType.SelectedValue.ToString();
            KeyValuePair<PizzaType, double> selectedEntry =
           (KeyValuePair<PizzaType, double>)cmbType.SelectedItem;
            selectedPizza = selectedEntry.Key;
        }
        private int ValidateQuantity(PizzaType selectedDoughnut)
        {
            int q = int.Parse(txtQuantity.Text);
            int r = 1;

            switch (selectedDoughnut)
            {
                case PizzaType.Californian:
                    if (q > mamericancalifornian)
                        r = 0;
                    break;
                case PizzaType.Detroit:
                    if (q > mamericandetroit)
                        r = 0;
                    break;
                case PizzaType.Margherita:
                    if (q > mitalianmargherita)
                        r = 0;
                    break;
                case PizzaType.Capricciosa:
                    if (q > mitaliancapricciosa)
                        r = 0;
                    break;
                case PizzaType.Boscaiota:
                    if (q > mitalianboscaiola)
                        r = 0;
                    break;
            }
            return r;
        }

        private void btnAddToSale_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateQuantity(selectedPizza) > 0)
            {
                lstSale.Items.Add(txtQuantity.Text + " " + selectedPizza.ToString() +
               ":" + txtPrice.Text + " " + double.Parse(txtQuantity.Text) *
               double.Parse(txtPrice.Text));
                Total = Total + double.Parse(txtQuantity.Text) * double.Parse(txtPrice.Text);
                txtTotal.Text = Total.ToString();
            }
            else
            {
                MessageBox.Show("Cantitatea introdusa nu este disponibila in stoc!");
            }
        }

        private void btnRemoveItem_Click(object sender, RoutedEventArgs e)
        {
            lstSale.Items.Remove(lstSale.SelectedItem);
        }

        private void btnCheckOut_Click(object sender, RoutedEventArgs e)
        {
            txtTotal.Text = "0";
            foreach (string s in lstSale.Items)
            {
                switch (s.Substring(s.IndexOf(" ") + 1, s.IndexOf(":") - s.IndexOf(" ") -
               1))
                {
                    case "Glazed":
                        mamericancalifornian = mamericancalifornian - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtCalAm.Text = mamericancalifornian.ToString();
                        break;
                    case "Sugar":
                        mamericandetroit = mamericandetroit - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtDitAm.Text = mamericandetroit.ToString();
                        break;
                    case "Chocolate":
                        mitalianmargherita = mitalianmargherita - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtMarIt.Text = mitalianmargherita.ToString();
                        break;
                    case "Lemon":
                        mitaliancapricciosa = mitaliancapricciosa - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtCapIt.Text = mitaliancapricciosa.ToString();
                        break;
                    case "Vanilla":
                        mitalianboscaiola = mitalianboscaiola - Int32.Parse(s.Substring(0,
                       s.IndexOf(" ")));
                        txtBoscIt.Text = mitalianboscaiola.ToString();
                        break;
                }
            }
            lstSale.Items.Clear();
        }

        private void txtQuantity_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.Key >= Key.D0 && e.Key <= Key.D9))
            {
                MessageBox.Show("Numai cifre se pot introduce!", "Input Error", MessageBoxButton.OK,
               MessageBoxImage.Error);
            }
        }
    }
}
