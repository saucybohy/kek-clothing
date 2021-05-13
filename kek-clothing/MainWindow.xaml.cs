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
        Page1 page1 = new Page1();
      

        public ObservableCollection<ProductModel> products = new ObservableCollection<ProductModel>();
        string directory;
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
                string NewFile = System.IO.Directory.GetCurrentDirectory() + "/images/" + string.Format(@"{0}.txt", Guid.NewGuid()) + ".jpg";
                SqliteDataAccess.AddProduct(NameBox.Text, CategoryBox.Text, price, NewFile);
                int id = products[products.Count - 1].id;
                System.IO.File.Move(directory, NewFile);
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
                directory = op.FileName;  
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            
            int id = int.Parse(((Button)sender).Tag.ToString());
            if (SqliteDataAccess.DeleteProduct(id) > 0)
            {
                LoadProductList();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page1;
        }
    }
}
