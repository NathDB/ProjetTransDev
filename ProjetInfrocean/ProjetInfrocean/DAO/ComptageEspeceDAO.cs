using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class ComptageEspeceDAO
    {
        public int idComptageEspeceDAO;
        public int idEspeceDAO;
        public int idComptageDAO;
        public int quantiteDAO;
        
        public ComptageEspeceDAO(int idComptageEspeceDAO, int idEspeceDAO, int idComptageDAO, int quantiteDAO)
        {
            this.idComptageEspeceDAO = idComptageEspeceDAO;
            this.idEspeceDAO = idEspeceDAO;
            this.idComptageDAO = idComptageDAO;
            this.quantiteDAO = quantiteDAO;  
        }

        public static ObservableCollection<ComptageEspeceDAO> listeComptageEspeces()
        {
            ObservableCollection<ComptageEspeceDAO> l = ComptageEspeceDAL.selectComptageEspeces();
            return l;
        }
        public static ComptageEspeceDAO getComptageEspece(int idComptageEspece)
        {
            ComptageEspeceDAO cp = ComptageEspeceDAL.getComptageEspece(idComptageEspece);
            return cp;
        }

        public static void updateComptageEspece(ComptageEspeceDAO cp)
        {
            ComptageEspeceDAL.updateComptageEspece(cp);
        }

        public static void supprimerComptageEspece(int id)
        {
            ComptageEspeceDAL.supprimerComptageEspece(id);
        }

        public static void insertComptageEspece(ComptageEspeceDAO cp)
        {
            ComptageEspeceDAL.insertComptageEspece(cp);
        }
    }
}
