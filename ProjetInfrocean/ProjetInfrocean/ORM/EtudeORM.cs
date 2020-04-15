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
    public class EtudeORM
    {
        public static EtudeViewModel getEtude(int idEtude)
        {
            EtudeDAO eDAO = EtudeDAO.getEtude(idEtude);
            EtudeViewModel e = new EtudeViewModel(eDAO.idEtudeDAO, eDAO.titreDAO, eDAO.statutDAO, eDAO.idEquipeEtudeDAO);
            return e;
        }

        public static ObservableCollection<EtudeViewModel> listeEtudes()
        {
            ObservableCollection<EtudeDAO> listeDAO = EtudeDAO.listeEtudes();
            ObservableCollection<EtudeViewModel> liste = new ObservableCollection<EtudeViewModel>();
            foreach(EtudeDAO element in listeDAO)
            {
                EtudeViewModel e = new EtudeViewModel(element.idEtudeDAO, element.titreDAO, element.statutDAO, element.idEquipeEtudeDAO);
                liste.Add(e);
            }
            return liste;
        }
        public static ObservableCollection<EtudeViewModel> requeteEtudePlage()
        {
            ObservableCollection<EtudeDAO> listeDAO = EtudeDAO.requeteEtudePlage();
            ObservableCollection<EtudeViewModel> liste = new ObservableCollection<EtudeViewModel>();
            foreach (EtudeDAO element in listeDAO)
            {
                EtudeViewModel e = new EtudeViewModel(element.idEtudeDAO, element.titreDAO, element.statutDAO, element.idEquipeEtudeDAO);
                liste.Add(e);
            }
            return liste;
        }

        public static void updateEtude(EtudeViewModel e)
        {
            EtudeDAO.updateEtude(new EtudeDAO(e.idEtudeProperty, e.titreProperty, e.statutProperty, e.idEquipeEtudeProperty));
        }
        public static void supprimerEtude(int id)
        {
            EtudeDAO.supprimerEtude(id);
        }
        public static void insertEtude(EtudeViewModel e)
        {
            EtudeDAO.insertEtude(new EtudeDAO(e.idEtudeProperty, e.titreProperty, e.statutProperty, e.dateFinEtudeProperty));
        }
    }
}
