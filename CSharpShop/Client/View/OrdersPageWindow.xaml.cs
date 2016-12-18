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
using System.Windows.Shapes;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for OrdersPageWindow.xaml
    /// </summary>
    public partial class OrdersPageWindow : Window
    {
        public OrdersPageWindow()
        {
            InitializeComponent();
            OrdersListBox.ItemsSource = new string[] { "1 order", "2 order", "3 order", "4 order", "5 order", "6 order", "7 order", "8 order", "9 order", "10 order", "11", "12", };
        }

        private void CreateOrderButtonClick(object sender, RoutedEventArgs e)
        {
            OrderPageWindow orderPage = new OrderPageWindow();
            orderPage.ProductsInOrderExpander.IsEnabled = false;
            orderPage.ProductsInOrderExpander.IsExpanded = false;
            orderPage.Show();
            this.Close();
        }
        private void OpenOrderButtonClick(object sender, RoutedEventArgs e)
        {
            OrderPageWindow orderPage = new OrderPageWindow();
            orderPage.Show();
            this.Close();
        }
    }
}
