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
        private string description;
        private Boolean complete;

        public EquipeViewModel(){}

        public EquipeViewModel(int idEquipe, string nom, string description, Boolean complete)
        {
            this.idEquipe = idEquipe;
            this.nom = nom;
            this.description = description;
            this.complete = complete;
        }

        public int idEquipeProperty
        {
            get { return idEquipe; }
        }        

        public string nomProperty
        {
            get { return nom; }
            set
            {
                nomProperty = value;
                OnPropertyChanged("nomProperty");
            }
        }
        public string descriptionProperty
        {
            get { return description; }
            set
            {
                descriptionProperty = value;
                OnPropertyChanged("descriptionProperty");
            }
        }
        public Boolean completeProperty
        {
            get { return complete; }
            set
            {
                completeProperty = value;
                OnPropertyChanged("completeProperty");
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
