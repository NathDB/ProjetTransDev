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
    public class SaisonDAL
    {

        public SaisonDAL()
        {
        }
        public static ObservableCollection<SaisonDAO> selectSaison()
        {
            ObservableCollection<SaisonDAO> liste = new ObservableCollection<SaisonDAO>();
            string query = "SELECT * from saisons;";
            MySqlCommand cmdSai= new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdCla.ExecuteNonQuery();
                MySqlDataReader reader = cmdSai.ExecuteReader();

                while (reader.Read())
                {
                    SaisonDAO s = new SaisonDAO(reader.GetInt32(0), reader.GetString(1));
                    liste.Add(s);
                }
                reader.Close();
            }
            catch (Exception s)
            {
                MessageBox.Show("Saison La base de données n'est pas connectée" + s.Message);
            }
            return liste;
        }
        public static void updateSaison(SaisonDAO s)
        {
            string query = "UPDATE Saison set nom=\"" + s.saisonDAO + ";";
            MySqlCommand cmdSai= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdSai);
            cmdSai.ExecuteNonQuery();
        }
        public static void insertSaison(SaisonDAO s)
        {
            int id = getMaxIdSaison() + 1;
            string query = "INSERT INTO saisons VALUES (\"" + id + "\",\"" + s.saisonDAO + "\");";
            MySqlCommand cmd2Sai= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Sai);
            cmd2Sai.ExecuteNonQuery();
        }

        public static void supprimerSaison(int id)
        {
            string query = "DELETE FROM saisons WHERE id = \"" + id + "\";";
            MySqlCommand cmdSai= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdSai);
            cmdSai.ExecuteNonQuery();
        }
        public static int getMaxIdSaison()
        {
            string query = "SELECT MAX(id) FROM saisons;";
            MySqlCommand cmdSai= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdSai.ExecuteNonQuery();

            MySqlDataReader reader = cmdSai.ExecuteReader();
            reader.Read();
            int maxIdSaison = reader.GetInt32(0);
            reader.Close();
            return maxIdSaison;
        }

        public static SaisonDAO getSaison(int id)
        {
            string query = "SELECT * FROM saisons WHERE id=" + id + ";";
            MySqlCommand cmdSai= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdSai.ExecuteNonQuery();
            MySqlDataReader reader = cmdSai.ExecuteReader();
            reader.Read();
            SaisonDAO sai = new SaisonDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return sai;
        }
    }
}
