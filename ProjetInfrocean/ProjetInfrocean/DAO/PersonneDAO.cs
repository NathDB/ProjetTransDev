using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class PersonneDAO
    {
        public int idPersonneDAO;
        public string nomDAO;
        public string prenomDAO;
        public string emailDAO;
        public string mdpDAO;
        public int idRolePersonneDAO;
        public int idEquipePersonneDAO;

        public PersonneDAO(int idPersonneDAO, string nomDAO, string prenomDAO, string emailDAO, string mdpDAO, int idRolePersonneDAO, int idEquipePersonneDAO)
        {
            this.idPersonneDAO = idPersonneDAO;
            this.nomDAO = nomDAO;
            this.prenomDAO = prenomDAO;
            this.emailDAO = emailDAO;
            this.mdpDAO = mdpDAO;
            this.idRolePersonneDAO = idRolePersonneDAO;
            this.idEquipePersonneDAO = idEquipePersonneDAO;
        }

        public static ObservableCollection<PersonneDAO> listePersonnes()
        {
            ObservableCollection<PersonneDAO> l = PersonneDAL.selectPersonnes();
            return l;
        }
        public static PersonneDAO getPersonne(int idPersonne)
        {
            PersonneDAO p = PersonneDAL.getPersonne(idPersonne);
            return p;
        }

        public static void updatePersonne(PersonneDAO p)
        {
            PersonneDAL.updatePersonne(p);
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAL.supprimerPersonne(id);
        }

        public static void insertPersonne(PersonneDAO p)
        {
            PersonneDAL.insertPersonne(p);
        }
    }
}
