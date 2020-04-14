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
    public class EquipeORM
    {
        public static EquipeViewModel getEquipe(int idEquipe)
        {
            EquipeDAO eDAO = EquipeDAO.getEquipe(idEquipe);
            EquipeViewModel e = new EquipeViewModel(eDAO.idEquipeDAO, eDAO.nomEquipeDAO, PersonneORM.getPersonne(eDAO.idPersonneEquipeDAO), EtudeORM.getEtude(eDAO.idEtudeEquipeDAO));
            return e;
        }

        public static ObservableCollection<EquipeViewModel> listeEquipes()
        {
            ObservableCollection<EquipeDAO> listeDAO = EquipeDAO.listeEquipes();
            ObservableCollection<EquipeViewModel> liste = new ObservableCollection<EquipeViewModel>();
            foreach(EquipeDAO element in listeDAO)
            {
                EquipeViewModel z = new EquipeViewModel(element.idEquipeDAO, element.nomEquipeDAO, PersonneORM.getPersonne(element.idPersonneEquipeDAO), EtudeORM.getEtude(element.idEtudeEquipeDAO));
                liste.Add(z);
            }
            return liste;
        }
        public static ObservableCollection<EquipeViewModel> listeAllEquipes()
        {
            ObservableCollection<EquipeDAO> listeDAO = EquipeDAO.listeAllEquipes();
            ObservableCollection<EquipeViewModel> liste = new ObservableCollection<EquipeViewModel>();
            foreach (EquipeDAO element in listeDAO)
            {
                EquipeViewModel z = new EquipeViewModel(element.idEquipeDAO, element.nomEquipeDAO, PersonneORM.getPersonne(element.idPersonneEquipeDAO), EtudeORM.getEtude(element.idEtudeEquipeDAO));
                liste.Add(z);
            }
            return liste;
        }
        /*public static ObservableCollection<EquipeViewModel> compteurEquipe()
        {
            ObservableCollection<EquipeDAO> listeDAO = EquipeDAO.compteurEquipe();
            ObservableCollection<EquipeViewModel> liste = new ObservableCollection<EquipeViewModel>();
            foreach (EquipeDAO element in listeDAO)
            {
                EquipeViewModel z = new EquipeViewModel(element.idPlageDAO, element.nomPlageDAO, element.idEquipeDAO);
                liste.Add(z);
            }
            return liste;
        }*/

        public static void updateEquipe(EquipeViewModel e)
        {
            EquipeDAO.updateEtude(new EquipeDAO(e.idEquipeProperty, e.nomEquipeProperty, e.idPersonneProperty.idPersonneProperty, e.idEtudeProperty.idEtudeProperty));
        }
        public static void supprimerEquipe(int id)
        {
            EquipeDAO.supprimerEtude(id);
        }
        public static void insertEquipe(EquipeViewModel e)
        {
            EquipeDAO.insertEtude(new EquipeDAO(e.idEquipeProperty, e.nomEquipeProperty, e.idPersonneProperty.idPersonneProperty , e.idEtudeProperty.idEtudeProperty));
        }
    }
}
