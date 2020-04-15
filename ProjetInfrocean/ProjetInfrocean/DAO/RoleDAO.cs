using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class RoleDAO
    {
        public int idDAO;
        public string nomDAO;
        public string descriptionDAO;

        public RoleDAO(int idDAO, string nomDAO, string descriptionDAO)
        {
            this.idDAO = idDAO;
            this.nomDAO = nomDAO;
            this.descriptionDAO = descriptionDAO;
        }

        public static ObservableCollection<RoleDAO> listeRole(){
            ObservableCollection<RoleDAO> liste = RoleDAL.selectRole();
            return liste;
        }
        public static RoleDAO getRole(int id)
        {
            RoleDAO r = RoleDAL.getRole(id);
            return r;
        }
        public static void updateRole(RoleDAO r)
        {
            RoleDAL.updateRole(r);
            
        }
        public static void supprimerRole(int id)
        {
            RoleDAL.supprimerRole(id);

        }
        public static void insertRole(RoleDAO r)
        {
            RoleDAL.insertRole(r);

        }
    }
}
