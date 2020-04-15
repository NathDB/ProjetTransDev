using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class SaisonDAO
    {
        public int idDAO;
        public string saisonDAO;

        public SaisoneDAO(int idDAO, string saisonDAO)
        {
            this.idDAO = idDAO;
            this.saisonDAO = saisonDAO;
        }

        public static ObservableCollection<SaisonDAO> listeSaison(){
            ObservableCollection<SaisonDAO> liste = SaisonDAL.selectSaison();
            return liste;
        }
        public static SaisonDAO getSaison(int id)
        {
            SaisonDAO s = SaisonDAL.getSaison(id);
            return s;
        }
        public static void updateSaison(SaisonDAO s)
        {
            SaisonDAL.updateSaison(s);
            
        }
        public static void supprimerSaison(int id)
        {
            SaisonDAL.supprimerSaison(id);

        }
        public static void insertSaison(SaisonDAO s)
        {
            SaisonDAL.insertSaison(s);

        }
    }
}
