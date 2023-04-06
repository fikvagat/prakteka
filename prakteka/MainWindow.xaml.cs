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

namespace prakteka
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            Users user = Instances.Context.Users.Where(p => p.login == txtLogin.Text && p.password == txtPass.Password).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show("Успешная авторизация", "Внимание");
                new ProductListWindow(user).Show();
                this.Close();
            }
            else MessageBox.Show("Неверный логин или пароль", "Внимание");
        }

        private void btnGuest_Click(object sender, RoutedEventArgs e)
        {
            Users user = new Users();
            new ProductListWindow(user).Show();
            this.Close();
        }
    }
}
