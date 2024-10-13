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

namespace ProjectFinal
{
    /// <summary>
    /// Interaction logic for FenetreAdmin.xaml
    /// </summary>
    public partial class FenetreAdmin : Window
    {
        hopitalEntities db;
        public FenetreAdmin()
        {
            InitializeComponent();
        }

        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {
           
            this.Close();

        }

        private void btnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (employeeDataGrid.SelectedItem != null)
            {
                User user = (User)employeeDataGrid.SelectedItem;
                UpdateWindow updateWindow = new UpdateWindow(user);
                updateWindow.ShowDialog();
                LoadData();
            }
            else
            {
                MessageBox.Show("Veuillez selectionner un utilisateur");
            }
        }

        private void btnAjouter_Click(object sender, RoutedEventArgs e)
        {
            CreateUser createUser = new CreateUser();
            createUser.ShowDialog();
            LoadData();
        }

        private void LoadData()
        {
           db = new hopitalEntities();
            List<User> ListUser = db.Users.ToList();
            employeeDataGrid.ItemsSource = ListUser;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
           LoadData();

        }

       
    }
}

