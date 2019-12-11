﻿using MySql.Data.MySqlClient;
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
    public class PlageDAL
    {
        private static MySqlConnection connection;
        public PlageDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DalConnexion.connection;
        }
        public static ObservableCollection<PlageDAO> selectPlages()
        {
            ObservableCollection<PlageDAO> l = new ObservableCollection<PlageDAO>();
            string query = "SELECT * FROM plage;";
            MySqlCommand cmd = new MySqlCommand(query, DalConnexion.OpenConnection());
            try
            {
                cmd.ExecuteNonQuery();
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    PlageDAO pl = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
                    l.Add(pl);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return l;
        }
        
        public static void insertPlage(PlageDAO pl)
        {
            int id = getMaxIdPlage() + 1;
            string query = "INSERT INTO plage VALUES (\"" + id + "\",\"" + pl.nomPlageDAO + "\",\"" + pl.departementPlageDAO + "\",\"" + pl.communePlageDAO +"\");";
            MySqlCommand cmd2Plage = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2Plage);
            cmd2Plage.ExecuteNonQuery();
        }

        public static void updatePlage(PlageDAO pl)
        {
            string query = "UPDATE plage set nomPlage=\"" + pl.nomPlageDAO + "\", departementPlage=\"" + pl.departementPlageDAO + "\", communePlage=\"" + pl.communePlageDAO;
            MySqlCommand cmdPlage = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdPlage);
            cmdPlage.ExecuteNonQuery();
        }

        public static void supprimerPlage(int id)
        {
            string query = "DELETE FROM plage WHERE idPlage = \"" + id + "\";";
            MySqlCommand cmdPlage = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdPlage);
            cmdPlage.ExecuteNonQuery();
        }

        public static int getMaxIdPlage()
        {
            string query = "SELECT MAX(idPlage) FROM plage;";
            MySqlCommand cmdPlage = new MySqlCommand(query, DalConnexion.connection);
            cmdPlage.ExecuteNonQuery();

            MySqlDataReader reader = cmdPlage.ExecuteReader();
            reader.Read();
            int maxIdPlage = reader.GetInt32(0);
            reader.Close();
            return maxIdPlage;
        }

        public static PlageDAO getPlage(int idPlage)
        {
            string query = "SELECT * FROM plage WHERE id="+idPlage+";";
            MySqlCommand cmdPlage = new MySqlCommand(query, connection);
            cmdPlage.ExecuteNonQuery();
            MySqlDataReader reader = cmdPlage.ExecuteReader();
            reader.Read();
            PlageDAO plage = new PlageDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3));
            reader.Close();
            return plage;
        }

      
    }
}
