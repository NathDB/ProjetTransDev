using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class GenreDAO
    {
        public int idDAO;
        public string nomDAO;

        public GenreDAO(int idDAO, string nomDAO)
        {
            this.idDAO = idDAO;
            this.nomDAO = nomDAO;
        }

        public static ObservableCollection<GenreDAO> listeGenre(){
            ObservableCollection<GenreDAO> liste = GenreDAL.selectGenre();
            return liste;
        }
        public static GenreDAO getGenre(int id)
        {
            GenreDAO g = GenreDAL.getGenre(id);
            return g;
        }
        public static void updateGenre(GenreDAO g)
        {
            GenreDAL.updateGenre(g);
            
        }
        public static void supprimerGenre(int id)
        {
            GenreDAL.supprimerGenre(id);

        }
        public static void insertGenre(GenreDAO g)
        {
            GenreDAL.insertGenre(g);

        }
    }
}
