using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class ComptageViewModel
    {
        private int idComptage;
        private DateTime dateDebut;
        private DateTime dateFin;
        private Boolean statut;
        private ZoneViewModel idZoneComptage;

        public ComptageViewModel() { }

        public ComptageViewModel(int idComptage, DateTime dateDebut, DateTime dateFin, Boolean statut, ZoneViewModel idZoneProperty)
        {
            this.idComptage = idComptage;
            this.dateDebutProperty = dateDebut;
            this.dateFinProperty = dateFin;
            this.statutProperty = statut;
            this.idZoneComptage = idZoneProperty;
            
        }
        public int idComptageProperty
        {
            get { return idComptage; }
        }
        public DateTime dateDebutProperty
        {
            get { return dateDebut; }
            set
            {
                this.dateDebut = value;
                OnPropertyChanged("dateDebutProperty");
            }
        }
        public DateTime dateFinProperty
        {
            get { return dateFin; }
            set
            {
                this.dateFin = value;
                OnPropertyChanged("dateFinProperty");
            }
        }
        public Boolean statutProperty
        {
            get { return statut; }
            set
            {
                this.statut = value;
                OnPropertyChanged("statutProperty");
            }
        }
        public ZoneViewModel idZoneProperty
        {
            get { return idZoneComptage; }
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
                ComptageORM.updateComptage(this);
            }
        }
    }
}

