using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class EspeceDAO
    {
        public int idEspeceDAO;
        public string nomDAO;
        public int quantiteDAO;
        

        public EspeceDAO(int idEspeceDAO, string nomDAO, int quantiteDAO)
        {
            this.idEspeceDAO = idEspeceDAO;
            this.nomDAO = nomDAO;
            this.quantiteDAO = quantiteDAO;
        }

        public static ObservableCollection<EspeceDAO> listeEspeces(){
            ObservableCollection<EspeceDAO> liste = EspeceDAL.selectEspeces();
            return liste;
        }
        public static EspeceDAO getEspece(int idEspece)
        {
            EspeceDAO es = EspeceDAL.getEspece(idEspece);
            return es;
        }
        public static void updateEspece(EspeceDAO es)
        {
            EspeceDAL.updateEspece(es);
            
        }
        public static void supprimerEspece(int id)
        {
            EspeceDAL.supprimerEspece(id);

        }
        public static void insertEspece(EspeceDAO es)
        {
            EspeceDAL.insertEspece(es);

        }
    }
}
