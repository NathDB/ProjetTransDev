using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class PlageDAO
    {
        public int idPlageDAO;
        public string nomDAO;
        public int idCommunePlageDAO;
        public decimal superficiePlageDAO;

        public PlageDAO(int idPlageDAO, string nomDAO, int idCommunePlageDAO, decimal superficiePlageDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomDAO = nomDAO;
            this.idCommunePlageDAO = idCommunePlageDAO;
            this.superficiePlageDAO = superficiePlageDAO;
        }

        public static ObservableCollection<PlageDAO> listePlages()
        {
            ObservableCollection<PlageDAO> l = PlageDAL.selectPlages();
            return l;
        }
        public static PlageDAO getPlage(int idPlage)
        {
            PlageDAO p = PlageDAL.getPlage(idPlage);
            return p;
        }

        public static void updatePlage(PlageDAO pl)
        {
            PlageDAL.updatePlage(pl);
        }

        public static void supprimerPlage(int id)
        {
            PlageDAL.supprimerPlage(id);
        }

        public static void insertPlage(PlageDAO pl)
        {
            PlageDAL.insertPlage(pl);
        }
    }
}
