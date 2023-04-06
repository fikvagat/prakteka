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
using System.Windows.Shapes;

namespace prakteka
{
    /// <summary>
    /// Логика взаимодействия для ProductListWindow.xaml
    /// </summary>
    public partial class ProductListWindow : Window
    {
        Users user = new Users();
        List<Products> list = new List<Products>();
        public ProductListWindow(Users user)
        {
            InitializeComponent();
            this.user = user;
            lvProduct.ItemsSource = Instances.Context.Products.ToList();
            lblCount.Content = lvProduct.Items.Count;
            cbDiscount.Items.Add("Любая скидка");
            cbDiscount.Items.Add("0% - 10%");
            cbDiscount.Items.Add("11% - 14%");
            cbDiscount.Items.Add("15% и более");

            if (user.role == 0 || user.role == 1)
            {
                btnAdd.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnOrders.IsEnabled = false;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            Products product = new Products();
            new AddProductWindow(product).Show();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show("Вы уверены, что хотите удалить выбранный товар?", "Внимание", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                Products product = lvProduct.SelectedItem as Products;
                Instances.Context.Products.Remove(product);
                Instances.Context.SaveChanges();
                MessageBox.Show("Продукт успешно удалён", "Внимание");
                lvProduct.ItemsSource = Instances.Context.Products.ToList();
            }

        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtSearch.Text.Length == 0)
                lvProduct.ItemsSource = Instances.Context.Products.ToList();
            else if (cbDiscount.SelectedItem != null) 
            {
                switch (cbDiscount.SelectedIndex)
                {
                    case 0: lvProduct.ItemsSource = Instances.Context.Products.ToList(); break;
                    case 1: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 0 && p.discount <= 10 && p.name.Contains(txtSearch.Text)).ToList(); break;
                    case 2: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 11 && p.discount <= 14 && p.name.Contains(txtSearch.Text)).ToList(); break;
                    case 3: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 15 && p.name.Contains(txtSearch.Text)).ToList(); break;

                }
            }
            else lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.name.Contains(txtSearch.Text)).ToList();
            lblCount.Content = lvProduct.Items.Count;
        }

        private void cbDiscount_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                switch (cbDiscount.SelectedIndex)
                {
                    case 0: lvProduct.ItemsSource = Instances.Context.Products.ToList(); break;
                    case 1: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 0 && p.discount <= 10 && p.name.Contains(txtSearch.Text)).ToList(); break;
                    case 2: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 11 && p.discount <= 14 && p.name.Contains(txtSearch.Text)).ToList(); break;
                    case 3: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 15 && p.name.Contains(txtSearch.Text)).ToList(); break;

                }
            }
            else 
            {
                switch (cbDiscount.SelectedIndex)
                {
                    case 0: lvProduct.ItemsSource = Instances.Context.Products.ToList(); break;
                    case 1: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 0 && p.discount <= 10).ToList(); break;
                    case 2: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 11 && p.discount <= 14).ToList(); break;
                    case 3: lvProduct.ItemsSource = Instances.Context.Products.Where(p => p.discount >= 15).ToList(); break;

                }
            }
            lblCount.Content = lvProduct.Items.Count;
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e)
        {
            new OrderListWindow(user).Show();
            Close();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Products product = new Products();
            if (lvProduct.SelectedItem != null)
            {
                product = lvProduct.SelectedItem as Products;
                new AddProductWindow(product).Show();
            }
            else MessageBox.Show("Выберите один из товаров в списке", "Внимание");

        }

        private void cmAdd_Click(object sender, RoutedEventArgs e)
        {
            list.Add(lvProduct.SelectedItem as Products);
        }

        private void btnNewOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow ow = new OrderWindow(list);
            ow.Show();
        }
    }
}
