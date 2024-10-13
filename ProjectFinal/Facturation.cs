using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFinal
{
    public class Facturation
    {
        public DateTime DateAdmission { get; set; }
        public DateTime DateSortie { get; set; }
        public bool Telephone { get; set; }
        public bool Televiseur { get; set; }
        public bool Surclassement { get; set; }
        public int TypeChambre { get; set; }
        public double Montant { get; set; }


        public void facturer(string assMaladie)
        {
            //Calculer le montant de la facture
            hopitalEntities db = new hopitalEntities();
            var query =db.Admissions
                .Include("Lit")
                
                .Where(a => a.NSS == assMaladie).FirstOrDefault();

            if (query != null) {
                DateAdmission = query.Date_Admission;
                DateSortie =(DateTime) query.Date_Du_Conge;
                Telephone = (bool)query.Telephone;
                Televiseur = (bool)query.Televiseur;
                
                TypeChambre =(int) query.Lit.ID_Type;
            }

            TimeSpan duree = DateSortie - DateAdmission;
            
            if (TypeChambre == 1)
            {
                Montant = 0 * duree.Days;
            }
            else if (TypeChambre == 2)
            {
                Montant = 267 * duree.Days;
            }
            else if (TypeChambre == 3)
            {
                Montant = 571 * duree.Days;
            }

            if (Telephone)
            {
                Montant += 7.50 * duree.Days;
            }
            if (Televiseur)
            {
                Montant += 42.50 * duree.Days;
            }
        }
    }
}
