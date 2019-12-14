using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    class ComptageViewModel
    {
        
        private int idZoneComptage;
        private int idEspeceComptage;
        private string populationComptage;
        
        

        public ComptageViewModel() { }

        public ComptageViewModel(int id, int Zone_idEtude, int Espece_idEspece, string population)
        {
            this.idZoneComptage = Zone_idEtude;
            this.idEspeceComptage = Espece_idEspece;
            this.populationComptage = population;
            
        }
        public int idZoneComptageProperty
        {
            get { return idZoneComptage; }
        }

        public int idEspeceComptageProperty
        {
            get { return idEspeceComptage; }
            

        }
        public String populationComptageProperty
        {
            get { return populationComptage; }
            set
            {
                this.populationComptage = value;
                OnPropertyChanged("populationComptageProperty");
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
                ComptageORM.updateComptage(this);
            }
        }
    }
}

