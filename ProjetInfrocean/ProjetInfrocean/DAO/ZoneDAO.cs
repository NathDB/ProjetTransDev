using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class ZoneDAO
    {
        public int idZoneDAO;
        public decimal pointALoDAO;
        public decimal pointALaDAO;
        public decimal pointBLoDAO;
        public decimal pointBLaDAO;
        public decimal pointCLoDAO;
        public decimal pointCLaDAO;
        public decimal pointDLoDAO;
        public decimal pointDLaDAO;
        public decimal superficieZoneDAO;
        public int idPlageZoneDAO;
        public int idEtudeZoneDAO;
        public int idPlageDAO;
        public string nomPlageDAO;
        public string titreEtudeDAO;

        public ZoneDAO(int idPlageDAO, string nomPlageDAO, int idZoneDAO)
        {
            this.idPlageDAO = idPlageDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.idZoneDAO = idZoneDAO;
        }
        public ZoneDAO(int idZoneDAO, decimal pointALoDAO, decimal pointALaDAO, decimal pointBLoDAO, decimal pointBLaDAO, decimal pointCLoDAO, decimal pointCLaDAO, decimal pointDLoDAO, decimal pointDLaDAO, decimal superficieZoneDAO, string nomPlageDAO, string titreEtudeDAO)
        {
            this.idZoneDAO = idZoneDAO;
            this.pointALoDAO = pointALoDAO;
            this.pointALaDAO = pointALaDAO;
            this.pointBLoDAO = pointBLoDAO;
            this.pointBLaDAO = pointBLaDAO;
            this.pointCLoDAO = pointCLoDAO;
            this.pointCLaDAO = pointCLaDAO;
            this.pointDLoDAO = pointDLoDAO;
            this.pointDLaDAO = pointDLaDAO;
            this.superficieZoneDAO = superficieZoneDAO;
            this.nomPlageDAO = nomPlageDAO;
            this.titreEtudeDAO = titreEtudeDAO;
        }
        public ZoneDAO(int idZoneDAO, decimal pointALoDAO, decimal pointALaDAO, decimal pointBLoDAO, decimal pointBLaDAO, decimal pointCLoDAO, decimal pointCLaDAO, decimal pointDLoDAO, decimal pointDLaDAO, decimal superficieZoneDAO, int idPlageZoneDAO, int idEtudeZoneDAO)
        {
            this.idZoneDAO = idZoneDAO;
            this.pointALoDAO = pointALoDAO;
            this.pointALaDAO = pointALaDAO;
            this.pointBLoDAO = pointBLoDAO;
            this.pointBLaDAO = pointBLaDAO;
            this.pointCLoDAO = pointCLoDAO;
            this.pointCLaDAO = pointCLaDAO;
            this.pointDLoDAO = pointDLoDAO;
            this.pointDLaDAO = pointDLaDAO;
            this.superficieZoneDAO = superficieZoneDAO;
            this.idPlageZoneDAO = idPlageZoneDAO;
            this.idEtudeZoneDAO = idEtudeZoneDAO;  
        }

        public static ObservableCollection<ZoneDAO> listeZones(){
            ObservableCollection<ZoneDAO> liste = ZoneDAL.selectZones();
            return liste;
        }
        public static ObservableCollection<ZoneDAO> compteurZone()
        {
            ObservableCollection<ZoneDAO> liste = ZoneDAL.compteurZone();
            return liste;
        }
        public static ObservableCollection<ZoneDAO> listeAllZones()
        {
            ObservableCollection<ZoneDAO> liste = ZoneDAL.listeAllZones();
            return liste;
        }
        public static ZoneDAO getZone(int idZone)
        {
            ZoneDAO z = ZoneDAL.getZone(idZone);
            return z;
        }
        public static void updateEtude(ZoneDAO z)
        {
            ZoneDAL.updateZone(z);
            
        }
        public static void supprimerEtude(int id)
        {
            ZoneDAL.supprimerZone(id);

        }
        public static void insertEtude(ZoneDAO z)
        {
            ZoneDAL.insertZone(z);

        }
    }
}
