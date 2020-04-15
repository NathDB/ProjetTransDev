using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class EquipeDAO
    {
        public int idEquipeDAO;
        public string nomDAO;
        public string descriptionDAO;
        public Boolean completeDAO;

        public EquipeDAO(int idEquipeDAO, string nomDAO, string descriptionDAO, Boolean completeDAO)
        {
            this.idEquipeDAO = idEquipeDAO;
            this.nomDAO = nomDAO;
            this.descriptionDAO = descriptionDAO;
            this.completeDAO = completeDAO;
        }
        /*public EquipeDAO(int idEquipeDAO, string nomDAO, string descriptionDAO, Boolean statutDAO)
        {
            this.idEquipeDAO = idEquipeDAO;
            this.nomDAO = nomDAO;
            this.descriptionDAO = descriptionDAO;
            this.statut = statutDAO;
        }*/

        public static ObservableCollection<EquipeDAO> listeEquipes(){
            ObservableCollection<EquipeDAO> liste = EquipeDAL.selectEquipes();
            return liste;
        }
        /*public static ObservableCollection<EquipeDAO> compteurEquipe()
        {
            ObservableCollection<EquipeDAO> liste = EquipeDAL.compteurEquipe();
            return liste;
        }
        public static ObservableCollection<EquipeDAO> listeAllEquipes()
        {
            ObservableCollection<EquipeDAO> liste = EquipeDAL.listeAllEquipes();
            return liste;
        }*/
        public static EquipeDAO getEquipe(int idEquipe)
        {
            EquipeDAO e = EquipeDAL.getEquipe(idEquipe);
            return e;
        }
        public static void updateEtude(EquipeDAO e)
        {
            EquipeDAL.updateEquipe(e);
            
        }
        public static void supprimerEtude(int id)
        {
            EquipeDAL.supprimerEquipe(id);

        }
        public static void insertEtude(EquipeDAO e)
        {
            EquipeDAL.insertEquipe(e);

        }
    }
}
