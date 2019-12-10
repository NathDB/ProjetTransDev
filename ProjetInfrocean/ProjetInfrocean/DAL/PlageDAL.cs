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
    public class PersonneDAL
    {
        private static MySqlConnection connection;
        public PersonneDAL()
        {
            //  si la connexion est déjà ouverte, il ne la refera pas (voir code dans DALConnection)
            connection = DalConnexion.connection;
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
                    PersonneDAO p = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
                    l.Add(p);
                }
                reader.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("La base de données n'est pas connectée");
            }
            return l;
        }
        public static int getMaxIdPersonne()
        {
            string query = "SELECT MAX(idPersonne) FROM personne;";
            MySqlCommand cmdPers = new MySqlCommand(query, DalConnexion.connection);
            cmdPers.ExecuteNonQuery();

            MySqlDataReader reader = cmdPers.ExecuteReader();
            reader.Read();
            int maxIdPersonne = reader.GetInt32(0);
            reader.Close();
            return maxIdPersonne;
        }
        public static void insertPersonne(PersonneDAO p)
        {
            int id = getMaxIdPersonne() + 1;
            string query = "INSERT INTO personne VALUES (\"" + id + "\",\"" + p.nomPersonneDAO + "\",\"" + p.prenomPersonneDAO + "\",\"" + p.etudePersonneDAO + "\",\"" + p.isAdminPersonneDAO + "\");";
            MySqlCommand cmd2Pers = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmd2Pers);
            cmd2Pers.ExecuteNonQuery();
        }

        public static void updatePersonne(PersonneDAO p)
        {
            string query = "UPDATE personne set nomPersonne=\"" + p.nomPersonneDAO + "\", prenomPersonne=\"" + p.prenomPersonneDAO;
            MySqlCommand cmdPers = new MySqlCommand(query, connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdPers);
            cmdPers.ExecuteNonQuery();
        }

        public static void supprimerPersonne(int id)
        {
            string query = "DELETE FROM personne WHERE idPersonne = \"" + id + "\";";
            MySqlCommand cmdPers = new MySqlCommand(query, DalConnexion.connection);
            MySqlDataAdapter sqlDataAdap = new MySqlDataAdapter(cmdPers);
            cmdPers.ExecuteNonQuery();
        }
        public static PersonneDAO getPersonne(int idPersonne)
        {
            string query = "SELECT * FROM personne WHERE id="+idPersonne+";";
            MySqlCommand cmdPers = new MySqlCommand(query, connection);
            cmdPers.ExecuteNonQuery();
            MySqlDataReader reader = cmdPers.ExecuteReader();
            reader.Read();
            PersonneDAO pers = new PersonneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetInt32(3), reader.GetInt32(4));
            reader.Close();
            return pers;
        }

      
    }
}