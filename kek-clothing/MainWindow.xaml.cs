using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace kek_clothing
{

    public partial class MainWindow : Window
    {
        public ObservableCollection<ProductModel> products = new ObservableCollection<ProductModel>();
      
        public MainWindow()
        {
            InitializeComponent();
            LoadProductList();
        }

        void LoadProductList()
        {
            products = SqliteDataAccess.LoadProducts("tops");
            ProductGrid.ItemsSource = products;
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LoadProductList();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if(float.TryParse(PriceBox.Text, out float price))
            {
                SqliteDataAccess.AddProduct(NameBox.Text, CategoryBox.Text, price);
            }
            else
            {
                MessageBox.Show("Please enter a valid price");
            }
            LoadProductList();
        }
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            
            if (op.ShowDialog() == true)
            {
                MessageBox.Show(op.FileName);
                string directory = op.FileName;  
            }
        }
    }
}
