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
    /// Interaction logic for OrderPageWindow.xaml
    /// </summary>
    public partial class OrderPageWindow : Window
    {
        public OrderPageWindow()
        {
            InitializeComponent();
            ProductListView.ItemsSource = new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "10", "11", "12", "13", "120" };
        }
        public void BackButtonClick(object sender, RoutedEventArgs e)
        {
            OrdersPageWindow ordersPage = new OrdersPageWindow();
            ordersPage.Show();
            this.Close();
        }
    }
}
