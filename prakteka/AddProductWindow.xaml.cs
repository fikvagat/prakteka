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
    /// Логика взаимодействия для AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        Products prod;
        public AddProductWindow(Products prod)
        {
            InitializeComponent();
            this.prod = prod;
            cbCategory.ItemsSource = Instances.Context.Categories.ToList();
            cbManufacturer.ItemsSource = Instances.Context.Manufacturers.ToList();
            cbProvider.ItemsSource = Instances.Context.Providers.ToList();
            cbUnit.ItemsSource = Instances.Context.Units.ToList();
            if(!string.IsNullOrWhiteSpace(prod.article))
            {
                txtArticle.Text = prod.article;
                txtArticle.IsEnabled = false;
                txtName.Text = prod.name;
                cbUnit.Text = prod.Units.name;
                txtPrice.Text = prod.price.ToString();
                txtMaxDiscount.Text = prod.maxDiscount.ToString();
                cbManufacturer.Text = prod.Manufacturers.name;
                cbProvider.Text = prod.Providers.name;
                cbCategory.Text = prod.Categories.name;
                txtDiscount.Text = prod.discount.ToString();
                txtCount.Text = prod.count.ToString();
                txtDescription.Text = prod.description;
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(prod == null)
                {
                    Products product = new Products();
                    product.article = txtArticle.Text;
                    product.name = txtName.Text;
                    product.unit = (cbUnit.SelectedItem as Units).id;
                    product.price = int.Parse(txtPrice.Text);
                    product.maxDiscount = int.Parse(txtMaxDiscount.Text);
                    product.manufacturer = cbManufacturer.SelectedIndex;
                    product.provider = (cbProvider.SelectedItem as Providers).id;
                    product.category = (cbCategory.SelectedItem as Categories).id;
                    product.discount = int.Parse(txtDiscount.Text);
                    product.count = int.Parse(txtCount.Text);
                    product.description = txtDescription.Text;
                    product.image = "C:\\Users\\fikva\\OneDrive\\Рабочий стол\\a\\picture.png";
                    Instances.Context.Products.Add(product);
                    Instances.Context.SaveChanges();
                    MessageBox.Show("Продукт успешно добавлен", "Внимание");
                }
                else
                {
                    Products product = Instances.Context.Products.Where(p => p.article == prod.article).FirstOrDefault();
                    product.article = txtArticle.Text;
                    product.name = txtName.Text;
                    product.unit = (cbUnit.SelectedItem as Units).id;
                    product.price = int.Parse(txtPrice.Text);
                    product.maxDiscount = int.Parse(txtMaxDiscount.Text);
                    product.manufacturer = (cbManufacturer.SelectedItem as Manufacturers).id;
                    product.provider = (cbProvider.SelectedItem as Providers).id;
                    product.category = (cbCategory.SelectedItem as Categories).id;
                    product.discount = int.Parse(txtDiscount.Text);
                    product.count = int.Parse(txtCount.Text);
                    product.description = txtDescription.Text;
                    Instances.Context.SaveChanges();
                    MessageBox.Show("Продукт успешно изменён", "Внимание");
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
