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
    /// Interaction logic for UpdateWindow.xaml
    /// </summary>
    public partial class UpdateWindow : Window
    {
        hopitalEntities db;
        User user;
        public UpdateWindow(User user)
        {
            InitializeComponent();
            this.user = user;
            LoadUser();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            db = new hopitalEntities();

            if (user != null)
            {
                var modifierUser = db.Users.FirstOrDefault(p => p.UserId == user.UserId);

                if (modifierUser != null)
                {
                    modifierUser.Login = txtLogin.Text;
                    modifierUser.Password = txtPassword.Password;
                    modifierUser.Nom = txtNom.Text;
                    modifierUser.Prenom = txtPrenom.Text;
                    LoadUser();
                    db.SaveChanges();
                    MessageBox.Show("L'utilisateur a été modifier");
                }
            }
            else
            {
                // Handle the case where user is null
                MessageBox.Show("User is not initialized.");
            }
        }
        private void LoadUser() {
                txtLogin.Text = user.Login;
                txtPassword.Password = user.Password;
                txtNom.Text = user.Nom;
                txtPrenom.Text = user.Prenom;
                cboxRole.Text = user.Role;
           


        }
        
    }
}
