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

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WpfApp2.Session1_XXDataSet session1_XXDataSet = ((WpfApp2.Session1_XXDataSet)(this.FindResource("session1_XXDataSet")));
            // Загрузить данные в таблицу Users. Можно изменить этот код как требуется.
            WpfApp2.Session1_XXDataSetTableAdapters.UsersTableAdapter session1_XXDataSetUsersTableAdapter = new WpfApp2.Session1_XXDataSetTableAdapters.UsersTableAdapter();
            session1_XXDataSetUsersTableAdapter.Fill(session1_XXDataSet.Users);
            System.Windows.Data.CollectionViewSource usersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("usersViewSource")));
            usersViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var window = new AddUser();
            window.Show();
            this.Close();
        }
    }
}
