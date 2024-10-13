using System;
using System.Linq;
using System.Windows;

namespace ProjectFinal
{
    /// <summary>
    /// Logique d'interaction pour frmConge.xaml
    /// </summary>
    public partial class frmConge : Window
    {
        hopitalEntities db;

        public frmConge()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère l'événement du clic sur le bouton "Congé".
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnConge_Click(object sender, RoutedEventArgs e)
        {
            if (dateConge.SelectedDate.HasValue)
            {
                DateTime date = dateConge.SelectedDate.Value;

                bool isValid = true;
                if (isValid)
                {
                    db = new hopitalEntities();
                    var conge = db.Admissions
                                .Include("Patient") // Use the string name of the navigation property
                                .Include("Lit.Departement") // Use the string name of the navigation property and nested property
                                .Where(a => a.NSS == txtNss.Text && a.Date_Du_Conge != null)
                                .FirstOrDefault();

                    if (conge != null)
                    {
                        conge.Date_Du_Conge = dateConge.SelectedDate.Value;
                        conge.Lit.Occupe = false;
                        db.SaveChanges();
                        MessageBox.Show("Date du congé mise à jour avec succès.");
                        Facturation facturation = new Facturation();
                        facturation.facturer(txtNss.Text);

                        txtMontant.Text = facturation.Montant.ToString();

                    }
                    else
                    {
                        MessageBox.Show("Aucun enregistrement trouvé pour mettre à jour la date du congé.");
                    }
                }
                else
                {
                    MessageBox.Show("Date non valide");
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une date.");
            }
        }

        /// <summary>
        /// Gère l'événement du clic sur le bouton "Annuler".
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {

            this.Close();


        }

        /// <summary>
        /// Gère l'événement du clic sur le bouton "Rechercher".
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnRechercher_Click(object sender, RoutedEventArgs e)
        {
            txtNss.Text = txtNss.Text.ToUpper();
            txtNss.Text = txtNss.Text.Replace(" ", "");
            db = new hopitalEntities();
            var query = db.Admissions
                   .Include("Patient")
                   .Include("Lit.Departement")

                   .Where(a => a.NSS == txtNss.Text && a.Date_Du_Conge != null);

            var admission = query.FirstOrDefault();

            if (admission != null)
            {
                txtNss.IsEnabled = false;
                txtPrenom.Text = admission.Patient.Prenom;
                txtNom.Text = admission.Patient.Nom;
                txtBedNumber.Text = admission.Lit.Numero_Lit.ToString();
                txtDepartment.Text = admission.Lit.Departement.Nom_Departement.ToString();
                dateNaissance.SelectedDate = admission.Patient.Date_Naissance;


            }
            else
            {
                MessageBox.Show("Patient non trouvé");
            }

        }

        /// <summary>
        /// Réinitialise les champs du formulaire.
        /// </summary>
        private void clearFields()
        {
            txtNss.IsEnabled = true;
            txtNss.Text = "";
            txtPrenom.Text = "";
            txtNom.Text = "";
            txtBedNumber.Text = "";
            txtDepartment.Text = "";
            dateNaissance.SelectedDate = null;
            dateConge.SelectedDate = null;
        }

        /// <summary>
        /// Gère l'événement du clic sur le bouton "Effacer".
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnEffacer_Click(object sender, RoutedEventArgs e)
        {
            clearFields();
        }

        private void btnList_Click(object sender, RoutedEventArgs e)
        {
            OpenListAdmissionWindow();
        }
        private void OpenListAdmissionWindow()
        {
            ListAdmission window = new ListAdmission(this);
            window.Show();
        }
        public void SetSelectedAdmission(Admission selectedAdmission)
        {
            if (selectedAdmission != null)
            {
                txtNss.IsEnabled = false;
                txtNss.Text = selectedAdmission.NSS;
                txtPrenom.Text = selectedAdmission.Patient.Prenom;
                txtNom.Text = selectedAdmission.Patient.Nom;
                txtBedNumber.Text = selectedAdmission.Lit.Numero_Lit.ToString();
                txtDepartment.Text = selectedAdmission.Lit.Departement.Nom_Departement.ToString();
                dateNaissance.SelectedDate = selectedAdmission.Patient.Date_Naissance;
                // dateConge.SelectedDate = selectedAdmission.Date_Du_Conge;
            }
        }
    }
}


