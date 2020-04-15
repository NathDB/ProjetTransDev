using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class PersonneViewModel
    {
        
        private int idPersonne;
        private string nom;
        private string prenom;
        private string email;
        private string mdp;
        private RoleViewModel idRolePersonne;
        private EquipeViewModel idEquipePersonne;
        //private string concat;
        
        public PersonneViewModel() { }

        public PersonneViewModel(int idPersonne, string nom, string prenom, string email, string mdp, RoleViewModel rolePersonneProperty, EtudeViewModel etudePersonneProperty)
        {
            this.idPersonne = idPersonne;
            this.nomProperty = nom;
            this.prenomProperty = prenom;
            this.emailProperty = email;
            this.mdpProperty = mdp;
            this.rolePersonneProperty = rolePersonneProperty;
            this.etudePersonneProperty = etudePersonneProperty;
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
        }

        public String nomProperty
        {
            get { return nom; }
            set
            {
                nom = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomPersonne;
                OnPropertyChanged("nomProperty");
            }

        }
        public String prenomProperty
        {
            get { return prenom; }
            set
            {
                this.prenomPersonne = value;
                this.concatProperty = this.nomPersonne + " " + value;
                OnPropertyChanged("prenomPersonneProperty");
            }
        }
        public EtudeViewModel etudePersonneProperty
        {
            get { return etudePersonne; }
            set
            {
                this.etudePersonne = value;
                OnPropertyChanged("etudePersonneProperty");
            }
        }
        public int isAdminPersonneProperty
        {
            get { return isAdminPersonne; }
            set
            {
                this.isAdminPersonne =value;
                OnPropertyChanged("isAdminPersonneProperty");
            }
        }

        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }

       
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                PersonneORM.updatePersonne(this);
            }
        }
    }
}

