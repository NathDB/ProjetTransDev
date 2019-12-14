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
            ComptageViewModel cp = new ComptageViewModel(+1, cpDAO.idZoneComptageDAO, cpDAO.idEspeceComptageDAO, cpDAO.populationComptageDAO);
            return cp;
        }

        public static ObservableCollection<ComptageViewModel> listeComptages()
        {
            ObservableCollection<ComptageDAO> lDAO = ComptageDAO.listeComptages();
            ObservableCollection<ComptageViewModel> l = new ObservableCollection<ComptageViewModel>();
            foreach (ComptageDAO element in lDAO)
            {                
                ComptageViewModel cp = new ComptageViewModel(+1, element.idZoneComptageDAO, element.idEspeceComptageDAO, element.populationComptageDAO);
                l.Add(cp);
            }
            return l;
        }


        
        public static void updateComptage(ComptageViewModel cp)
        {
            ComptageDAO.updateComptage(new ComptageDAO(cpDAO.idZoneComptageDAO, cpDAO.idEspeceComptageDAO, cpDAO.populationComptageDAO));
        }

        public static void supprimerComptage(int id)
        {
            ComptageDAO.supprimerComptage(id);
        } 

        public static void insertComptage(ComptageViewModel cp)
        {
            ComptageDAO.insertComptage(new ComptageDAO(cp.idZoneComptageProperty, cp.idEspeceComptageProperty, cp.populationComptageProperty));
        }
    }
}

