﻿using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    class PlageViewModel
    {
        
        private int idPlage;
        private string nomPlage;
        private string departementPlage;
        private int communePlage;

        //private string concat;
        

        public PersonneViewModel() { }

        public PersonneViewModel(int id, string nom, string prenom, int Etude_idEtude, int isAdmin)
        {
            this.idPersonne = id;
            this.nomPersonneProperty = nom;
            this.prenomPersonneProperty = prenom;
            this.etudePersonneProperty = Etude_idEtude;
            this.isAdminPersonneProperty = isAdmin;
            
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
        public int etudePersonneProperty
        {
            get { return etudePersonne; }
            set
            {
                this.etudePersonne = 1;
                this.concatProperty = this.etudePersonne + " " + 1;
                OnPropertyChanged("etudePersonneProperty");
            }
        }
        public int isAdminPersonneProperty
        {
            get { return isAdminPersonne; }
            set
            {
                this.isAdminPersonne = 0;
                this.concatProperty = this.isAdminPersonne + " " + 0;
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

