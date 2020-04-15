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
    public class DepartementORM
    {
        public static DepartementViewModel getDepartement(int id)
        {
            DepartementDAO dDAO = DepartementDAO.getDepartement(id);
            DepartementViewModel d = new DepartementViewModel(dDAO.idDAO, dDAO.nomDAO);
            return d;
        }

        public static ObservableCollection<DepartementViewModel> listeDepartement()
        {
            ObservableCollection<DepartementDAO> DepartementDAO = DepartementDAO.listeDepartement();
            ObservableCollection<DepartementViewModel> liste = new ObservableCollection<DepartementViewModel>();
            foreach(DepartementDAO element in listeDAO)
            {
                DepartementViewModel d = new DepartementViewModel(element.idDAO, element.nomDAO);
                liste.Add(d);
            }
            return liste;
        }

        public static void updateDepartement(DepartementViewModel d)
        {
            DepartementDAO.updateDepartement(new DepartementDAO(d.idProperty, d.nomProperty));
        }
        public static void supprimerDepartement(int id)
        {
            DepartementDAO.supprimerDepartement(id);
        }
        public static void insertDepartement(DepartementViewModel d)
        {
            DepartementDAO.insertDepartement(new DepartementDAO(d.idProperty, d.nomProperty));
        }
    }
}
