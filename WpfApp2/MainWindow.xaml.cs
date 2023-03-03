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
using WpfApp2.Session1_XXDataSetTableAdapters;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        UsersTableAdapter session1_XXDataSetUsersTableAdapter;
        public MainWindow()
        {
            InitializeComponent();
            session1_XXDataSetUsersTableAdapter = new UsersTableAdapter();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int roleId;
          var roleQuery =  session1_XXDataSetUsersTableAdapter.Auth(UserName.Text, Password.Text);
            if (roleQuery != null)
            {
                roleId = (int)roleQuery;
                if(roleId == 1)
                {
                    AdminWindow window = new AdminWindow();
                    window.Show();
                    this.Close();
                }

            }

        }

    }
}
