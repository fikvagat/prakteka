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

namespace prakteka
{
    /// <summary>
    /// Логика взаимодействия для OrderListWindow.xaml
    /// </summary>
    public partial class OrderListWindow : Window
    {
        Users user;
        public OrderListWindow(Users user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void btnProducts_Click(object sender, RoutedEventArgs e)
        {
            new ProductListWindow(user).Show();
            Close();
        }

        private void cbSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (cbDiscount.SelectedIndex)
            {
                case 0: dgOrders.ItemsSource = Instances.Context.Products.ToList(); break;
                case 1: dgOrders.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 0 && p.discount <= 10).ToList(); break;
                case 2: dgOrders.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 11 && p.discount <= 14).ToList(); break;
                case 3: dgOrders.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 15).ToList(); break;

            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            cbDiscount.SelectedIndex = -1;
            cbSort.SelectedIndex = -1;
        }

        private void cbDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
