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
        Page3 page3 = new Page3();
        Page4 page4 = new Page4();
        Page5 page5 = new Page5();
        Page6 page6 = new Page6();

        public Page1()
        {
            InitializeComponent();
        }
        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }

        private void HomeBut_Click(object sender, RoutedEventArgs e)
        {
           
           
        }
      
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Page4_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void Page5_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}

