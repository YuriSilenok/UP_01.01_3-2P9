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

namespace JournalApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class AuthorizationWin : Window
    {
        public AuthorizationWin()
        {
            InitializeComponent();
        }

        private void SingInButtonClick(object sender, RoutedEventArgs e)
        {

            var users = Session.DB.User.Where(u => u.UserName == loginInput.Text.Trim() && u.Password == passInput.Password.Trim());
            if (users.Count() == 1)
            {
                Session.CurrentUser = users.First();
                GroupsWin newWin = new GroupsWin();
                Hide();
                newWin.ShowDialog();
                Show();
            }
            else MessageBox.Show("Не верный логин или пароль");
        }

        private void SingUpButtonClick(object sender, RoutedEventArgs e)
        {
            User newUser = new User { UserName = loginInput.Text.Trim(), Password = passInput.Password.Trim() };

            Session.DB.User.Add(newUser);
            Session.DB.SaveChanges();
            MessageBox.Show("Пользователь зарегистрирован");
        }
    }
}
