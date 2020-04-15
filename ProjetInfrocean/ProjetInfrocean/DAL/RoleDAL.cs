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
    public class RoleDAL
    {

        public RoleDAL()
        {
        }
        public static ObservableCollection<RoleDAO> selectRole()
        {
            ObservableCollection<RoleDAO> liste = new ObservableCollection<RoleDAO>();
            string query = "SELECT * from roles;";
            MySqlCommand cmdRol= new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmdRol.ExecuteNonQuery();
                MySqlDataReader reader = cmdRol.ExecuteReader();

                while (reader.Read())
                {
                    RoleDAO r = new RoleDAO(reader.GetInt32(0), reader.GetString(1));
                    liste.Add(r);
                }
                reader.Close();
            }
            catch (Exception r)
            {
                MessageBox.Show("Role La base de données n'est pas connectée" + r.Message);
            }
            return liste;
        }
        public static void updateRole(RoleDAO r)
        {
            string query = "UPDATE Role set nom=\"" + r.nomDAO +" set description =\"" + r.descriptionDAO + ";";
            MySqlCommand cmdRol= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdRol);
            cmdRol.ExecuteNonQuery();
        }
        public static void insertRole(RoleDAO r)
        {
            int id = getMaxIdRole() + 1;
            string query = "INSERT INTO roles VALUES (\"" + id + "\",\"" + d.nomDAO + "\",\"" + d.descriptionDAO + "\");";
            MySqlCommand cmd2Rol= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Rol);
            cmd2Rol.ExecuteNonQuery();
        }

        public static void supprimerRole(int id)
        {
            string query = "DELETE FROM roles WHERE id = \"" + id + "\";";
            MySqlCommand cmdRol= new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdRol);
            cmdRol.ExecuteNonQuery();
        }
        public static int getMaxIdRole()
        {
            string query = "SELECT MAX(id) FROM roles;";
            MySqlCommand cmdRol= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdRol.ExecuteNonQuery();

            MySqlDataReader reader = cmdRol.ExecuteReader();
            reader.Read();
            int maxIdRole = reader.GetInt32(0);
            reader.Close();
            return maxIdRole;
        }

        public static RoleDAO getRole(int id)
        {
            string query = "SELECT * FROM roles WHERE id=" + id + ";";
            MySqlCommand cmdRol= new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdRol.ExecuteNonQuery();
            MySqlDataReader reader = cmdRol.ExecuteReader();
            reader.Read();
            RoleDAO rol = new RoleDAO(reader.GetInt32(0), reader.GetString(1));
            reader.Close();
            return rol;
        }
    }
}
