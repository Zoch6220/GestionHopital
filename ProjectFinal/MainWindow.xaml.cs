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

namespace ProjectFinal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        hopitalEntities context;
       
        GestionUser users;

        /// <summary>
        /// Chargement de la fenêtre principale.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            context = new hopitalEntities();
            users = GestionUser.Instance;
            List<User> usersList = context.Users.ToList();
            users.SetUsers(usersList);
        }

        /// <summary>
        /// Constructeur de la classe MainWindow.
        /// </summary>
       public MainWindow()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Gestion de l'événement du bouton "OK".
        /// </summary>
        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            string login = txtUser.Text;
            string password = txtPass.Password;

            if (!string.IsNullOrEmpty(login) && !string.IsNullOrEmpty(password))
            {
                User userRechercher = users.FindUser(login, password);
                if (userRechercher != null)
                {
                    txtPass.Password = "";
                    txtUser.Text = "";
                    if (userRechercher.Role == "admin")
                    {
                        FenetreAdmin fenetreAdmin = new FenetreAdmin();
                        fenetreAdmin.Closed += (s, args) => this.Show();
                        fenetreAdmin.Show();
                        this.Hide();
                    }
                    else if (userRechercher.Role == "prepose")
                    {
                        FenetrePrepose fenetrePrepose = new FenetrePrepose();
                        fenetrePrepose.Closed += (s, args) =>this.Show();
                        fenetrePrepose.Show();
                        this.Hide();
                    }
                    else if (userRechercher.Role == "medecin")
                    {
                        frmConge conge = new frmConge();
                        conge.Closed += (s, args) => this.Show();
                        conge.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Utilisateur ou mot de passe incorrect", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplir tous les champs", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Gestion de l'événement du bouton "Annuler".
        /// </summary>
        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
