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
    public class HistoriqueDAL
    {

        public HistoriqueDAL()
        {
        }
        public static ObservableCollection<HistoriqueDAO> selectHistoriques()
        {
            ObservableCollection<HistoriqueDAO> liste = new ObservableCollection<HistoriqueDAO>();
            string query = "SELECT * from historique;";
            MySqlCommand cmdHis = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdHis.ExecuteNonQuery();
                MySqlDataReader reader = cmdHis.ExecuteReader();

                while (reader.Read())
                {
                    HistoriqueDAO e = new HistoriqueDAO(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4));
                    liste.Add(e);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("historique La base de données n'est pas connectée" + e.Message);
            }
            return liste;
        }
        public static void updateHistorique(HistoriqueDAO c)
        {
            string query = "UPDATE historique set dateFin=\"" + c.dateFinDAO + ";";
            MySqlCommand cmdHis = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdHis);
            cmdHis.ExecuteNonQuery();
        }
        public static void insertHistorique(HistoriqueDAO c)
        {
            int idHistorique = getMaxIdHistorique() + 1;
            string query = "INSERT INTO historique VALUES (\"" + idHistorique + "\",\"" + c.dateCreaDAO + "\", \"" + c.dateFinDAO + "\",\"" + c.idEtudeHistoriqueDAO + "\",\"" + c.idSaisonHistoriqueDAO + "\");";
            MySqlCommand cmd2His = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2His);
            cmd2His.ExecuteNonQuery();
        }

        public static void supprimerHistorique(int idHistorique)
        {
            string query = "DELETE FROM historique WHERE idHistorique = \"" + idHistorique + "\";";
            MySqlCommand cmdHis = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdHis);
            cmdHis.ExecuteNonQuery();
        }
        public static int getMaxIdHistorique()
        {
            string query = "SELECT MAX(idHistorique) FROM historique;";
            MySqlCommand cmdHis = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdHis.ExecuteNonQuery();

            MySqlDataReader reader = cmdHis.ExecuteReader();
            reader.Read();
            int maxIdHistorique = reader.GetInt32(0);
            reader.Close();
            return maxIdHistorique;
        }

        public static HistoriqueDAO getHistorique(int idHistorique)
        {
            string query = "SELECT * FROM Historique WHERE idHistorique=" + idHistorique + ";";
            MySqlCommand cmdHis = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdHis.ExecuteNonQuery();
            MySqlDataReader reader = cmdHis.ExecuteReader();
            reader.Read();
            HistoriqueDAO his = new HistoriqueDAO(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetInt32(3), reader.GetInt32(4));
            reader.Close();
            return his;
        }
    }
}
