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
        public static CommuneViewModel getCommune(int idCommune)
        {
            CommuneDAO cDAO = CommuneDAO.getCommune(idCommune);
            CommuneViewModel c = new CommuneViewModel(cDAO.idCommuneDAO, cDAO.idDepartementDAO, cDAO.codePostalDAO, cDAO.nomDAO);
            return c;
        }

        public static ObservableCollection<CommuneViewModel> listeCommunes()
        {
            ObservableCollection<CommuneDAO> listeDAO = CommuneDAO.listeCommunes();
            ObservableCollection<CommuneViewModel> liste = new ObservableCollection<CommuneViewModel>();
            foreach(CommuneDAO element in listeDAO)
            {
                CommuneViewModel c = new CommuneViewModel(element.idCommuneDAO, element.idDepartementDAO, element.codePostalDAO, element.nomDAO);
                liste.Add(c);
            }
            return liste;
        }

        public static void updateCommune(CommuneViewModel c)
        {
            CommuneDAO.updateCommune(new CommuneDAO(c.idCommuneProperty, c.idDepartementProperty, c.codePostalProperty, c.nomProperty));
        }
        public static void supprimerCommune(int idCommune)
        {
            CommuneDAO.supprimerCommune(idCommune);
        }
        public static void insertCommune(CommuneViewModel c)
        {
            CommuneDAO.insertCommune(new CommuneDAO(c.idCommuneProperty, c.idDepartementProperty, c.codePostalProperty, c.nomProperty));
        }
    }
}
