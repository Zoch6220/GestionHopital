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
    /// Interaction logic for CreateUser.xaml
    /// </summary>
    public partial class CreateUser : Window
    {
        hopitalEntities db;
        public CreateUser()
        {
            InitializeComponent();
            LoadRole();
            db = new hopitalEntities();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                User newUser = new User
                {
                    Login = txtLogin.Text,
                    Password = txtPassword.Password,
                    Nom = txtNom.Text,
                    Prenom = txtPrenom.Text,
                    Role = cboxRole.SelectedItem.ToString()
                };
                if (newUser.Role == "medecin")
                {
                    Medecin medecin = new Medecin
                    {
                        Nom = txtNom.Text,
                        Prenom = txtPrenom.Text
                    };
                    db.Medecins.Add(medecin);
                    newUser.Medecin = medecin;
                    db.SaveChanges();
                }
                db.Users.Add(newUser);
                db.SaveChanges();
                MessageBox.Show("User created successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);              
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error creating user: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void LoadRole()
        {
            List<string> roles = new List<string>
            {
                "admin",
                "prepose",
                "medecin"
            };
            cboxRole.ItemsSource = roles;
        }

    }
}
    



