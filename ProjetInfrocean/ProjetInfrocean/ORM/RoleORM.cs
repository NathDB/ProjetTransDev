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
    public class RoleORM
    {
        public static RoleViewModel getRole(int id)
        {
            RoleDAO rDAO = RoleDAO.getRole(id);
            RoleViewModel r = new RoleViewModel(rDAO.idDAO, rDAO.nomDAO, rDAO.descritionDAO);
            return r;
        }

        public static ObservableCollection<RoleViewModel> listeRole()
        {
            ObservableCollection<RoleDAO> RoleDAO = RoleDAO.listeRole();
            ObservableCollection<RoleViewModel> liste = new ObservableCollection<RoleViewModel>();
            foreach(RoleDAO element in RoleDAO)
            {
                RoleViewModel r = new RoleViewModel(element.idDAO, element.nomDAO, element.descriptionDAO);
                liste.Add(r);
            }
            return liste;
        }

        public static void updateRole(RoleViewModel r)
        {
            RoleDAO.updateRole(new RoleDAO(r.idProperty, r.nomProperty, r.descriptionProperty));
        }
        public static void supprimerRole(int id)
        {
            RoleDAO.supprimerRole(id);
        }
        public static void insertRole(RoleViewModel r)
        {
            RoleDAO.insertRole(new RoleDAO(r.idProperty, r.nomProperty, r.descriptionProperty));
        }
    }
}
