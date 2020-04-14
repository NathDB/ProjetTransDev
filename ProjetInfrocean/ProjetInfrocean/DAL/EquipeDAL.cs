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
    public class EquipeDAL
    {

        public EquipeDAL()
        {}
        public static ObservableCollection<EquipeDAO> listeAllEquipes()
        {
            ObservableCollection<EquipeDAO> liste = new ObservableCollection<EquipeDAO>();
            string query = "select equipe.idEquipe,  equipe.nom, personne.nom, etude.titre " +
                "FROM equipe " +
                "join personne on personne.idPersonne = equipe.Personne_idPersonne " +
                "join etude on etude.idEtude = equipe.Etude_idEtude;";
            MySqlCommand cmdEquipe = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmdEquipe.ExecuteNonQuery();
                reader = cmdEquipe.ExecuteReader();

                while (reader.Read())
                {
                    EquipeDAO e = new EquipeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    liste.Add(e);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Equipe : La base de données n'est pas connectée" + e.Message);
            }
            reader.Close();

            return liste;
        }
        public static ObservableCollection<EquipeDAO> selectEquipes()
        {
            ObservableCollection<EquipeDAO> liste = new ObservableCollection<EquipeDAO>();
            string query = "SELECT * from equipe;";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataReader reader=null;
            try
            {
                cmdEtu.ExecuteNonQuery();
                reader = cmdEtu.ExecuteReader();

                while (reader.Read())
                {
                    EquipeDAO e = new EquipeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
                    liste.Add(e);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("equipe : La base de données n'est pas connectée"+e.Message);
            }
            reader.Close();

            return liste;
        }
        /*public static ObservableCollection<EquipeDAO> compteurEquipe()
        {
            ObservableCollection<EquipeDAO> liste = new ObservableCollection<EquipeDAO>();
            string query = "SELECT personne.idPersonne, personne.nom, COUNT(zone.idZone)" +
                "FROM zone " +
                "JOIN plage on plage.idPlage=eone.Plage_idPlage " +
                "GROUP BY plage.idPlage, plage.nom;";
            MySqlCommand cmdCompteurZone = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataReader reader = null;
            try
            {
                cmdCompteurZone.ExecuteNonQuery();
                reader = cmdCompteurZone.ExecuteReader();

                while (reader.Read())
                {
                    ZoneDAO z = new ZoneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2));
                    liste.Add(z);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("zone : La base de données n'est pas connectée" + e.Message);
            }
            reader.Close();

            return liste;
        }*/
        public static void updateEquipe(EquipeDAO e)
        {
            string query = "UPDATE equipe set nom=\"" + e.nomEquipeDAO + ";";
            MySqlCommand cmdEquipe = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdEquipe);
            cmdEquipe.ExecuteNonQuery();
        }
        public static void insertEquipe(EquipeDAO e)
        {
            int id = getMaxIdEquipe() + 1;
            string query = "INSERT INTO Equipe VALUES (\"" + id + "\",\"" + e.nomEquipeDAO + "\");";
            MySqlCommand cmd2Equipe = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Equipe);
            cmd2Equipe.ExecuteNonQuery();
        }

        public static void supprimerEquipe(int id)
        {
            string query = "DELETE FROM equipe WHERE idEquipe = \"" + id + "\";";
            MySqlCommand cmdEquipe = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdEquipe);
            cmdEquipe.ExecuteNonQuery();
        }
        public static int getMaxIdEquipe()
        {
            string query = "SELECT MAX(idEquipe) FROM equipe;";
            MySqlCommand cmdEquipe = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdEquipe.ExecuteNonQuery();

            MySqlDataReader reader = cmdEquipe.ExecuteReader();
            reader.Read();
            int maxIdEquipe = reader.GetInt32(0);
            reader.Close();
            return maxIdEquipe;
        }

        public static EquipeDAO getEquipe(int idEquipe)
        {
            string query = "SELECT * FROM equipe WHERE idEquipe=" + idEquipe + ";";
            MySqlCommand cmdEquipe = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdEquipe.ExecuteNonQuery();
            MySqlDataReader reader = cmdEquipe.ExecuteReader();
            reader.Read();
            EquipeDAO Equipe = new EquipeDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3));
            reader.Close();
            return Equipe;
        }
    }
}
