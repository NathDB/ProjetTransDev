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

        public PersonneViewModel(int idPersonne, string nom, string prenom, string email, string mdp, RoleViewModel rolePersonneProperty, EquipeViewModel equipePersonneProperty)
        {
            this.idPersonne = idPersonne;
            this.nomProperty = nom;
            this.prenomProperty = prenom;
            this.emailProperty = email;
            this.mdpProperty = mdp;
            this.rolePersonneProperty = rolePersonneProperty;
            this.equipePersonneProperty = equipePersonneProperty;
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
                this.prenom = value;
                this.concatProperty = this.nom + " " + value;
                OnPropertyChanged("prenomProperty");
            }
        }
        public String emailProperty
        {
            get { return email; }
            set
            {
                this.email = value;
                OnPropertyChanged("emailProperty");
            }
        }
        public String mdpProperty
        {
            get { return mdp; }
            set
            {
                this.mdp = value;
                OnPropertyChanged("mdpProperty");
            }
        }
        public RoleViewModel rolePersonneProperty
        {
            get { return idRolePersonne; }
            set
            {
                this.idRolePersonne = value;
                OnPropertyChanged("rolePersonneProperty");
            }
        }
        public EquipeViewModel equipePersonneProperty
        {
            get { return idEquipePersonne; }
            set
            {
                this.idEquipePersonne = value;
                OnPropertyChanged("equipePersonneProperty");
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

