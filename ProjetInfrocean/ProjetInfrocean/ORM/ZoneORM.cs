using ProjetInfrocean.Ctrl;
using ProjetInfrocean.DAO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.ORM
{
    public class ZoneORM
    {
        public static ZoneViewModel getZone(int idZone)
        {
            ZoneDAO zDAO = ZoneDAO.getZone(idZone);
            ZoneViewModel z = new ZoneViewModel(zDAO.idZoneDAO, zDAO.pointALoDAO, zDAO.pointALaDAO, zDAO.pointBLoDAO, zDAO.pointBLaDAO, zDAO.pointCLoDAO, zDAO.pointCLaDAO, zDAO.pointDLoDAO, zDAO.pointDLaDAO, zDAO.superficieZoneDAO, PlageORM.getPlage(zDAO.idPlageZoneDAO), EtudeORM.getEtude(zDAO.idEtudeZoneDAO));
            return z;
        }

        public static ObservableCollection<ZoneViewModel> listeZones()
        {
            ObservableCollection<ZoneDAO> listeDAO = ZoneDAO.listeZones();
            ObservableCollection<ZoneViewModel> liste = new ObservableCollection<ZoneViewModel>();
            foreach(ZoneDAO element in listeDAO)
            {
                ZoneViewModel z = new ZoneViewModel(element.idZoneDAO, element.pointALoDAO, element.pointALaDAO, element.pointBLoDAO, element.pointBLaDAO, element.pointCLoDAO,element.pointCLaDAO, element.pointDLoDAO, element.pointDLaDAO, element.superficieZoneDAO, PlageORM.getPlage(element.idPlageZoneDAO), EtudeORM.getEtude(element.idEtudeZoneDAO));
                liste.Add(z);
            }
            return liste;
        }
        public static ObservableCollection<ZoneViewModel> listeAllZones()
        {
            ObservableCollection<ZoneDAO> listeDAO = ZoneDAO.listeAllZones();
            ObservableCollection<ZoneViewModel> liste = new ObservableCollection<ZoneViewModel>();
            foreach (ZoneDAO element in listeDAO)
            {
                ZoneViewModel z = new ZoneViewModel(element.idZoneDAO, element.pointALoDAO, element.pointALaDAO, element.pointBLoDAO, element.pointBLaDAO, element.pointCLoDAO, element.pointCLaDAO, element.pointDLoDAO, element.pointDLaDAO, element.superficieZoneDAO, PlageORM.getPlage(element.idPlageZoneDAO), EtudeORM.getEtude(element.idEtudeZoneDAO));
                liste.Add(z);
            }
            return liste;
        }
        public static ObservableCollection<ZoneViewModel> compteurZone()
        {
            ObservableCollection<ZoneDAO> listeDAO = ZoneDAO.compteurZone();
            ObservableCollection<ZoneViewModel> liste = new ObservableCollection<ZoneViewModel>();
            foreach (ZoneDAO element in listeDAO)
            {
                ZoneViewModel z = new ZoneViewModel(element.idPlageDAO, element.nomPlageDAO, element.idZoneDAO);
                liste.Add(z);
            }
            return liste;
        }

        public static void updateZone(ZoneViewModel z)
        {
            ZoneDAO.updateEtude(new ZoneDAO(z.idZoneProperty, z.pointALoProperty, z.pointALaProperty, z.pointBLoProperty, z.pointBLaProperty, z.pointCLoProperty, z.pointCLaProperty, z.pointDLoProperty, z.pointDLaProperty, z.superficieZoneProperty, z.PlageProperty.idPlageProperty, z.idEtudeProperty.idEtudeProperty));
        }
        public static void supprimerZone(int id)
        {
            ZoneDAO.supprimerEtude(id);
        }
        public static void insertZone(ZoneViewModel z)
        {
            ZoneDAO.insertEtude(new ZoneDAO(z.idZoneProperty, z.pointALoProperty, z.pointALaProperty, z.pointBLoProperty, z.pointBLaProperty, z.pointCLoProperty, z.pointCLaProperty, z.pointDLoProperty, z.pointDLaProperty, z.superficieZoneProperty, z.PlageProperty.idPlageProperty, z.idEtudeProperty.idEtudeProperty));
        }
    }
}
