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
    public class SaisonORM
    {
        public static SaisonViewModel getSaison(int id)
        {
            SaisonDAO sDAO = SaisonDAO.getSaison(id);
            SaisonViewModel s = new SaisonViewModel(sDAO.idDAO, sDAO.saisonDAO);
            return s;
        }

        public static ObservableCollection<SaisonViewModel> listeSaison()
        {
            ObservableCollection<SaisonDAO> SaisonDAO = SaisonDAO.listeSaison();
            ObservableCollection<SaisonViewModel> liste = new ObservableCollection<SaisonViewModel>();
            foreach(SaisonDAO element in listeDAO)
            {
                SaisonViewModel s = new SaisonViewModel(element.idDAO, element.saisonDAO);
                liste.Add(s);
            }
            return liste;
        }

        public static void updateSaison(SaisonViewModel s)
        {
            SaisonDAO.updateSaison(new SaisonDAO(s.idProperty, s.saisonProperty));
        }
        public static void supprimerSaison(int id)
        {
            SaisonDAO.supprimerSaison(id);
        }
        public static void insertSaison(SaisonViewModel s)
        {
            SaisonDAO.insertSaison(new SaisonDAO(s.idProperty, s.saisonProperty));
        }
    }
}
