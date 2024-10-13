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
    /// Interaction logic for FenetrePrepose.xaml
    /// </summary>
    public partial class FenetrePrepose : Window
    {
        public FenetrePrepose()
        {
            InitializeComponent();
        }

        private void btn_recherche_Click(object sender, RoutedEventArgs e)
        {
            frmRecherche frmRecherche = new frmRecherche();
            frmRecherche.Closed += (s, args) => this.Show();
            frmRecherche.Show();
            this.Hide();

        }

        private void btn_admission_Click(object sender, RoutedEventArgs e)
        {
            FenetreAdmission fenetreAdmission = new FenetreAdmission();
            fenetreAdmission.Closed += (s, args) => this.Show();
            fenetreAdmission.Show();
            this.Hide();
        }

        private void btn_back_Click(object sender, RoutedEventArgs e)
        {

            
            this.Close();
        }


      
    }
}
