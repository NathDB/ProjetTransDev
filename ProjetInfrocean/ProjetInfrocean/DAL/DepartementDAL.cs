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
    public class DepartementDAL
    {

        public DepartementDAL()
        {
        }
        public static ObservableCollection<DepartementDAO> selectDepartement()
        {
            ObservableCollection<DepartementDAO> liste = new ObservableCollection<DepartementDAO>();
            string query = "SELECT * from departements;";
            MySqlCommand cmdDep= new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdDep.ExecuteNonQuery();
                MySqlDataReader reader = cmdDep.ExecuteReader();

                while (reader.Read())
                {
                    DepartementDAO d = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
                    liste.Add(d);
                }
                reader.Close();
            }
            catch (Exception d)
            {
                MessageBox.Show("Departement La base de données n'est pas connectée" + d.Message);
            }
            return liste;
        }
        public static void updateDepartement(DepartementDAO d)
        {
            string query = "UPDATE Departement set nom=\"" + d.nomDAO + ";";
            MySqlCommand cmdDep= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdDep);
            cmdDep.ExecuteNonQuery();
        }
        public static void insertDepartement(DepartementDAO d)
        {
            int id = getMaxIdDepartement() + 1;
            string query = "INSERT INTO departements VALUES (\"" + id + "\",\"" + d.nomDAO + "\");";
            MySqlCommand cmd2Dep= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Dep);
            cmd2Dep.ExecuteNonQuery();
        }

        public static void supprimerDepartement(int id)
        {
            string query = "DELETE FROM departements WHERE id = \"" + id + "\";";
            MySqlCommand cmdDep= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdDep);
            cmdDep.ExecuteNonQuery();
        }
        public static int getMaxIdDepartement()
        {
            string query = "SELECT MAX(id) FROM departements;";
            MySqlCommand cmdDep= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdDep.ExecuteNonQuery();

            MySqlDataReader reader = cmdDep.ExecuteReader();
            reader.Read();
            int maxIdDepartement = reader.GetInt32(0);
            reader.Close();
            return maxIdDepartement;
        }

        public static DepartementDAO getDepartement(int id)
        {
            string query = "SELECT * FROM departements WHERE id=" + id + ";";
            MySqlCommand cmdDep= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdDep.ExecuteNonQuery();
            MySqlDataReader reader = cmdDep.ExecuteReader();
            reader.Read();
            DepartementDAO dep = new DepartementDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return dep;
        }
    }
}
