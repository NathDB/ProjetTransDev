using ProjetInfrocean.Ctrl;
using ProjetInfrocean.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.ORM
{
    public class FamilleORM
    {
        public static FamilleViewModel getFamille(int id)
        {
            FamilleDAO fDAO = FamilleDAO.getFamille(id);
            FamilleViewModel f = new FamilleViewModel(fDAO.idDAO, fDAO.nomDAO);
            return f;
        }

        public static ObservableCollection<FamilleViewModel> listeFamille()
        {
            ObservableCollection<FamilleDAO> listeDAO = FamilleDAO.listeFamille();
            ObservableCollection<FamilleViewModel> liste = new ObservableCollection<FamilleViewModel>();
            foreach(FamilleDAO element in listeDAO)
            {
                FamilleViewModel f = new FamilleViewModel(element.idDAO, element.nomDAO);
                liste.Add(f);
            }
            return liste;
        }

        public static void updateFamille(FamilleViewModel f)
        {
            FamilleDAO.updateFamille(new FamilleDAO(f.idProperty, f.nomProperty));
        }
        public static void supprimerFamille(int id)
        {
            FamilleDAO.supprimerFamille(id);
        }
        public static void insertFamille(FamilleViewModel f)
        {
            FamilleDAO.insertFamille(new FamilleDAO(f.idProperty, f.nomProperty));
        }
    }
}
