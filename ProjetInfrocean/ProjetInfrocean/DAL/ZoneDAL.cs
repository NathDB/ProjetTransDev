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
    public class ZoneDAL
    {

        public ZoneDAL()
        {}
        public static ObservableCollection<ZoneDAO> selectZones()
        {
            ObservableCollection<ZoneDAO> liste = new ObservableCollection<ZoneDAO>();
            string query = "SELECT * from zone;";
            MySqlCommand cmdEtu = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataReader reader=null;
            try
            {
                cmdEtu.ExecuteNonQuery();
                reader = cmdEtu.ExecuteReader();

                while (reader.Read())
                {
                    ZoneDAO z = new ZoneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
                    liste.Add(z);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("zone : La base de données n'est pas connectée"+e.Message);
            }
            reader.Close();

            return liste;
        }
        public static void updateZone(ZoneDAO z)
        {
            string query = "UPDATE zone set pointA=\"" + z.pointADAO + "\",  pointB = \"" + z.pointBDAO + "\",   pointC = \"" + z.pointCDAO + "\",   pointD = \"" + z.pointDDAO + "\",  superficieZone = \"" + z.superficieZoneDAO + ";";
            MySqlCommand cmdZone = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdZone);
            cmdZone.ExecuteNonQuery();
        }
        public static void insertZone(ZoneDAO z)
        {
            int id = getMaxIdZone() + 1;
            string query = "INSERT INTO zone VALUES (\"" + id + "\",\"" + z.pointADAO + "\",\"" + z.pointBDAO + "\",\"" + z.pointCDAO + "\",\"" + z.pointDDAO + "\",\"" + z.superficieZoneDAO + "\");";
            MySqlCommand cmd2Zone = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmd2Zone);
            cmd2Zone.ExecuteNonQuery();
        }

        public static void supprimerZone(int id)
        {
            string query = "DELETE FROM zone WHERE idZone = \"" + id + "\";";
            MySqlCommand cmdZone = new MySqlCommand(query, DalConnexion.OpenConnection());
            MySqlDataAdapter sqlDataAdpat = new MySqlDataAdapter(cmdZone);
            cmdZone.ExecuteNonQuery();
        }
        public static int getMaxIdZone()
        {
            string query = "SELECT MAX(idZone) FROM zone;";
            MySqlCommand cmdZone = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdZone.ExecuteNonQuery();

            MySqlDataReader reader = cmdZone.ExecuteReader();
            reader.Read();
            int maxIdZone = reader.GetInt32(0);
            reader.Close();
            return maxIdZone;
        }

        public static ZoneDAO getZone(int idZone)
        {
            string query = "SELECT * FROM zone WHERE idZone=" + idZone + ";";
            MySqlCommand cmdZone = new MySqlCommand(query, DalConnexion.OpenConnection());
            cmdZone.ExecuteNonQuery();
            MySqlDataReader reader = cmdZone.ExecuteReader();
            reader.Read();
            ZoneDAO zone = new ZoneDAO(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(6), reader.GetInt32(7));
            reader.Close();
            return zone;
        }
    }
}
