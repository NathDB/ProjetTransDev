using ProjetInfrocean.Ctrl;
using ProjetInfrocean.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.ORM
{
    public class HistoriqueORM
    {
        public static HistoriqueViewModel getHistorique(int idHistorique)
        {
            HistoriqueDAO cDAO = HistoriqueDAO.getHistorique(idHistorique);
            HistoriqueViewModel c = new HistoriqueViewModel(cDAO.idHistoriqueDAO, cDAO.dateCreaDAO, cDAO.dateFinDAO, cDAO.idSaisonHistoriqueDAO, cDAO.idEtudeHistoriqueDAO);
            return c;
        }

        public static ObservableCollection<HistoriqueViewModel> listeHistoriques()
        {
            ObservableCollection<HistoriqueDAO> listeDAO = HistoriqueDAO.listeHistoriques();
            ObservableCollection<HistoriqueViewModel> liste = new ObservableCollection<HistoriqueViewModel>();
            foreach(HistoriqueDAO element in listeDAO)
            {
                HistoriqueViewModel c = new HistoriqueViewModel(element.idHistoriqueDAO, element.dateCreaDAO, element.dateFinDAO, element.idSaisonHistoriqueDAO, element.idEtudeHistoriqueDAO);
                liste.Add(c);
            }
            return liste;
        }

        public static void updateHistorique(HistoriqueViewModel c)
        {
            HistoriqueDAO.updateHistorique(new HistoriqueDAO(c.idHistoriqueProperty, c.dateCreaProperty, c.dateFinProperty, c.idSaisonHistoriqueProperty, c.idEtudeHistoriqueProperty));
        }
        public static void supprimerHistorique(int idHistorique)
        {
            HistoriqueDAO.supprimerHistorique(idHistorique);
        }
        public static void insertHistorique(HistoriqueViewModel c)
        {
            HistoriqueDAO.insertHistorique(new HistoriqueDAO(c.idHistoriqueProperty, c.dateCreaProperty, c.dateFinProperty, c.idSaisonHistoriqueProperty, c.idEtudeHistoriqueProperty));
        }
    }
}
