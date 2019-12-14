﻿using ProjetInfrocean.Ctrl;
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
            ZoneViewModel z = new ZoneViewModel(zDAO.idZoneDAO, zDAO.pointADAO, zDAO.pointBDAO, zDAO.pointCDAO, zDAO.pointDDAO, zDAO.superficieZoneDAO, zDAO.idPlageZoneDAO, zDAO.idComptageZoneDAO, zDAO.idEtudeZoneDAO);
            return z;
        }

        public static ObservableCollection<ZoneViewModel> listeZones()
        {
            ObservableCollection<ZoneDAO> listeDAO = ZoneDAO.listeZones();
            ObservableCollection<ZoneViewModel> liste = new ObservableCollection<ZoneViewModel>();
            foreach(ZoneDAO element in listeDAO)
            {
                ZoneViewModel z = new ZoneViewModel(element.idZoneDAO, element.pointADAO, element.pointBDAO, element.pointCDAO, element.pointDDAO, element.superficieZoneDAO, element.idPlageZoneDAO, element.idComptageZoneDAO, element.idEtudeZoneDAO);
                liste.Add(z);
            }
            return liste;
        }

        public static void updateZone(ZoneViewModel z)
        {
            ZoneDAO.updateEtude(new ZoneDAO(z.idZoneProperty, z.pointAProperty, z.pointBProperty, z.pointCProperty, z.pointDProperty, z.superficieZoneProperty, z.idPlageZoneProperty, z.idComptageZoneProperty, z.idEtudeZoneProperty));
        }
        public static void supprimerZone(int id)
        {
            ZoneDAO.supprimerEtude(id);
        }
        public static void insertZone(ZoneViewModel z)
        {
            ZoneDAO.insertEtude(new ZoneDAO(z.idZoneProperty, z.pointAProperty, z.pointBProperty, z.pointCProperty, z.pointDProperty, z.superficieZoneProperty, z.idPlageZoneProperty, z.idComptageZoneProperty, z.idEtudeZoneProperty));
        }
    }
}