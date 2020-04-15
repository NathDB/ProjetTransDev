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
    public class ClasseDAL
    {

        public ClasseDAL()
        {
        }
        public static ObservableCollection<ClasseDAO> selectClasse()
        {
            ObservableCollection<ClasseDAO> liste = new ObservableCollection<ClasseDAO>();
            string query = "SELECT * from classes;";
            MySqlCommand cmdCla= new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdCla.ExecuteNonQuery();
                MySqlDataReader reader = cmdCla.ExecuteReader();

                while (reader.Read())
                {
                    ClasseDAO c = new ClasseDAO(reader.GetInt32(0), reader.GetString(1));
                    liste.Add(c);
                }
                reader.Close();
            }
            catch (Exception c)
            {
                MessageBox.Show("Classe La base de données n'est pas connectée" + c.Message);
            }
            return liste;
        }
        public static void updateClasse(ClasseDAO c)
        {
            string query = "UPDATE Classe set nom=\"" + c.nomDAO + ";";
            MySqlCommand cmdCla= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdCla);
            cmdCla.ExecuteNonQuery();
        }
        public static void insertClasse(ClasseDAO c)
        {
            int id = getMaxIdClasse() + 1;
            string query = "INSERT INTO classes VALUES (\"" + id + "\",\"" + c.nomDAO + "\");";
            MySqlCommand cmd2Cla= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Cla);
            cmd2Cla.ExecuteNonQuery();
        }

        public static void supprimerClasse(int id)
        {
            string query = "DELETE FROM classes WHERE id = \"" + id + "\";";
            MySqlCommand cmdCla= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdCla);
            cmdCla.ExecuteNonQuery();
        }
        public static int getMaxIdClasse()
        {
            string query = "SELECT MAX(id) FROM classes;";
            MySqlCommand cmdCla = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdCla.ExecuteNonQuery();

            MySqlDataReader reader = cmdCla.ExecuteReader();
            reader.Read();
            int maxIdClasse = reader.GetInt32(0);
            reader.Close();
            return maxIdClasse;
        }

        public static ClasseDAO getClasse(int id)
        {
            string query = "SELECT * FROM classes WHERE id=" + id + ";";
            MySqlCommand cmdCla = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdCla.ExecuteNonQuery();
            MySqlDataReader reader = cmdCla.ExecuteReader();
            reader.Read();
            ClasseDAO cla = new ClasseDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return cla;
        }
    }
}
