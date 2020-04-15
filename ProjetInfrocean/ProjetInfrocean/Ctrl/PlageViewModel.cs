using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class PlageViewModel
    {
        
        private int idPlage;
        private string nom;
        private int idCommunePlage;
        private decimal superficiePlage;

        //private string concat;

        public PlageViewModel() { }

        public PlageViewModel(int id, string nom, int idCommunePlage, decimal superficiePlage)
        {
            this.idPlage = id;
            this.nomProperty = nom;
            this.idCommunePlageProperty = idCommunePlage;
            this.superficiePlageProperty = superficiePlage;
            
        }
        public int idPlageProperty
        {
            get { return idPlage; }
        }

        public String nomProperty
        {
            get { return nom; }
            set
            {
                nom = value;
                OnPropertyChanged("nomProperty");
            }

        }
        public int idCommunePlageProperty
        {
            get { return idCommunePlage; }
            set
            {
                this.idCommunePlage = value;
                OnPropertyChanged("idCommunePlageProperty");
            }
        }
        public decimal superficiePlageProperty
        {
            get { return superficiePlage; }
            set
            {
                this.superficiePlage = value;
                this.concatProperty = this.superficiePlage + " " + 1;
                OnPropertyChanged("superficiePlageProperty");
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
                PlageORM.updatePlage(this);
            }
        }
    }
}

