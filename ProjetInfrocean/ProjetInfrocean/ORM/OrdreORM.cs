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
    public class OrdreORM
    {
        public static OrdreViewModel getOrdre(int id)
        {
            OrdreDAO oDAO = OrdreDAO.getOrdre(id);
            OrdreViewModel o = new OrdreViewModel(oDAO.idDAO, oDAO.nomDAO);
            return o;
        }

        public static ObservableCollection<OrdreViewModel> listeOrdre()
        {
            ObservableCollection<OrdreDAO> listeDAO = OrdreDAO.listeOrdre();
            ObservableCollection<OrdreViewModel> liste = new ObservableCollection<OrdreViewModel>();
            foreach(OrdreDAO element in listeDAO)
            {
                OrdreViewModel o = new OrdreViewModel(element.idDAO, element.nomDAO);
                liste.Add(o);
            }
            return liste;
        }

        public static void updateOrdre(OrdreViewModel o)
        {
            OrdreDAO.updateOrdre(new OrdreDAO(o.idProperty, o.nomProperty));
        }
        public static void supprimerOrdre(int id)
        {
            OrdreDAO.supprimerOrdre(id);
        }
        public static void insertOrdre(OrdreViewModel o)
        {
            OrdreDAO.insertOrdre(new OrdreDAO(o.idProperty, o.nomProperty));
        }
    }
}
