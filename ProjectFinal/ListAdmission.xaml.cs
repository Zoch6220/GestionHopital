using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Interaction logic for ListAdmission.xaml
    /// </summary>
    public partial class ListAdmission : Window
    {
        private hopitalEntities db;
        private frmConge congeWindow;
        public ListAdmission(frmConge congeWindow)
        {
            InitializeComponent();
            this.congeWindow = congeWindow;
            LoadData();
        }
        public void LoadData()
        {
            db = new hopitalEntities();
            var admissions = db.Admissions
                .Include("Patient")
                .Include("Lit.Departement").Where(l=>l.Lit.Occupe == true)
                .ToList();
            admissionDataGrid.ItemsSource = admissions;
        }
        private void SelectAdmission_Click(object sender, RoutedEventArgs e)
        {
            var selectedAdmission = admissionDataGrid.SelectedItem as Admission;
            if (selectedAdmission != null)
            {
                congeWindow.SetSelectedAdmission(selectedAdmission);
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select an admission.");
            }
        }
    }
}
