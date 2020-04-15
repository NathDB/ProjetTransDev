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
    public class GenreORM
    {
        public static GenreViewModel getGenre(int id)
        {
            GenreDAO gDAO = GenreDAO.getGenre(id);
            GenreViewModel g = new GenreViewModel(gDAO.idDAO, gDAO.nomDAO);
            return g;
        }

        public static ObservableCollection<GenreViewModel> listeGenre()
        {
            ObservableCollection<GenreDAO> GenreDAO = GenreDAO.listeGenre();
            ObservableCollection<GenreViewModel> liste = new ObservableCollection<GenreViewModel>();
            foreach(GenreDAO element in listeDAO)
            {
                GenreViewModel g = new GenreViewModel(element.idDAO, element.nomDAO);
                liste.Add(g);
            }
            return liste;
        }

        public static void updateGenre(GenreViewModel g)
        {
            GenreDAO.updateGenre(new GenreDAO(g.idProperty, g.nomProperty));
        }
        public static void supprimerGenre(int id)
        {
            GenreDAO.supprimerGenre(id);
        }
        public static void insertGenre(GenreViewModel g)
        {
            GenreDAO.insertGenre(new GenreDAO(g.idProperty, g.nomProperty));
        }
    }
}
