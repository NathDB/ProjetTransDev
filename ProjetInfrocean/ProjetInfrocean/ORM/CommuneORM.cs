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
    public class CommuneORM
    {
        public static CommuneViewModel getCommune(int id)
        {
            CommuneDAO cDAO = CommuneDAO.getCommune(id);
            CommuneViewModel c = new CommuneViewModel(cDAO.idDAO, cDAO.idDepartementDAO, cDAO.codePostalDAO, cDAO.nomDAO);
            return c;
        }

        public static ObservableCollection<CommuneViewModel> listeCommunes()
        {
            ObservableCollection<CommuneDAO> listeDAO = CommuneDAO.listeCommunes();
            ObservableCollection<CommuneViewModel> liste = new ObservableCollection<CommuneViewModel>();
            foreach(CommuneDAO element in listeDAO)
            {
                CommuneViewModel c = new CommuneViewModel(element.idDAO, element.idDepartementDAO, element.codePostalDAO, element.nomDAO);
                liste.Add(c);
            }
            return liste;
        }

        public static void updateCommune(CommuneViewModel c)
        {
            CommuneDAO.updateCommune(new CommuneDAO(c.idProperty, c.idDepartementProperty, c.codePostalProperty, c.nomProperty));
        }
        public static void supprimerCommune(int id)
        {
            CommuneDAO.supprimerCommune(id);
        }
        public static void insertCommune(CommuneViewModel c)
        {
            CommuneDAO.insertCommune(new CommuneDAO(c.idProperty, c.idDepartementProperty, c.codePostalProperty, c.nomProperty));
        }
    }
}
