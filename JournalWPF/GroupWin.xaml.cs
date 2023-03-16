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

namespace JournalApp
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class GroupWin : Window
    {
        public GroupWin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Session.CurrentGroup.Student.ToList().ForEach(s =>
            {
                if (!studentsGrid.Items.Contains(s)) studentsGrid.Items.Add(s);
            });
            Session.CurrentGroup.Journal.ToList().ForEach(j =>
            {
                if (!disciplines.Items.Contains(j.Disciplin)) disciplines.Items.Add(j.Disciplin);
            });
        }

        private void studentsGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {

        }
    }
}
