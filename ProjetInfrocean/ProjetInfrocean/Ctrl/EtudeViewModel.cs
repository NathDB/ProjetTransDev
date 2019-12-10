using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class EtudeViewModel : INotifyPropertyChanged
    {
        private int idEtude;
        private string titreEtude;
        private string dateCreationEtude;
        private string dateFinEtude;

        public EtudeViewModel()
        {

        }
        public EtudeViewModel(int idEtude, string titre, string dateCrea, string dateFin)
        {
            this.idEtude = idEtude;
            this.titreEtudeProperty = titre;
            this.dateCreationEtudeProperty = dateCrea;
            this.dateFinEtudeProperty = dateFin;
        }

        public int idEtudeProperty
        {
            get { return idEtude; }
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

        public string dateCreationEtudeProperty
        {
            get { return dateCreationEtude; }
            set
            {
                dateCreationEtude = value;
                OnPropertyChanged("dateCreationEtudeProperty");
            }
        }
        public string dateFinEtudeProperty
        {
            get { return dateFinEtude; }
            set
            {
                dateFinEtude = value;
                OnPropertyChanged("dateFinEtudeProperty");
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
                EtudeORM.updateEtude(this);
            }
        }
    }

    
}
