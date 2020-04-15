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
    public class ClasseORM
    {
        public static ClasseViewModel getClasse(int id)
        {
            ClasseDAO cDAO = ClasseDAO.getClasse(id);
            ClasseViewModel c = new ClasseViewModel(cDAO.idDAO, cDAO.nomDAO);
            return c;
        }

        public static ObservableCollection<ClasseViewModel> listeClasse()
        {
            ObservableCollection<ClasseDAO> ClasseDAO = ClasseDAO.listeClasse();
            ObservableCollection<ClasseViewModel> liste = new ObservableCollection<ClasseViewModel>();
            foreach(ClasseDAO element in listeDAO)
            {
                ClasseViewModel c = new ClasseViewModel(element.idDAO, element.nomDAO);
                liste.Add(c);
            }
            return liste;
        }

        public static void updateClasse(ClasseViewModel c)
        {
            ClasseDAO.updateClasse(new ClasseDAO(c.idProperty, c.nomProperty));
        }
        public static void supprimerClasse(int id)
        {
            ClasseDAO.supprimerClasse(id);
        }
        public static void insertClasse(ClasseViewModel c)
        {
            ClasseDAO.insertClasse(new ClasseDAO(c.idProperty, c.nomProperty));
        }
    }
}
