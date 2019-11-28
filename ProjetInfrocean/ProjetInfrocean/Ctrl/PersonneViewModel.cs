using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    class PersonneViewModel
    {
        
        private int idPersonne;
        private string nomPersonne;
        private string prenomPersonne;
        //private string concat;
        

        public PersonneViewModel() { }

        public PersonneViewModel(int id, string nom, string prenom)
        {
            this.idPersonne = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            
        }
        public int idPersonneProperty
        {
            get { return idPersonne; }
        }

        public String nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value.ToUpper();
                //this.concatProperty = value.ToUpper() + " " + prenomPersonne;
                OnPropertyChanged("nomPersonneProperty");
            }

        }
        public String prenomPersonneProperty
        {
            get { return prenomPersonne; }
            set
            {
                this.prenomPersonne = value;
                this.concatProperty = this.nomPersonne + " " + value;
                OnPropertyChanged("prenomPersonneProperty");
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

