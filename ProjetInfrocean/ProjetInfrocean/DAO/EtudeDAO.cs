﻿using ProjetInfrocean.DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.DAO
{
    public class EtudeDAO
    {
        public int idEtudeDAO;
        public string titreEtudeDAO;
        public string dateCreationEtudeDAO;
        public string dateFinEtudeDAO;

        public EtudeDAO(int idEtudeDAO, string titreEtudeDAO, string dateCreationEtudeDAO, string dateFinEtudeDAO)
        {
            this.idEtudeDAO = idEtudeDAO;
            this.titreEtudeDAO = titreEtudeDAO;
            this.dateCreationEtudeDAO = dateCreationEtudeDAO;
            this.dateFinEtudeDAO = dateFinEtudeDAO;
        }

        public static ObservableCollection<EtudeDAO> listeEtudes(){
            ObservableCollection<EtudeDAO> liste = EtudeDAL.selectEtudes();
            return liste;
        }
        public static EtudeDAO getEtude(int idEtude)
        {
            EtudeDAO e = EtudeDAL.getEtude(idEtude);
            return e;
        }
        public static void updateEtude(EtudeDAO e)
        {
            EtudeDAL.updateEtude(e);
            
        }
        public static void supprimerEtude(int id)
        {
            EtudeDAL.supprimerEtude(id);

        }
        public static void insertEtude(EtudeDAO e)
        {
            EtudeDAL.insertEtude(e);

        }
    }
}