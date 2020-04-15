using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class OrdreDAO
    {
        public int idDAO;
        public string nomDAO;

        public OrdreDAO(int idDAO, string nomDAO)
        {
            this.idDAO = idDAO;
            this.nomDAO = nomDAO;
        }

        public static ObservableCollection<OrdreDAO> listeOrdre(){
            ObservableCollection<OrdreDAO> liste = OrdreDAL.selectOrdre();
            return liste;
        }
        public static OrdreDAO getOrdre(int id)
        {
            OrdreDAO o = OrdreDAL.getOrdre(id);
            return o;
        }
        public static void updateOrdre(OrdreDAO o)
        {
            OrdreDAL.updateOrdre(o);
            
        }
        public static void supprimerOrdre(int id)
        {
            OrdreDAL.supprimerOrdre(id);

        }
        public static void insertOrdre(OrdreDAO o)
        {
            OrdreDAL.insertOrdre(o);

        }
    }
}
