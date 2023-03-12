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
using WpfApp2.AppDataFile;
using WpfApp2.Session1_XXDataSetTableAdapters;

namespace WpfApp2
{

    /// <summary>
    /// Логика взаимодействия для AddUser.xaml
    /// </summary>
    public partial class AddUser : Window
    {
        UsersTableAdapter session1_XXDataSetUsersTableAdapter;

        public AddUser()
        {
            InitializeComponent();
            session1_XXDataSetUsersTableAdapter = new UsersTableAdapter();
            //OfficeCB.SelectedValuePath = session1_XXDataSetUsersTableAdapter.GetId();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            WpfApp2.Session1_XXDataSet session1_XXDataSet = ((WpfApp2.Session1_XXDataSet)(this.FindResource("session1_XXDataSet")));
            // Загрузить данные в таблицу Offices. Можно изменить этот код как требуется.
            WpfApp2.Session1_XXDataSetTableAdapters.OfficesTableAdapter session1_XXDataSetOfficesTableAdapter = new WpfApp2.Session1_XXDataSetTableAdapters.OfficesTableAdapter();
            session1_XXDataSetOfficesTableAdapter.Fill(session1_XXDataSet.Offices);
            System.Windows.Data.CollectionViewSource officesViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("officesViewSource")));
            officesViewSource.View.MoveCurrentToFirst();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           // session1_XXDataSetUsersTableAdapter.InsertQuery(1, EmailText.Text, Password.Text, FirstName.Text, LastName.Text, (int)officesComboBox.SelectedValue, BirthDate.Text, true);
            var user = new Users()
            {
                RoleID = 1,
                Email = EmailText.Text,
                Password = Password.Text,
                FirstName = FirstName.Text,
                LastName = LastName.Text,
                OfficeID = (int)officesComboBox.SelectedValue,
                Birthdate = BirthDate.SelectedDate,
                Active = true,
            };
            ConnectOdb.conObj.Users.Add(user);
            ConnectOdb.conObj.SaveChanges();
            MessageBox.Show("Uspex");
        }
    }
}
