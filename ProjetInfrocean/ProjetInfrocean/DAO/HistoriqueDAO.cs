using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class HistoriqueDAO
    {
        public int idHistoriqueDAO;
        public DateTime dateCreaDAO;
        public DateTime dateFinDAO;
        public int idSaisonHistoriqueDAO;
        public int idEtudeHistoriqueDAO;

        public HistoriqueDAO(int idHistoriqueDAO, DateTime dateCreaDAO, DateTime dateFinDAO, int idSaisonHistoriqueDAO, int idEtudeHistoriqueDAO)
        {
            this.idHistoriqueDAO = idHistoriqueDAO;
            this.dateCreaDAO = dateCreaDAO;
            this.dateFinDAO = dateFinDAO;
            this.idSaisonHistoriqueDAO = idSaisonHistoriqueDAO;
            this.idEtudeHistoriqueDAO = idEtudeHistoriqueDAO;
        }

        public static ObservableCollection<HistoriqueDAO> listeHistoriques(){
            ObservableCollection<HistoriqueDAO> liste = HistoriqueDAL.selectHistoriques();
            return liste;
        }
        public static HistoriqueDAO getHistorique(int idHistorique)
        {
            HistoriqueDAO c = HistoriqueDAL.getHistorique(idHistorique);
            return c;
        }
        public static void updateHistorique(HistoriqueDAO c)
        {
            HistoriqueDAL.updateHistorique(c);
            
        }
        public static void supprimerHistorique(int idHistorique)
        {
            HistoriqueDAL.supprimerHistorique(idHistorique);

        }
        public static void insertHistorique(HistoriqueDAO c)
        {
            HistoriqueDAL.insertHistorique(c);

        }
    }
}
