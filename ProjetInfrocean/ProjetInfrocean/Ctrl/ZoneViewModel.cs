using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class ZoneViewModel : INotifyPropertyChanged
    {
        private int idZone;
        private decimal pointALo;
        private decimal pointALa;
        private decimal pointBLo;
        private decimal pointBLa;
        private decimal pointCLo;
        private decimal pointCLa;
        private decimal pointDLo;
        private decimal pointDLa;
        private decimal superficieZone;
        private PlageViewModel idPlageZone;
        private EtudeViewModel idEtudeZone;
        private int idPlage;
        private string nomPlage;
        private string titreEtude;

        public ZoneViewModel(){}
        public ZoneViewModel(int idPlage, string nomPlage, int idZone)
        {
            this.idPlage = idPlage;
            this.nomPlage = nomPlage;
            this.idZone = idZone;

        }
        public ZoneViewModel(int idZone, decimal pointALo, decimal pointALa, decimal pointBLo, decimal pointBLa, decimal pointCLo,
            decimal pointCLa, decimal pointDLo, decimal pointDLa, decimal superficieZone, string nomPlage, string titreEtude)
        {
            this.idZone = idZone;
            this.pointALo = pointALo;
            this.pointALa = pointALa;
            this.pointBLo = pointBLo;
            this.pointBLa = pointBLa;
            this.pointCLo = pointCLo;
            this.pointCLa = pointCLa;
            this.pointDLo = pointDLo;
            this.pointDLa = pointDLa;
            this.superficieZone = superficieZone;
            this.nomPlage = nomPlage;
            this.titreEtude = titreEtude;
        }
        public ZoneViewModel(int idZone, decimal pointALo, decimal pointALa, decimal pointBLo, decimal pointBLa, decimal pointCLo,
            decimal pointCLa, decimal pointDLo, decimal pointDLa, decimal superficieZone, PlageViewModel idPlageProperty, EtudeViewModel idEtudeProperty)
        {
            this.idZone = idZone;
            this.pointALo = pointALo;
            this.pointALa = pointALa;
            this.pointBLo = pointBLo;
            this.pointBLa = pointBLa;
            this.pointCLo = pointCLo;
            this.pointCLa = pointCLa;
            this.pointDLo = pointDLo;
            this.pointDLa = pointDLa;
            this.superficieZone = superficieZone;
            this.idPlageZone = idPlageProperty;
            this.idEtudeZone = idEtudeProperty;   
        }

        public int idZoneProperty
        {
            get { return idZone; }
        }
        public decimal pointALoProperty
        {
            get { return pointALo; }
            set
            {
                pointALo = value;
                OnPropertyChanged("pointALoProperty");
            }
        }
        public decimal pointALaProperty
        {
            get { return pointALa; }
            set
            {
                pointALa = value;
                OnPropertyChanged("pointALaProperty");
            }
        }
        public decimal pointBLoProperty
        {
            get { return pointBLo; }
            set
            {
                pointBLo = value;
                OnPropertyChanged("pointBLoProperty");
            }
        }
        public decimal pointBLaProperty
        {
            get { return pointBLa; }
            set
            {
                pointBLa = value;
                OnPropertyChanged("pointBLaProperty");
            }
        }
        public decimal pointCLoProperty
        {
            get { return pointCLo; }
            set
            {
                pointCLo = value;
                OnPropertyChanged("pointCLoProperty");
            }
        }
        public decimal pointCLaProperty
        {
            get { return pointCLa; }
            set
            {
                pointCLa = value;
                OnPropertyChanged("pointCLaProperty");
            }
        }
        public decimal pointDLoProperty
        {
            get { return pointDLo; }
            set
            {
                pointDLo = value;
                OnPropertyChanged("pointDLoProperty");
            }
        }
        public decimal pointDLaProperty
        {
            get { return pointDLa; }
            set
            {
                pointDLa = value;
                OnPropertyChanged("pointDLaProperty");
            }
        }


        public decimal superficieZoneProperty
        {
            get { return superficieZone; }
            set
            {
                superficieZone = value;
                OnPropertyChanged("superficieZoneProperty");
            }
        }
        public PlageViewModel PlageProperty
        {
            get { return idPlageZone; }
            set
            {
                idPlageZone = value;
                OnPropertyChanged("idPlageZoneProperty");
            }
        }
        
        public EtudeViewModel idEtudeProperty
        {
            get { return idEtudeZone; }
            set
            {
                idEtudeZone = value;
                OnPropertyChanged("idEtudeZoneProperty");
            }
        }
        public string nomPlageProperty
        {
            get { return nomPlage; }
            set
            {
                nomPlage = value;
                OnPropertyChanged("nomPlageProperty");
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
        public int idPlageProperty
        {
            get { return idPlage; }
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
                ZoneORM.updateZone(this);
            }
        }
    }

    
}
