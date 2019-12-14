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
        public string pointADAO;
        public string pointBDAO;
        public string pointCDAO;
        public string pointDDAO;
        public int superficieZoneDAO;
        public int idPlageZoneDAO;
        public int idComptageZoneDAO;
        public int idEtudeZoneDAO;

        public ZoneDAO(int idZoneDAO, string pointADAO, string pointBDAO, string pointCDAO, string pointDDAO, int superficieZoneDAO, int idPlageZoneDAO, int idComptageZoneDAO, int idEtudeZoneDAO)
        {
            this.idZoneDAO = idZoneDAO;
            this.pointADAO = pointADAO;
            this.pointBDAO = pointBDAO;
            this.pointCDAO = pointCDAO;
            this.pointDDAO = pointDDAO;
            this.superficieZoneDAO = superficieZoneDAO;
            this.idPlageZoneDAO = idPlageZoneDAO;
            this.idComptageZoneDAO = idComptageZoneDAO;
            this.idEtudeZoneDAO = idEtudeZoneDAO;

            
        }

        public static ObservableCollection<ZoneDAO> listeZones(){
            ObservableCollection<ZoneDAO> liste = ZoneDAL.selectZones();
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
