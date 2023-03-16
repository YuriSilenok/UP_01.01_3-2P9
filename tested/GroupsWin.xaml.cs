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

namespace tested
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class GroupsWin : Window
    {
        public GroupsWin()
        {
            InitializeComponent();
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (var db = new Entities1())
            {
                Session.CurrentUser.Journal.ToList().ForEach(j => 
                {
                    if (!groups.Items.Contains(j.Group)) groups.Items.Add(j.Group);
                });
            }

        }

        private void groups_Selected(object sender, RoutedEventArgs e)
        {
            GroupWin window = new GroupWin();
        }

        private void filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            groups.Items.Clear();
            Session.CurrentUser.Journal.ToList().ForEach(j =>
            {
                if (!groups.Items.Contains(j.Group) && j.Group.Code.Contains(filter.Text)) groups.Items.Add(j.Group);
            });


        }
    }
}
