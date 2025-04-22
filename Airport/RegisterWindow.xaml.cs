using Airport.Data;
using Airport.Models;
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

namespace Airport
{
    /// <summary>
    /// Логика взаимодействия для RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            using var db = new AppDbContext();
            if (db.Users.Any(u => u.Login == LoginBox.Text))
            {
                MessageBox.Show("Такой пользователь уже существует");
                return;
            }

            db.Users.Add(new User { Login = LoginBox.Text, Password = PasswordBox.Password });
            db.SaveChanges();
            MessageBox.Show("Регистрация успешна!");
            new LoginWindow().Show();
            Close();
        }

    }
}
