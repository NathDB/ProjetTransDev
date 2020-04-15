using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class DepartementDAO
    {
        public int idDAO;
        public string nomDAO;

        public DepartementDAO(int idDAO, string nomDAO)
        {
            this.idDAO = idDAO;
            this.nomDAO = nomDAO;
        }

        public static ObservableCollection<DepartementDAO> listeDepartement(){
            ObservableCollection<DepartementDAO> liste = DepartementDAL.selectDepartement();
            return liste;
        }
        public static DepartementDAO getDepartement(int id)
        {
            DepartementDAO d = DepartementDAL.getClasse(id);
            return d;
        }
        public static void updateDepartement(DepartementDAO d)
        {
            DepartementDAL.updateDepartement(d);
            
        }
        public static void supprimerDepartement(int id)
        {
            DepartementDAL.supprimerDepartement(id);

        }
        public static void insertDepartement(DepartementDAO d)
        {
            DepartementDAL.insertDepartement(d);

        }
    }
}
