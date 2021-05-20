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
    // loads the products 
        void LoadProductList(string category)
        {
            products = SqliteDataAccess.LoadProducts(category);
            ProductGrid.ItemsSource = products;
           
        }
    // the save button gets all the inputed info and saves it
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
    // browse button gets an image with .jpeg, .png etc then shows a message box to confrm it got the right image then converts to a string    
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

    // delete button waits on the admin bool to be set to true then deletes whatever product the button is on then refreshes the page to show that the product has been deleted 
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
    // each button bellow sets the deserved row to the correct size and the others to 0 
    // each button sets the admin bool to false unless its the admin button which sets it to true this is so the delete button only works on the admin page
    // the category buttons also filter out the desvered product eg tops will only load up tops
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
