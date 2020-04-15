using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class ComptageDAO
    {
        public int idComptageDAO;
        public DateTime dateDebutDAO;
        public DateTime dateFinDAO;
        public Boolean statutDAO;
        public int idZoneComptageDAO;
        
        public ComptageDAO(int idComptageDAO, DateTime dateDebutDAO, DateTime dateFinDAO, Boolean statutDAO, int idZoneComptageDAO)
        {
            this.idZoneComptageDAO = idComptageDAO;
            this.dateDebutDAO = dateDebutDAO;
            this.dateFinDAO = dateFinDAO;
            this.statutDAO = statutDAO;
            this.idZoneComptageDAO = idZoneComptageDAO;
        }

        public static ObservableCollection<ComptageDAO> listeComptages()
        {
            ObservableCollection<ComptageDAO> l = ComptageDAL.selectComptages();
            return l;
        }
        public static ComptageDAO getComptage(int idComptage)
        {
            ComptageDAO cp = ComptageDAL.getComptage(idComptage);
            return cp;
        }

        public static void updateComptage(ComptageDAO cp)
        {
            ComptageDAL.updateComptage(cp);
        }

        public static void supprimerComptage(int id)
        {
            ComptageDAL.supprimerComptage(id);
        }

        public static void insertComptage(ComptageDAO cp)
        {
            ComptageDAL.insertComptage(cp);
        }
    }
}
