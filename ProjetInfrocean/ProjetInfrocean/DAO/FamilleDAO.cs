using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class FamilleDAO
    {
        public int idDAO;
        public string nomDAO;

        public FamilleDAO(int idDAO, string nomDAO)
        {
            this.idDAO = idDAO;
            this.nomDAO = nomDAO;
        }

        public static ObservableCollection<FamilleDAO> listeFamille(){
            ObservableCollection<FamilleDAO> liste = FamilleDAL.selectFamille();
            return liste;
        }
        public static FamilleDAO getOrdre(int id)
        {
            FamilleDAO f = FamilleDAL.getFamille(id);
            return f;
        }
        public static void updateFamille(FamilleDAO f)
        {
            FamilleDAL.updateFamille(f);
            
        }
        public static void supprimerFamille(int id)
        {
            FamilleDAL.supprimerFamille(id);

        }
        public static void insertFamille(FamilleDAO f)
        {
            FamilleDAL.insertFamille(f);

        }
    }
}
