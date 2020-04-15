using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class CommuneDAO
    {
        public int idDAO;
        public int idDepartementDAO;
        public string codePostalDAO;
        public string nomDAO;

        public CommuneDAO(int idDAO, int idDepartementDAO, string codePostalDAO, string nomDAO)
        {
            this.idDAO = idDAO;
            this.idDepartementDAO = idDepartementDAO;
            this.codePostalDAO = codePostalDAO;
            this.nomDAO = nomDAO;
        }

        public static ObservableCollection<CommuneDAO> listeCommunes(){
            ObservableCollection<CommuneDAO> liste = CommuneDAL.selectCommunes();
            return liste;
        }
        public static CommuneDAO getCommune(int id)
        {
            CommuneDAO c = CommuneDAL.getCommune(id);
            return c;
        }
        public static void updateCommune(CommuneDAO c)
        {
            CommuneDAL.updateCommune(c);
            
        }
        public static void supprimerCommune(int id)
        {
            CommuneDAL.supprimerCommune(id);

        }
        public static void insertCommune(CommuneDAO c)
        {
            CommuneDAL.insertCommune(c);

        }
    }
}
