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
using Client.ViewModel;
using DomainModel;
using DataAccessLayer;

namespace Client.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();

            //!!!!!!!!for test only!!!!!!!!!!!!!!
            //in real project connect to Db with wcf services ONLY
            var sc_op = new DataAccessLayer.ShopContext<OrderProduct>();
            sc_op.Items.Add(new OrderProduct());
            var sc_order = new DataAccessLayer.ShopContext<Order>();
            sc_order.Items.Add(new Order());
            var service = new ServiceReferenceProduct.ShopServiceBaseOf_ProductClient();
            var vmAdd = new ViewModelProductAdd(service);
            //service.Create(new ProductPrice
            //{
            //    Id = Guid.NewGuid(),
            //    EffectiveDate = DateTime.Now,
            //    Price = 1.06
            //});
            var vm = new ViewModelProductShow(service);
            vm.GetData();
            foreach (var p in vm.ObsCollection)
            {
                MessageBox.Show(p.Title);
            }           
        }

        public void ButtonRegestrationClick(object sender, RoutedEventArgs e)
        {
            RegistrationWindow registrationWindow = new RegistrationWindow();
            registrationWindow.Show();
            this.Close();
        }

        private void ButtonSignInClick(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text == "admin")
            {
                AdminOrdersPageWindow adminWindow = new AdminOrdersPageWindow();
                adminWindow.Show();
                this.Close();
            }
            else
            {
                OrdersPageWindow mainWindow = new OrdersPageWindow();
                mainWindow.Show();
                this.Close();
            }
        }

        public void TextBoxGotFocus(object sender, RoutedEventArgs e)
        {
            ((TextBox)sender).Text = "";
        }

    }
}
