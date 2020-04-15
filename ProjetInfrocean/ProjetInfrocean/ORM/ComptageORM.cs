using ProjetInfrocean.Ctrl;
using ProjetInfrocean.DAO;
using System.Collections.ObjectModel;

namespace ProjetInfrocean.ORM
{
    class ComptageORM
    {
        public static ComptageViewModel getComptage(int idComptage)
        {
            ComptageDAO cpDAO = ComptageDAO.getComptage(idComptage);
            ComptageViewModel cp = new ComptageViewModel(cpDAO.idComptageDAO, cpDAO.dateDebutDAO, cpDAO.dateFinDAO, cpDAO.statutDAO, ZoneORM.getZone(cpDAO.idZoneComptageDAO));
            return cp;
        }

        public static ObservableCollection<ComptageViewModel> listeComptages()
        {
            ObservableCollection<ComptageDAO> lDAO = ComptageDAO.listeComptages();
            ObservableCollection<ComptageViewModel> l = new ObservableCollection<ComptageViewModel>();
            foreach (ComptageDAO element in lDAO)
            {                
                ComptageViewModel cp = new ComptageViewModel(element.idComptageDAO, element.dateDebutDAO, element.dateFinDAO, element.statutDAO, ZoneORM.getZone(element.idZoneComptageDAO));
                l.Add(cp);
            }
            return l;
        }


        
        public static void updateComptage(ComptageViewModel cp)
        {
            ComptageDAO.updateComptage(new ComptageDAO(cp.idComptageProperty, cp.dateDebutProperty, cp.dateFinProperty, cp.statutProperty, cp.idZoneProperty.idZoneProperty));
        }

        public static void supprimerComptage(int id)
        {
            ComptageDAO.supprimerComptage(id);
        } 

        public static void insertComptage(ComptageViewModel cp)
        {
            ComptageDAO.insertComptage(new ComptageDAO(cp.idComptageProperty, cp.dateDebutProperty, cp.dateFinProperty, cp.statutProperty, cp.idZoneProperty.idZoneProperty));
        }
    }
}

