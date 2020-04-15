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
    public class FamilleDAL
    {

        public FamilleDAL()
        {
        }
        public static ObservableCollection<FamilleDAO> selectFamille()
        {
            ObservableCollection<FamilleDAO> liste = new ObservableCollection<FamilleDAO>();
            string query = "SELECT * from familles;";
            MySqlCommand cmdFam = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdFam.ExecuteNonQuery();
                MySqlDataReader reader = cmdFam.ExecuteReader();

                while (reader.Read())
                {
                    FamilleDAO f = new FamilleDAO(reader.GetInt32(0), reader.GetString(1));
                    liste.Add(f);
                }
                reader.Close();
            }
            catch (Exception f)
            {
                MessageBox.Show("Famille La base de données n'est pas connectée" + f.Message);
            }
            return liste;
        }
        public static void updateFamille(FamilleDAO f)
        {
            string query = "UPDATE familles set nom=\"" + f.nomDAO + ";";
            MySqlCommand cmdFam = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdFam);
            cmdFam.ExecuteNonQuery();
        }
        public static void insertFamille(FamilleDAO f)
        {
            int id = getMaxIdOrdre() + 1;
            string query = "INSERT INTO familles VALUES (\"" + id + "\",\"" + f.nomDAO + "\");";
            MySqlCommand cmd2Fam= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Fam);
            cmd2Fam.ExecuteNonQuery();
        }

        public static void supprimerFamille(int id)
        {
            string query = "DELETE FROM familles WHERE id = \"" + id + "\";";
            MySqlCommand cmdFam= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdFam);
            cmdFam.ExecuteNonQuery();
        }
        public static int getMaxIdFamille()
        {
            string query = "SELECT MAX(id) FROM ordres;";
            MySqlCommand cmdOrd = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdOrd.ExecuteNonQuery();

            MySqlDataReader reader = cmdFam.ExecuteReader();
            reader.Read();
            int maxIdFamille = reader.GetInt32(0);
            reader.Close();
            return maxIdFamille;
        }

        public static FamilleDAO getFamille(int id)
        {
            string query = "SELECT * FROM familles WHERE id=" + id + ";";
            MySqlCommand cmdFam= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdFam.ExecuteNonQuery();
            MySqlDataReader reader = cmdFam.ExecuteReader();
            reader.Read();
            FamilleDAO fam= new FamilleDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return fam;
        }
    }
}
