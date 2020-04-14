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
        public string nomEquipeDAO;
        public int idPersonneEquipeDAO;
        public int idEtudeEquipeDAO;
        public string titreEtudeDAO;
        public string nomPersonneDAO;

        public EquipeDAO(int idEquipeDAO, string nomEquipeDAO, string nomPersonneDAO, string titreEtudeDAO)
        {
            this.idEquipeDAO = idEquipeDAO;
            this.nomEquipeDAO = nomEquipeDAO;
            this.nomPersonneDAO = nomPersonneDAO;
            this.titreEtudeDAO = titreEtudeDAO;
        }
        public EquipeDAO(int idEquipeDAO, string nomEquipeDAO, int idPersonneEquipeDAO, int idEtudeEquipeDAO)
        {
            this.idEquipeDAO = idEquipeDAO;
            this.nomEquipeDAO = nomEquipeDAO;
            this.idPersonneEquipeDAO = idPersonneEquipeDAO;
            this.idEtudeEquipeDAO = idEtudeEquipeDAO;
        }

        public static ObservableCollection<EquipeDAO> listeEquipes(){
            ObservableCollection<EquipeDAO> liste = EquipeDAL.selectEquipes();
            return liste;
        }
        /*public static ObservableCollection<EquipeDAO> compteurEquipe()
        {
            ObservableCollection<EquipeDAO> liste = EquipeDAL.compteurEquipe();
            return liste;
        }*/
        public static ObservableCollection<EquipeDAO> listeAllEquipes()
        {
            ObservableCollection<EquipeDAO> liste = EquipeDAL.listeAllEquipes();
            return liste;
        }
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
