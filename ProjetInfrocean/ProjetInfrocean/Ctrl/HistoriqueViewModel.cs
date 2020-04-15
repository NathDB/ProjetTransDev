using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class HistoriqueViewModel : INotifyPropertyChanged
    {
        private int idHistorique;
        private DateTime dateCrea;
        private DateTime dateFin;
        private int idSaisonHistorique;
        private int idEtudeHistorique;
     

        public HistoriqueViewModel()
        {

        }
        public HistoriqueViewModel(int idHistorique, DateTime dateCrea, DateTime dateFin, int idSaisonHistorique, int idEtudeHistorique)
        {
            this.idHistorique = idHistorique;
            this.dateCreaProperty = dateCrea;
            this.dateFinProperty = dateFin;
            this.idSaisonHistorique = idSaisonHistorique;
            this.idEtudeHistorique = idEtudeHistorique;
        }

        public int idHistoriqueProperty
        {
            get { return idHistorique; }
        }
        public DateTime dateCreaProperty
        {
            get { return dateCrea; }
            set
            {
                dateCrea = value;
                OnPropertyChanged("dateCreaProperty");
            }
        }
        public DateTime dateFinProperty
        {
            get { return dateFin; }
            set
            {
                dateFin = value;
                OnPropertyChanged("dateFinProperty");
            }
        }

        public int idSaisonHistoriqueProperty
        {
            get { return idSaisonHistorique; }
            set
            {
                idSaisonHistorique = value;
                OnPropertyChanged("idSaisonHistoriqueProperty");
            }
        }
        public int idEtudeHistoriqueProperty
        {
            get { return idEtudeHistorique; }
            set
            {
                idEtudeHistorique = value;
                OnPropertyChanged("idEtudeHistoriqueProperty");
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
                HistoriqueORM.updateHistorique(this);
            }
        }
    }

    
}
