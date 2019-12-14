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
    public class EspeceDAL
    {
        private static MySqlConnection connection;

        public EspeceDAL()
        {
            connection = DalConnexion.connection;
        }
        public static ObservableCollection<EspeceDAO> selectEspeces()
        {
            ObservableCollection<EspeceDAO> liste = new ObservableCollection<EspeceDAO>();
            string query = "SELECT * from espece;";
            MySqlCommand cmdEs = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdEs.ExecuteNonQuery();
                MySqlDataReader reader = cmdEs.ExecuteReader();

                while (reader.Read())
                {
                    EspeceDAO es = new EspeceDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                    liste.Add(es);
                }
                reader.Close();
            }
            catch (Exception es)
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return liste;
        }
        public static void updateEspece(EspeceDAO es)
        {
            string query = "UPDATE espece set nomEspece=\"" + es.nomEspeceDAO + "\",  quantiteEspece = \"" + es.quantiteEspeceDAO + ";";
            MySqlCommand cmdEs = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdEs);
            cmdEs.ExecuteNonQuery();
        }
        public static void insertEspece(EspeceDAO es)
        {
            int id = getMaxIdEspece() + 1;
            string query = "INSERT INTO espece VALUES (\"" + id + "\",\"" + es.nomEspeceDAO + "\",\"" + es.quantiteEspeceDAO + "\");";
            MySqlCommand cmd2Es = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Es);
            cmd2Es.ExecuteNonQuery();
        }

        public static void supprimerEspece(int id)
        {
            string query = "DELETE FROM espece WHERE idEspece = \"" + id + "\";";
            MySqlCommand cmdEs = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdEs);
            cmdEs.ExecuteNonQuery();
        }
        public static int getMaxIdEspece()
        {
            string query = "SELECT MAX(idEspece) FROM espece;";
            MySqlCommand cmdEs = new MySqlCommand(query, connection);
            cmdEs.ExecuteNonQuery();

            MySqlDataReader reader = cmdEs.ExecuteReader();
            reader.Read();
            int maxIdEspece = reader.GetInt32(0);
            reader.Close();
            return maxIdEspece;
        }

        public static EspeceDAO getEspece(int idEspece)
        {
            string query = "SELECT * FROM espece WHERE id=" + idEspece + ";";
            MySqlCommand cmdEs = new MySqlCommand(query, connection);
            cmdEs.ExecuteNonQuery();
            MySqlDataReader reader = cmdEs.ExecuteReader();
            reader.Read();
            EspeceDAO es = new EspeceDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
            reader.Close();
            return es;
        }
    }
}
