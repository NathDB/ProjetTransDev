using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class EquipeViewModel : INotifyPropertyChanged
    {
        private int idEquipe;
        private string nom;
        private PersonneViewModel idPersonneEquipe;
        private EtudeViewModel idEtudeEquipe;
        private string titreEtude;
        private string nomPersonne;

        public EquipeViewModel(){}

        public EquipeViewModel(int idEquipe, string nom, PersonneViewModel idPersonneProperty, EtudeViewModel idEtudeProperty)
        {
            this.idEquipe = idEquipe;
            this.nom = nom;
            this.idPersonneEquipe = idPersonneProperty;
            this.idEtudeEquipe = idEtudeProperty;
        }
        public EquipeViewModel(int idEquipe, string nom, string titreEtude, string nomPersonne)
        {
            this.idEquipe = idEquipe;
            this.nom = nom;
            this.titreEtude = titreEtude;
            this.nomPersonne = nomPersonne;
        }

        public int idEquipeProperty
        {
            get { return idEquipe; }
        }        

        public string nomEquipeProperty
        {
            get { return nom; }
            set
            {
                nomEquipeProperty = value;
                OnPropertyChanged("nomEquipeProperty");
            }
        }
        public PersonneViewModel idPersonneProperty
        {
            get { return idPersonneEquipe; }
            set
            {
                idPersonneEquipe = value;
                OnPropertyChanged("idPersonneEquipeEquipe");
            }
        }
        
        public EtudeViewModel idEtudeProperty
        {
            get { return idEtudeEquipe; }
            set
            {
                idEtudeEquipe = value;
                OnPropertyChanged("idEtudeEquipeProperty");
            }
        }
        public string nomPersonneProperty
        {
            get { return nomPersonne; }
            set
            {
                nomPersonne = value;
                OnPropertyChanged("titreEtudeProperty");
            }
        }
        public string titreEtudeProperty
        {
            get { return titreEtude; }
            set
            {
                titreEtude = value;
                OnPropertyChanged("titreEtudeProperty");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        public String concatProperty
        {
            get { return ""; }
            set
            {
                //     this.concat = "Ajouter " + value;
            }
        }


        private void OnPropertyChanged(string info)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(info));
                EquipeORM.updateEquipe(this);
            }
        }
    }

    
}
