using ProjetInfrocean.Ctrl;
using ProjetInfrocean.DAO;
using System.Collections.ObjectModel;

namespace ProjetInfrocean.ORM
{
    class ComptageEspeceORM
    {
        public static ComptageEspeceViewModel getComptageEspece(int idComptageEspece)
        {
            ComptageEspeceDAO cpDAO = ComptageEspeceDAO.getComptageEspece(idComptageEspece);
            ComptageEspeceViewModel cp = new ComptageEspeceViewModel(cpDAO.idComptageEspeceDAO, ZoneORM.getZone(cpDAO.idZoneComptageEspeceDAO), EspeceORM.getEspece(cpDAO.idEspeceComptageEspeceDAO), cpDAO.populationComptageEspeceDAO);
            return cp;
        }

        public static ObservableCollection<ComptageEspeceViewModel> listeComptageEspeces()
        {
            ObservableCollection<ComptageEspeceDAO> lDAO = ComptageEspeceDAO.listeComptageEspeces();
            ObservableCollection<ComptageEspeceViewModel> l = new ObservableCollection<ComptageEspeceViewModel>();
            foreach (ComptageEspeceDAO element in lDAO)
            {                
                ComptageEspeceViewModel cp = new ComptageEspeceViewModel(element.idComptageEspeceDAO, ZoneORM.getZone(element.idZoneComptageEspeceDAO), EspeceORM.getEspece(element.idEspeceComptageEspeceDAO), element.populationComptageEspeceDAO);
                l.Add(cp);
            }
            return l;
        }


        
        public static void updateComptageEspece(ComptageEspeceViewModel cp)
        {
            ComptageEspeceDAO.updateComptageEspece(new ComptageEspeceDAO(cp.idComptageEspeceProperty, cp.idZoneProperty.idZoneProperty, cp.idEspeceProperty.idEspeceProperty, cp.populationComptageEspeceProperty));
        }

        public static void supprimerComptageEspece(int id)
        {
            ComptageEspeceDAO.supprimerComptageEspece(id);
        } 

        public static void insertComptageEspece(ComptageEspeceViewModel cp)
        {
            ComptageEspeceDAO.insertComptageEspece(new ComptageEspeceDAO(cp.idComptageEspeceProperty, cp.idZoneProperty.idZoneProperty, cp.idEspeceProperty.idEspeceProperty, cp.populationComptageEspeceProperty));
        }
    }
}

