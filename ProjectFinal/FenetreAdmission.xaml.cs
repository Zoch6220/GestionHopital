using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProjectFinal
{
    /// <summary>
    /// Interaction logic for FenetreAdmission.xaml
    /// </summary>

    public partial class FenetreAdmission : Window
    {
        hopitalEntities db;

        /// <summary>
        /// Chargement de la fenêtre.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            db = new hopitalEntities();
            LoadDepartement();
            LoadLit();
            LoadMedecin();
            LoadAssurance();
            dateNaissance.BlackoutDates.Add(new CalendarDateRange(DateTime.Now.AddDays(1), DateTime.MaxValue));
        }

        /// <summary>
        /// Constructeur de la fenêtre.
        /// </summary>
        public FenetreAdmission()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gère le clic sur le bouton "Trouver".
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = db.Patients.FirstOrDefault((Patient p) => p.NSS == txtNss.Text);
            if (patient != null)
            {
                txtNom.Text = patient.Nom;
                txtPrenom.Text = patient.Prenom;
                txtNss.IsEnabled = false;
                txtPrenom.IsEnabled = false;
                txtNom.IsEnabled = false;
                dateNaissance.SelectedDate = patient.Date_Naissance;
                dateNaissance.IsEnabled = false;
                txtAdresse.Text = patient.Adresse;
                txtVille.Text = patient.Ville;
                txtProvince.Text = patient.Province;
                txtPostal.Text = patient.Code_Postal;
                txtTelephone.Text = patient.Telephone;
                txtTelephone.Text = txtTelephone.Text.Insert(0, "(");
                txtTelephone.Text = txtTelephone.Text.Insert(4, ") ");
                txtTelephone.Text = txtTelephone.Text.Insert(9, "-");
                cboxAssurance.SelectedValue = patient.ID_Assurance;
                CheckAge(patient);
                btnUpdate.IsEnabled = true;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Patient non trouvé, voulez-vous le créer?", "Patient non trouvé", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                {
                    btnCree.IsEnabled = true;
                }
            }
        }

        /// <summary>
        /// Gère le clic sur le bouton "Créer".
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnCree_Click(object sender, RoutedEventArgs e)
        {
            Patient patient = new Patient();
            //format du NSS est AAAA 1234 5678 
            string patternNSS = @"^(?i)[A-Za-z]{4}\s*\d{4}\s*\d{4}$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtNss.Text, patternNSS))
            {
                MessageBox.Show("Le numéro d'assurance maladie doit être de la forme AAAA 1234 5678");
                return;
            }

            patient.NSS = (txtNss.Text).ToUpper().Replace(" ", "");
            patient.Nom = txtNom.Text;
            patient.Prenom = txtPrenom.Text;
            if (dateNaissance.SelectedDate.HasValue)
            {
                DateTime date = dateNaissance.SelectedDate.Value;
                if (date > DateTime.Now)
                {
                    MessageBox.Show("Date de naissance non valide");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Veuillez entrer une date de naissance");
                return;
            }
            patient.Date_Naissance = dateNaissance.SelectedDate.Value;
            patient.Adresse = txtAdresse.Text;
            patient.Ville = txtVille.Text;
            patient.Province = txtProvince.Text;
            //format du code postal est A1A 1A1
            string patternCodePostal = @"^(?i)[ABCEGHJKLMNPRSTVXY]\d[A-Za-z] ?\d[A-Za-z]\d$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtPostal.Text, patternCodePostal))
            {
                MessageBox.Show("Le code postal doit être de la forme A1A 1A1");
                return;
            }
            patient.Code_Postal = txtPostal.Text.ToUpper().Replace(" ", "");
            //format du telephone est (123) 456-7890
            string patternTelephone = @"^(\(?\d{3}\)?[-.\s]?)(\d{3})[-.\s]?(\d{4})$";
            if (!System.Text.RegularExpressions.Regex.IsMatch(txtTelephone.Text, patternTelephone))
            {
                MessageBox.Show("Le numéro de téléphone doit être de la forme (123) 456-7890");
                return;
            }
            txtTelephone.Text = txtTelephone.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "");
            patient.Telephone = txtTelephone.Text;
            patient.ID_Assurance = (int)cboxAssurance.SelectedValue;
            db.Patients.Add(patient);
            db.SaveChanges();
            MessageBox.Show("Patient ajouté avec succès");
            CheckAge(patient);
        }

        /// <summary>
        /// Gère le clic sur le bouton "Annuler".
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btn_annuler_Click(object sender, RoutedEventArgs e)
        {
            EffaceTout();
        }

        /// <summary>
        /// Efface tous les champs de la fenêtre.
        /// </summary>
        private void EffaceTout()
        {
            cboxDep.IsEnabled = true;
            txtNss.Text = "";
            txtNom.Text = "";
            txtPrenom.Text = "";
            dateNaissance.SelectedDate = null;
            txtAdresse.Text = "";
            txtVille.Text = "";
            txtProvince.Text = "";
            txtPostal.Text = "";
            txtTelephone.Text = "";
            cboxAssurance.SelectedIndex = -1;
            radioNonOpe.IsChecked = false;
            radioOuiOpe.IsChecked = false;
            dateOperation.SelectedDate = null;
            chkTelephone.IsChecked = false;
            chkTelevision.IsChecked = false;
            cboxDep.SelectedIndex = -1;
            cboxMedecin.SelectedIndex = -1;
            cboxLit.SelectedIndex = -1;
            txtNom.IsEnabled = true;
            txtPrenom.IsEnabled = true;
            dateNaissance.IsEnabled = true;
            txtNss.IsEnabled = true;
            LoadLit();
            LoadMedecin();
            LoadAssurance();
            LoadDepartement();
        }
        private void btn_admin_Click(object sender, RoutedEventArgs e)
        {
            if (!CheckEmpty())
            {
                MessageBox.Show("Veuillez remplir tous les champs");
                return;
            }
            var patient = db.Patients.FirstOrDefault((Patient p) => p.NSS == txtNss.Text);
            if (patient == null)
            {
                MessageBox.Show("Patient non trouvé, veuillez le créer");
                return;
            }

            var admission = new Admission();
            admission.NSS = (txtNss.Text).ToUpper().Replace(" ", "");
            admission.Numero_Lit = (int)cboxLit.SelectedValue;
            admission.ID_Medecin = (int)cboxMedecin.SelectedValue;
            admission.Date_Admission = DateTime.Now;

            if (radioOuiOpe.IsChecked == true)
            {
                admission.Chirurgie_Programmee = true;
                admission.Date_Chirurgie = dateOperation.SelectedDate.Value;
                //var query = db.Lits.Where(d => d.ID_Departement == 3 && d.Occupe == false);

                //if (query.Count() >= 0)
                //{
                //    cboxLit.ItemsSource = query.ToList();
                //    cboxDep.SelectedIndex = 2;
                //    cboxDep.IsEnabled = false;
                //}

            }
            else
            {
                admission.Chirurgie_Programmee = false;
            }
            if (chkTelephone.IsChecked == true)
            {
                admission.Telephone = true;
            }
            else
            {
                admission.Telephone = false;
            }
            if (chkTelevision.IsChecked == true)
            {
                admission.Televiseur = true;
            }
            else
            {
                admission.Televiseur = false;
            }

            db.Admissions.Add(admission);
            db.SaveChanges();
            var lit = db.Lits.FirstOrDefault(l => l.Numero_Lit == admission.Numero_Lit);
            lit.Occupe = true;
            LoadLit();
            db.SaveChanges();
            MessageBox.Show("Admission ajoutée avec succès");
            EffaceTout();
        }
        /// <summary>
        /// Gère la sélection d'un département dans la liste déroulante.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void cboxDep_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxDep.SelectedValue != null)
            {
                cboxLit.ItemsSource = db.Lits.Where(l => l.ID_Departement == (int)cboxDep.SelectedValue && l.Occupe == false).ToList();
            }
        }

        /// <summary>
        /// Gère le clic sur le bouton "Retour".
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnRetour_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        /// <summary>
        /// Charge les départements dans la liste déroulante.
        /// </summary>
        private void LoadDepartement()
        {
            cboxDep.ItemsSource = db.Departements.ToList();
            cboxDep.DisplayMemberPath = "Nom_Departement";
            cboxDep.SelectedValuePath = "ID_Departement";
        }

        /// <summary>
        /// Charge les lits dans la liste déroulante.
        /// </summary>
        private void LoadLit()
        {
            cboxLit.ItemsSource = db.Lits.Include("TypeLit").Where(l => l.Occupe == false).ToList();
            cboxLit.DisplayMemberPath = "NumAndType";
            cboxLit.SelectedValuePath = "Numero_Lit";
        }

        /// <summary>
        /// Charge les médecins dans la liste déroulante.
        /// </summary>
        private void LoadMedecin()
        {
            cboxMedecin.ItemsSource = db.Medecins.ToList();
            cboxMedecin.DisplayMemberPath = "NomComplet";
            cboxMedecin.SelectedValuePath = "ID_Medecin";
        }

        /// <summary>
        /// Charge les assurances dans la liste déroulante.
        /// </summary>
        private void LoadAssurance()
        {
            cboxAssurance.ItemsSource = db.Assurances.ToList();
            cboxAssurance.DisplayMemberPath = "Nom_Compagnie";
            cboxAssurance.SelectedValuePath = "ID_Assurance";
        }

        /// <summary>
        /// Vérifie l'âge du patient et restreint la sélection du département s'il a moins de 16 ans.
        /// </summary>
        /// <param name="patient">Le patient dont l'âge doit être vérifié.</param>
        private void CheckAge(Patient patient)
        {
            int age = DateTime.Now.Year - patient.Date_Naissance.Year;
            // Si le patient a moins de 16 ans, on ne lui permet pas de choisir un département, seulement le département de pédiatrie
            var departementPediatrie = db.Departements.FirstOrDefault(d => d.Nom_Departement == "Pédiatrie");
            if (age <= 16)
            {
                cboxDep.SelectedValue = departementPediatrie.ID_Departement;
                cboxDep.IsEnabled = false;
                cboxLit.ItemsSource = db.Lits.Where(l => l.ID_Departement == departementPediatrie.ID_Departement).ToList();
            }
        }

        /// <summary>
        /// Vérifie si tous les champs sont remplis.
        /// </summary>
        /// <returns>True si tous les champs sont remplis, sinon False.</returns>
        private bool CheckEmpty()
        {
            if (txtNss.Text == "" || txtNom.Text == "" || txtPrenom.Text == "" || dateNaissance.SelectedDate == null || txtAdresse.Text == "" || txtVille.Text == "" || txtProvince.Text == "" || txtPostal.Text == "" || txtTelephone.Text == "" || cboxAssurance.SelectedIndex == -1 || cboxDep.SelectedIndex == -1 || cboxLit.SelectedIndex == -1 || cboxMedecin.SelectedIndex == -1)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Empêche l'utilisateur de saisir des chiffres dans les champs de texte.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Vérifie si l'entrée est un chiffre
            if (e.Text.Any(char.IsDigit))
            {
                e.Handled = true; // Marque l'événement comme géré pour empêcher l'entrée
            }
        }

        /// <summary>
        /// Met à jour les informations du patient dans la base de données.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement.</param>
        /// <param name="e">Les arguments de l'événement.</param>
        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var patient = db.Patients.FirstOrDefault(p => p.NSS == txtNss.Text);
            if (patient != null)
            {
                patient.Adresse = txtAdresse.Text;
                patient.Ville = txtVille.Text;
                patient.Province = txtProvince.Text;
                patient.Code_Postal = txtPostal.Text;
                patient.Telephone = txtTelephone.Text;
                patient.ID_Assurance = (int)cboxAssurance.SelectedValue;
                db.SaveChanges();
                MessageBox.Show("Patient modifié avec succès");
            }
        }

        private void radioOuiOpe_Checked(object sender, RoutedEventArgs e)
        {
            var query = db.Lits.Where(d => d.ID_Departement == 3 && d.Occupe == false);

            if (query.Count() >= 0)
            {
                cboxLit.ItemsSource = query.ToList();
                cboxDep.SelectedIndex = 2;
                cboxDep.IsEnabled = false;
            }
        }

        private void radioNonOpe_Checked(object sender, RoutedEventArgs e)
        {
            cboxDep.IsEnabled = true;
            LoadLit();
        }
    }
}
