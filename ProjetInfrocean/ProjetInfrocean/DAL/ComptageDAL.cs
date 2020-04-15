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
    public class ComptageDAL
    {
        public ComptageDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
        }
        public static ObservableCollection<ComptageDAO> selectComptages()
        {
            ObservableCollection<ComptageDAO> l = new ObservableCollection<ComptageDAO>();
            string query = "SELECT * FROM comptage;";
            MySqlCommand cmd = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ComptageDAO cp = new ComptageDAO(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetBoolean(3), reader.GetInt32(4));
                    l.Add(cp);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("comptage La base de données n'est pas connectée" + e.Message);
            }
            return l;
        }
        public static void insertComptage(ComptageDAO cp)
        {
            int id = getMaxIdComptage() + 1;
            string query = "INSERT INTO comptage VALUES (\"" + id + "\",\"" + cp.dateDebutDAO + "\",\"" + cp.dateFinDAO + "\",\"" + cp.statutDAO + "\"\"" + cp.idZoneComptageDAO + "\");";
            MySqlCommand cmd2Comp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2Comp);
            cmd2Comp.ExecuteNonQuery();
        }

        public static void updateComptage(ComptageDAO cp)
        {
            string query = "UPDATE comptage set dateFin=\"" + cp.dateFinDAO + "\",  statut = \"" + cp.statutDAO;
            MySqlCommand cmdComp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdComp);
            cmdComp.ExecuteNonQuery();
        }

        public static void supprimerComptage(int id)
        {
            string query = "DELETE FROM comptage WHERE idComptage = \"" + id + "\";";
            MySqlCommand cmdComp = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdComp);
            cmdComp.ExecuteNonQuery();
        }
        public static int getMaxIdComptage()
        {
            string query = "SELECT MAX(idComptage) FROM comptage;";
            MySqlCommand cmdComp = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdComp.ExecuteNonQuery();

            MySqlDataReader reader = cmdComp.ExecuteReader();
            reader.Read();
            int maxIdComptage = reader.GetInt32(0);
            reader.Close();
            return maxIdComptage;
        }

        public static ComptageDAO getComptage(int idComptage)
        {
            string query = "SELECT * FROM comptage WHERE id="+idComptage+";";
            MySqlCommand cmdComp = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdComp.ExecuteNonQuery();
            MySqlDataReader reader = cmdComp.ExecuteReader();
            reader.Read();
            ComptageDAO comptage = new ComptageDAO(reader.GetInt32(0), reader.GetDateTime(1), reader.GetDateTime(2), reader.GetBoolean(3), reader.GetInt32(4));
            reader.Close();
            return comptage;
        }

      
    }
}
