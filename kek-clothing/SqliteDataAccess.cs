using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace kek_clothing
{
    public class SqliteDataAccess
    {
        public static ObservableCollection<ProductModel> LoadProducts(string category)
        {
            using (IDbConnection cnn  = new SQLiteConnection(LoadConnectionString()))
            {
                var output = cnn.Query<ProductModel>("select * from products", new DynamicParameters());
                return new ObservableCollection<ProductModel>(output.ToList());
            }
        }

        public static void AddProduct(string name, string category, float price)
        {
            ProductModel product = new ProductModel();
            product.name = name;
            product.category = category;
            product.price = price;
            SaveProduct(product);
        }

        public static void SaveProduct(ProductModel product)
        {
            using (IDbConnection cnn = new SQLiteConnection(LoadConnectionString()))
            {
                cnn.Execute("insert into products (name, category, price) values (@name, @category, @price)", product);
            }
        }

        private static string LoadConnectionString(string id = "Default")
        {
            return ConfigurationManager.ConnectionStrings[id].ConnectionString;
        }
    }
}
