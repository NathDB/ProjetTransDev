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
    public class PersonneDAL
    {
        public PersonneDAL()
        {
        }
        public static ObservableCollection<PersonneDAO> selectPersonnes()
        {
            ObservableCollection<PersonneDAO> l = new ObservableCollection<PersonneDAO>();
            string query = "SELECT * FROM personne;";
            MySqlCommand cmd = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PersonneDAO p = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6));
                    l.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Personne La base de données n'est pas connectée" + e.Message);
            }
            return l;
        }
        /*public static void getEtudeFaite(PersonneDAO p)
        { 
            string query = "SELECT titre FROM etude e join personne p on p.idEtude=e.id";
            MySqlCommand cmd2Pers = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2Pers);
            cmd2Pers.ExecuteNonQuery();
        }*/
        public static void insertPersonne(PersonneDAO p)
        {
            int id = getMaxIdPersonne() + 1;
            string query = "INSERT INTO personne VALUES (\"" + id + "\",\"" + p.nomDAO + "\",\"" + p.prenomDAO + "\",\"" + p.emailDAO + "\",\"" + p.mdpDAO + "\",\"" + p.rolePersonneDAO + "\",\"" + p.equipePersonneDAO + "\");";
            MySqlCommand cmd2Pers = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2Pers);
            cmd2Pers.ExecuteNonQuery();
        }

        public static void updatePersonne(PersonneDAO p)
        {
            string query = "UPDATE personne set nom=\"" + p.nomDAO + "\", prenom=\"" + p.prenomDAO;
            MySqlCommand cmdPers = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdPers);
            cmdPers.ExecuteNonQuery();
        }

        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM personne WHERE idPersonne = \"" + id + "\";";
            MySqlCommand cmdPers = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdPers);
            cmdPers.ExecuteNonQuery();
        }
        public static int getMaxIdPersonne()
        {
            string query = "SELECT MAX(idPersonne) FROM personne;";
            MySqlCommand cmdPers = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdPers.ExecuteNonQuery();

            MySqlDataReader reader = cmdPers.ExecuteReader();
            reader.Read();
            int maxIdPersonne = reader.GetInt32(0);
            reader.Close();
            return maxIdPersonne;
        }


        public static PersonneDAO getPersonne(int idPersonne)
        {
            string query = "SELECT * FROM personne WHERE idPersonne="+idPersonne+";";
            MySqlCommand cmdPers = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdPers.ExecuteNonQuery();
            MySqlDataReader reader = cmdPers.ExecuteReader();
            reader.Read();
            PersonneDAO pers = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6));
            reader.Close();
            return pers;
        }

      
    }
}
