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
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        Page3 page3 = new Page3();
        Page4 page4 = new Page4();
        Page5 page5 = new Page5();
        Page6 page6 = new Page6();
        public Page2()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page3;
        }

        private void Page3_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page4;
        }

        private void Page4_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page5;
        }

        private void Page5_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Content = page6;
        }

    }
}
