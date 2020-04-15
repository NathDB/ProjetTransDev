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
    class PersonneORM
    {
        public static PersonneViewModel getPersonne(int idPersonne)
        {
            PersonneDAO pDAO = PersonneDAO.getPersonne(idPersonne);
            PersonneViewModel p = new PersonneViewModel(pDAO.idPersonneDAO, pDAO.nomDAO, pDAO.prenomDAO, pDAO.emailDAO, pDAO.mdpDAO, RoleORM.getRole(pDAO.idRolePersonneDAO), EquipeORM.getEquipe(pDAO.idEquipePersonneDAO));
            return p;
        }

        public static ObservableCollection<PersonneViewModel> listePersonnes()
        {
            ObservableCollection<PersonneDAO> lDAO = PersonneDAO.listePersonnes();
            ObservableCollection<PersonneViewModel> l = new ObservableCollection<PersonneViewModel>();
            foreach (PersonneDAO element in lDAO)
            {                
                PersonneViewModel p = new PersonneViewModel(element.idPersonneDAO, element.nomDAO, element.prenomDAO, element.emailDAO, element.mdpDAO, RoleORM.getRole(element.idRolePersonneDAO), EquipeORM.getEquipe(element.idEquipePersonneDAO));
                l.Add(p);
            }
            return l;
        }


        
        public static void updatePersonne(PersonneViewModel p)
        {
            PersonneDAO.updatePersonne(new PersonneDAO(p.idPersonneProperty, p.nomProperty, p.prenomProperty, p.emailProperty, p.mdpProperty, p.rolePersonneProperty.idRoleProperty, p.equipePersonneProperty.idEquipeProperty));
        }

        public static void supprimerPersonne(int id)
        {
            PersonneDAO.supprimerPersonne(id);
        } 

        public static void insertPersonne(PersonneViewModel p)
        {
            PersonneDAO.insertPersonne(new PersonneDAO(p.idPersonneProperty, p.nomProperty, p.prenomProperty, p.emailProperty, p.mdpProperty, p.rolePersonneProperty.idRoleProperty, p.equipePersonneProperty.idEquipeProperty));
        }
    }
}

