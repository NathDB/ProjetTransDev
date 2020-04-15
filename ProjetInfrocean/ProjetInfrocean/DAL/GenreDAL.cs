using MySql.Data.MySqlClient;
using ProjetInfrocean.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetInfrocean.DAL
{
    public class GenreDAL
    {

        public GenreDAL()
        {
        }
        public static ObservableCollection<GenreDAO> selectGenre()
        {
            ObservableCollection<GenreDAO> liste = new ObservableCollection<GenreDAO>();
            string query = "SELECT * from genres;";
            MySqlCommand cmdGen= new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdGen.ExecuteNonQuery();
                MySqlDataReader reader = cmdGen.ExecuteReader();

                while (reader.Read())
                {
                    GenreDAO g = new GenreDAO(reader.GetInt32(0), reader.GetString(1));
                    liste.Add(g);
                }
                reader.Close();
            }
            catch (Exception g)
            {
                MessageBox.Show("Genre La base de données n'est pas connectée" + g.Message);
            }
            return liste;
        }
        public static void updateGenre(GenreDAO g)
        {
            string query = "UPDATE genre set nom=\"" + g.nomDAO + ";";
            MySqlCommand cmdGen= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdGen);
            cmdGen.ExecuteNonQuery();
        }
        public static void insertGenre(GenreDAO g)
        {
            int id = getMaxIdGenre() + 1;
            string query = "INSERT INTO genres VALUES (\"" + id + "\",\"" + g.nomDAO + "\");";
            MySqlCommand cmd2Gen= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Gen);
            cmd2Gen.ExecuteNonQuery();
        }

        public static void supprimerGenres(int id)
        {
            string query = "DELETE FROM genres WHERE id = \"" + id + "\";";
            MySqlCommand cmdGen= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdGen);
            cmdGen.ExecuteNonQuery();
        }
        public static int getMaxIdGenres()
        {
            string query = "SELECT MAX(id) FROM genres;";
            MySqlCommand cmdGen= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdGen.ExecuteNonQuery();

            MySqlDataReader reader = cmdGen.ExecuteReader();
            reader.Read();
            int maxIdGenre= reader.GetInt32(0);
            reader.Close();
            return maxIdGenre;
        }

        public static GenreDAO getGenre(int id)
        {
            string query = "SELECT * FROM genres WHERE id=" + id + ";";
            MySqlCommand cmdGen= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdGen.ExecuteNonQuery();
            MySqlDataReader reader = cmdGen.ExecuteReader();
            reader.Read();
            GenreDAO gen = new GenreDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return gen;
        }
    }
}
