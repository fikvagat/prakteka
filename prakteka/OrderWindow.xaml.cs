using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
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
    /// Логика взаимодействия для OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        Products prod = new Products();
         public static ObservableCollection<Products> collection = new ObservableCollection<Products>();
        List<Products> order = new List<Products>();
        Users user = new Users();
        public OrderWindow(List<Products> order)
        {
            InitializeComponent();
            foreach (Products p in order)
                p.count = 1;
            //collection.CollectionChanged += new NotifyCollectionChangedEventHandler()
            dgOrder.ItemsSource = order;
            cbPI.ItemsSource = Instances.Context.PointsOfIssue.ToList();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Orders ord = new Orders();
                ord.dateOfOrder = DateTime.Now.Date;
                ord.dateOfDelivery = DateTime.Now.AddDays(7);
                ord.pointOfIssue = (cbPI.SelectedItem as PointsOfIssue).id;
                if (user.id != 0)
                    ord.client = user.id;
                Random rand = new Random();
                ord.codeToGet = rand.Next(100, 999);
                ord.Status = 1;
                Instances.Context.Orders.Add(ord);
                Instances.Context.SaveChanges();
                foreach (Products p in order)
                {
                    ProductsInOrder pio = new ProductsInOrder();
                    pio.productArticle = p.article;
                    pio.orderID = ord.id;
                    pio.count = p.count;
                    Instances.Context.ProductsInOrder.Add(pio);
                }
                Instances.Context.SaveChanges();
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
        private void getCost()
        {
            //double cost = collection.Sum(p => p.)
        } 
    }
}
