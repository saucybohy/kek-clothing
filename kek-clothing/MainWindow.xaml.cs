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
        string directory;
        bool admin = false;
        public MainWindow()
        {
            InitializeComponent();
          
        }

        void LoadProductList(string category)
        {
            products = SqliteDataAccess.LoadProducts(category);
            ProductGrid.ItemsSource = products;
           
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
            LoadProductList("");
          
        }
        
        private void Browse_Click(object sender, RoutedEventArgs e)
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

        private void Delete_Click(object sender, RoutedEventArgs e)
        {   
           if(admin == true) 
           { 
                int id = int.Parse(((Button)sender).Tag.ToString());
                if (SqliteDataAccess.DeleteProduct(id) > 0)
                {
                    LoadProductList("");
                }
           }
        }
        private void HomeBut_Click(object sender, RoutedEventArgs e)
        {
            Home.Height = new GridLength(1100, GridUnitType.Pixel);
            AdminInp.Height = new GridLength(0, GridUnitType.Pixel);
            AdminBut.Height = new GridLength(0, GridUnitType.Pixel);
            Products.Height = new GridLength(0, GridUnitType.Pixel);
            admin = false;
        }

        private void Top_Button_Click(object sender, RoutedEventArgs e)
        {
                      
            Home.Height = new GridLength(0, GridUnitType.Pixel);
            Products.Height = new GridLength(1100, GridUnitType.Pixel);
            AdminInp.Height = new GridLength(0, GridUnitType.Pixel);
            AdminBut.Height = new GridLength(0, GridUnitType.Pixel);
            LoadProductList("tops");
            admin = false;
        }

        private void Bottom_Click(object sender, RoutedEventArgs e)
        {
            Home.Height = new GridLength(0, GridUnitType.Pixel);
            Products.Height = new GridLength(1100, GridUnitType.Pixel);
            AdminInp.Height = new GridLength(0, GridUnitType.Pixel);
            AdminBut.Height = new GridLength(0, GridUnitType.Pixel);
            LoadProductList("bottoms");
            admin = false;
        }

        private void Footwear_Click(object sender, RoutedEventArgs e)
        {
            Home.Height = new GridLength(0, GridUnitType.Pixel);
            Products.Height = new GridLength(1100, GridUnitType.Pixel);
            AdminInp.Height = new GridLength(0, GridUnitType.Pixel);
            AdminBut.Height = new GridLength(0, GridUnitType.Pixel);
            LoadProductList("footwear");
            admin = false;
        }

        private void Accesories_Click(object sender, RoutedEventArgs e)
        {
            Home.Height = new GridLength(0, GridUnitType.Pixel);
            Products.Height = new GridLength(1100, GridUnitType.Pixel);
            AdminInp.Height = new GridLength(0, GridUnitType.Pixel);
            AdminBut.Height = new GridLength(0, GridUnitType.Pixel);
            LoadProductList("accesories");
            admin = false;
        }
        private void Admin(object sender, RoutedEventArgs e)
        {
            admin = true;
            AdminInp.Height = new GridLength(100, GridUnitType.Pixel);
            AdminBut.Height = new GridLength(100, GridUnitType.Pixel);
            Products.Height = new GridLength(600, GridUnitType.Pixel);
            Home.Height = new GridLength(0, GridUnitType.Pixel);
            LoadProductList("");

        }
    }
}
