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
    /// Interaction logic for frmRecherche.xaml
    /// </summary>
    public partial class frmRecherche : Window
    {
       hopitalEntities db;

        /// <summary>
        /// Initializes a new instance of the <see cref="frmRecherche"/> class.
        /// </summary>
        public frmRecherche()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clears les champs de texte.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnEfface_Click(object sender, RoutedEventArgs e)
        {
            txtNss.Text = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            dateNaissance.Text = "";
            txtBedNumber.Text = "";
            txtDepartment.Text = "";
        }

        /// <summary>
        /// Annule la recherche et retourne à la fenêtre précédente.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }

        /// <summary>
        /// Permet de rechercher un patient par son numéro d'assurance maladie.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnRechercher_Click(object sender, RoutedEventArgs e)
        {
            //format du NSS est AAAA 1234 5678 
            string patternNSS = @"^(?i)[A-Za-z]{4}\s*\d{4}\s*\d{4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtNss.Text, patternNSS))
            {
                MessageBox.Show("Le numéro d'assurance maladie doit être de la forme AAAA 1234 5678");
                return;
            }
            if (!string.IsNullOrEmpty(txtNss.Text))
            {
                db = new hopitalEntities();
                var query = db.Admissions
                    .Include("Patient") // Use the string name of the navigation property
                    .Include("Lit.Departement") // Use the string name of the navigation property and nested property
                    .Where(a => a.NSS == txtNss.Text)
                    .FirstOrDefault();
                if (query != null)
                {
                    txtNss.Text = query.NSS;
                    txtNom.Text = query.Patient.Nom;
                    txtPrenom.Text = query.Patient.Prenom;
                    dateNaissance.Text = query.Patient.Date_Naissance.ToString();
                    txtBedNumber.Text = query.Lit.Numero_Lit.ToString();
                    txtDepartment.Text = query.Lit.Departement.Nom_Departement;
                }
                else
                {
                    MessageBox.Show("Le patient n'est pas Admis a l'hopital");
                }
            }
            else
            {
                MessageBox.Show("Le numéro d'assurance maladie est obligatoire");
            }
        }

      
    }
}
