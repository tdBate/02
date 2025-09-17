using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace listak_gyakorlas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> gyunolcsok = new List<string> { "Alma", "Körte", "Banán", "Szilva" };

        List<string> balLista = new List<string> { "Alma", "Körte", "Banán", "Szilva" };
        List <string> jobbLista = new List<string>();
    public MainWindow()
        {
            InitializeComponent();

            List<string> szinek = new List<string> { "Piros", "Zöld", "Kék"};
            cmbSzinek.ItemsSource = szinek;

            //listbox
            lbGyumolcsok.ItemsSource = gyunolcsok;

            lbBal.ItemsSource = balLista;
            lbJobb.ItemsSource = jobbLista;
        }

        private void cmbSzinek_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbSzinek.SelectedItem != null)
            {
                lblSzin.Content = "Content: "+cmbSzinek.SelectedItem.ToString();
            }
            
        }

        private void btnFelvitel_Click(object sender, RoutedEventArgs e)
        {
            string ujELem = tbUj.Text.Trim();

            if (!(string.IsNullOrEmpty(ujELem))) 
            {
                gyunolcsok.Add(ujELem);
                lbGyumolcsok.Items.Refresh();
                tbUj.Clear();
            }
            else
            {
                MessageBox.Show(this,"Nem adtál meg új elemet!","Hiba",MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnTorles_Click(object sender, RoutedEventArgs e)
        {
            if (lbGyumolcsok.SelectedItems.Count == 0)
            {
                MessageBox.Show(this, "Nincs kijelölve elem!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else 
            {
                var torlendo = lbGyumolcsok.SelectedItems.Cast<string>().ToList();
                foreach (var tor in torlendo)
                {
                    gyunolcsok.Remove(tor);
                }
                lbGyumolcsok.Items.Refresh();
            }
            
        }

        private void btnJobbra_Click(object sender, RoutedEventArgs e)
        {
            var kijelolt = lbBal.SelectedItems.Cast<string>().ToList();
            foreach (var item in kijelolt)
            {
                balLista.Remove(item);
                jobbLista.Add(item);
            }

            lbBal.Items.Refresh();
            lbJobb.Items.Refresh();
        }

        private void btnBalra_Click(object sender, RoutedEventArgs e)
        {
            var kijelolt = lbJobb.SelectedItems.Cast<string>().ToList();
            foreach (var item in kijelolt)
            {
                jobbLista.Remove(item);
                balLista.Add(item);
            }

            lbBal.Items.Refresh();
            lbJobb.Items.Refresh();
        }
    }
}