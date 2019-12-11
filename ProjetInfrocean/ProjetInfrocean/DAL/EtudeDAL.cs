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
    public class EtudeDAL
    {
        private static MySqlConnection connection;

        public EtudeDAL()
        {
            connection = DalConnexion.connection;
        }
        public static ObservableCollection<EtudeDAO> selectEtudes()
        {
            ObservableCollection<EtudeDAO> liste = new ObservableCollection<EtudeDAO>();
            string query = "SELECT * from etude;";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdEtu.ExecuteNonQuery();
                MySqlDataReader reader = cmdEtu.ExecuteReader();

                while (reader.Read())
                {
                    EtudeDAO e = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    liste.Add(e);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return liste;
        }
        public static void updateEtude(EtudeDAO e)
        {
            string query = "UPDATE etude set titreEtude=\"" + e.titreEtudeDAO + "\",  dateCreationEtude = \"" + e.dateCreationEtudeDAO + "\", dateFinEtude = \"" + e.dateFinEtudeDAO + ";";
            MySqlCommand cmdEtu = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdEtu);
            cmdEtu.ExecuteNonQuery();
        }
        public static void insertEtude(EtudeDAO e)
        {
            int id = getMaxIdEtude() + 1;
            string query = "INSERT INTO etude VALUES (\"" + id + "\",\"" + e.titreEtudeDAO + "\",\"" + e.dateCreationEtudeDAO + "\",\"" + e.dateFinEtudeDAO + "\");";
            MySqlCommand cmd2Etu = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Etu);
            cmd2Etu.ExecuteNonQuery();
        }

        public static void supprimerEtude(int id)
        {
            string query = "DELETE FROM etude WHERE idEtude = \"" + id + "\";";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdEtu);
            cmdEtu.ExecuteNonQuery();
        }
        public static int getMaxIdEtude()
        {
            string query = "SELECT MAX(idEtude) FROM etude;";
            MySqlCommand cmdEtu = new MySqlCommand(query, connection);
            cmdEtu.ExecuteNonQuery();

            MySqlDataReader reader = cmdEtu.ExecuteReader();
            reader.Read();
            int maxIdEtude = reader.GetInt32(0);
            reader.Close();
            return maxIdEtude;
        }

        public static EtudeDAO getEtude(int idEtude)
        {
            string query = "SELECT * FROM etude WHERE id=" + idEtude + ";";
            MySqlCommand cmdEtu = new MySqlCommand(query, connection);
            cmdEtu.ExecuteNonQuery();
            MySqlDataReader reader = cmdEtu.ExecuteReader();
            reader.Read();
            EtudeDAO etu = new EtudeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            reader.Close();
            return etu;
        }
    }
}
