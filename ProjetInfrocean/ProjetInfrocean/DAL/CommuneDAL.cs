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
    public class CommuneDAL
    {

        public CommuneDAL()
        {
        }
        public static ObservableCollection<CommuneDAO> selectCommunes()
        {
            ObservableCollection<CommuneDAO> liste = new ObservableCollection<CommuneDAO>();
            string query = "SELECT * from commune;";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdEtu.ExecuteNonQuery();
                MySqlDataReader reader = cmdEtu.ExecuteReader();

                while (reader.Read())
                {
                    CommuneDAO e = new CommuneDAO(reader.GetInt32(0), reader.GetInt32(0), reader.GetString(1), reader.GetString(1));
                    liste.Add(e);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Commune La base de données n'est pas connectée" + e.Message);
            }
            return liste;
        }
        public static void updateCommune(CommuneDAO c)
        {
            string query = "UPDATE commune set nom=\"" + c.nomDAO + ";";
            MySqlCommand cmdCom = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdCom);
            cmdCom.ExecuteNonQuery();
        }
        public static void insertCommune(CommuneDAO c)
        {
            int idCommune = getMaxIdCommune() + 1;
            string query = "INSERT INTO commune VALUES (\"" + idCommune + "\",\"" + c.nomDAO + "\");";
            MySqlCommand cmd2Com = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Com);
            cmd2Com.ExecuteNonQuery();
        }

        public static void supprimerCommune(int idCommune)
        {
            string query = "DELETE FROM commune WHERE idCommune = \"" + idCommune + "\";";
            MySqlCommand cmdCom = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdCom);
            cmdCom.ExecuteNonQuery();
        }
        public static int getMaxIdCommune()
        {
            string query = "SELECT MAX(idCommune) FROM communes;";
            MySqlCommand cmdCom = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdCom.ExecuteNonQuery();

            MySqlDataReader reader = cmdCom.ExecuteReader();
            reader.Read();
            int maxIdCommune = reader.GetInt32(0);
            reader.Close();
            return maxIdCommune;
        }

        public static CommuneDAO getCommune(int idCommune)
        {
            string query = "SELECT * FROM commune WHERE idCommune=" + idCommune + ";";
            MySqlCommand cmdCom = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdCom.ExecuteNonQuery();
            MySqlDataReader reader = cmdCom.ExecuteReader();
            reader.Read();
            CommuneDAO com = new CommuneDAO(reader.GetInt32(0), reader.GetInt32(0), reader.GetString(1), reader.GetString(1));
            reader.Close();
            return com;
        }
    }
}
