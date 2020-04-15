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
    public class EspeceORM
    {
        public static EspeceViewModel getEspece(int idEspece)
        {
            EspeceDAO esDAO = EspeceDAO.getEspece(idEspece);
            EspeceViewModel es = new EspeceViewModel(esDAO.idEspeceDAO, esDAO.nomDAO, esDAO.quantiteDAO);
            return es;
        }

        public static ObservableCollection<EspeceViewModel> listeEspeces()
        {
            ObservableCollection<EspeceDAO> listeDAO = EspeceDAO.listeEspeces();
            ObservableCollection<EspeceViewModel> liste = new ObservableCollection<EspeceViewModel>();
            foreach(EspeceDAO element in listeDAO)
            {
                EspeceViewModel es = new EspeceViewModel(element.idEspeceDAO, element.nomDAO, element.quantiteDAO);
                liste.Add(es);
            }
            return liste;
        }

        public static void updateEspece(EspeceViewModel es)
        {
            EspeceDAO.updateEspece(new EspeceDAO(es.idEspeceProperty, es.nomProperty, es.quantiteProperty));
        }
        public static void supprimerEspece(int id)
        {
            EspeceDAO.supprimerEspece(id);
        }
        public static void insertEspece(EspeceViewModel es)
        {
            EspeceDAO.insertEspece(new EspeceDAO(es.idEspeceProperty, es.nomProperty, es.quantiteProperty));
        }
    }
}
