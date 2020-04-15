using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class ClasseDAO
    {
        public int idDAO;
        public string nomDAO;

        public ClasseDAO(int idDAO, string nomDAO)
        {
            this.idDAO = idDAO;
            this.nomDAO = nomDAO;
        }

        public static ObservableCollection<ClasseDAO> listeClasse(){
            ObservableCollection<ClasseDAO> liste = ClasseDAL.selectClasse();
            return liste;
        }
        public static ClasseDAO getClasse(int id)
        {
            ClasseDAO c = ClasseDAL.getClasse(id);
            return c;
        }
        public static void updateClasse(ClasseDAO c)
        {
            ClasseDAL.updateClasse(c);
            
        }
        public static void supprimerClasse(int id)
        {
            ClasseDAL.supprimerClasse(id);

        }
        public static void insertClasse(ClasseDAO c)
        {
            ClasseDAL.insertClasse(c);

        }
    }
}
