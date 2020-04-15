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
    public class ComptageEspeceDAL
    {
        public ComptageEspeceDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
        }
        public static ObservableCollection<ComptageEspeceDAO> selectComptageEspeces()
        {
            ObservableCollection<ComptageEspeceDAO> l = new ObservableCollection<ComptageEspeceDAO>();
            string query = "SELECT * FROM comptage_espece;";
            MySqlCommand cmd = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComptageEspeceDAO cp = new ComptageEspeceDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
                    l.Add(cp);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("ComptageEspece La base de données n'est pas connectée" + e.Message);
            }
            return l;
        }
        public static void insertComptageEspece(ComptageEspeceDAO cp)
        {
            int id = getMaxIdComptageEspece() + 1;
            string query = "INSERT INTO comptage_espece VALUES (\"" + id + "\",\"" + cp.idEspeceDAO + "\",\"" + cp.idComptageDAO + "\",\"" + cp.quantiteDAO + "\");";
            MySqlCommand cmd2CompEsp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2CompEsp);
            cmd2CompEsp.ExecuteNonQuery();
        }

        public static void updateComptageEspece(ComptageEspeceDAO cp)
        {
            string query = "UPDATE comptage_espece set quantite=\"" + cp.quantiteDAO + "\",  idEspece = \"" + cp.idEspeceDAO;
            MySqlCommand cmdCompEsp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdCompEsp);
            cmdCompEsp.ExecuteNonQuery();
        }

        public static void supprimerComptage(int id)
        {
            string query = "DELETE FROM comptage_espece WHERE idComptage = \"" + id + "\";";
            MySqlCommand cmdCompEsp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdCompEsp);
            cmdCompEsp.ExecuteNonQuery();
        }
        public static int getMaxIdComptageEspece()
        {
            string query = "SELECT MAX(idComptageEspece) FROM comptage_espece;";
            MySqlCommand cmdCompEsp = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdCompEsp.ExecuteNonQuery();

            MySqlDataReader reader = cmdCompEsp.ExecuteReader();
            reader.Read();
            int maxIdComptageEspece = reader.GetInt32(0);
            reader.Close();
            return maxIdComptageEspece;
        }

        public static ComptageEspeceDAO getComptageEspece(int idComptageEspece)
        {
            string query = "SELECT * FROM comptage_espece WHERE id=" + idComptageEspece+";";
            MySqlCommand cmdCompEsp = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdCompEsp.ExecuteNonQuery();
            MySqlDataReader reader = cmdCompEsp.ExecuteReader();
            reader.Read();
            ComptageEspeceDAO comptage_espece = new ComptageEspeceDAO(reader.GetInt32(0), reader.GetInt32(1), reader.GetInt32(2), reader.GetInt32(3));
            reader.Close();
            return comptage_espece;
        }

      
    }
}
