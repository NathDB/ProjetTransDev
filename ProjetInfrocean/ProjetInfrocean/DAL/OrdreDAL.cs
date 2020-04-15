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
    public class OrdreDAL
    {

        public OrdreDAL()
        {
        }
        public static ObservableCollection<OrdreDAO> selectOrdre()
        {
            ObservableCollection<OrdreDAO> liste = new ObservableCollection<OrdreDAO>();
            string query = "SELECT * from ordre;";
            MySqlCommand cmdOrd = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdOrd.ExecuteNonQuery();
                MySqlDataReader reader = cmdOrd.ExecuteReader();

                while (reader.Read())
                {
                    OrdreDAO o = new OrdreDAO(reader.GetInt32(0), reader.GetString(1));
                    liste.Add(o);
                }
                reader.Close();
            }
            catch (Exception o)
            {
                MessageBox.Show("Ordre La base de données n'est pas connectée" + o.Message);
            }
            return liste;
        }
        public static void updateOrdre(OrdreDAO o)
        {
            string query = "UPDATE ordre set nom=\"" + o.nomDAO + ";";
            MySqlCommand cmdOrd = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdOrd);
            cmdOrd.ExecuteNonQuery();
        }
        public static void insertOrdre(OrdreDAO o)
        {
            int id = getMaxIdOrdre() + 1;
            string query = "INSERT INTO ordre VALUES (\"" + id + "\",\"" + o.nomDAO + "\",\"" + o.idClassOrdreDAO + "\");";
            MySqlCommand cmd2Ord = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Ord);
            cmd2Ord.ExecuteNonQuery();
        }

        public static void supprimerOrdre(int id)
        {
            string query = "DELETE FROM ordre WHERE id = \"" + id + "\";";
            MySqlCommand cmdOrd = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdOrd);
            cmdOrd.ExecuteNonQuery();
        }
        public static int getMaxIdOrdre()
        {
            string query = "SELECT MAX(id) FROM ordre;";
            MySqlCommand cmdOrd = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdOrd.ExecuteNonQuery();

            MySqlDataReader reader = cmdOrd.ExecuteReader();
            reader.Read();
            int maxIdOrdre = reader.GetInt32(0);
            reader.Close();
            return maxIdOrdre;
        }

        public static OrdreDAO getOrdre(int id)
        {
            string query = "SELECT * FROM ordre WHERE id=" + id + ";";
            MySqlCommand cmdOrd = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdOrd.ExecuteNonQuery();
            MySqlDataReader reader = cmdOrd.ExecuteReader();
            reader.Read();
            OrdreDAO ord = new OrdreDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return ord;
        }
    }
}
