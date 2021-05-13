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

namespace kek_clothing
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        public Page2 page2 = new Page2();
        public Page1()
        {
            InitializeComponent();
        }
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void HomeBut_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page2;
            MessageBox.Show("cock");
        }

    }
}

