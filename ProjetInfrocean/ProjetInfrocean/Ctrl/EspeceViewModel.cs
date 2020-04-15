using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class EspeceViewModel : INotifyPropertyChanged
    {
        private int idEspece;
        private string nom;
        private int quantite;

        public EspeceViewModel(){}
        public EspeceViewModel(int idEspece, string nom, int quantite)
        {
            this.idEspece = idEspece;
            this.nomProperty = nom;
            this.quantite = quantite;
        }

        public int idEspeceProperty
        {
            get { return idEspece; }
        }
        public string nomProperty
        {
            get { return nom; }
            set
            {
                nom = value;
                OnPropertyChanged("nomProperty");
            }
        }

        public int quantiteProperty
        {
            get { return quantite; }
            set
            {
                quantite = value;
                OnPropertyChanged("quantiteProperty");
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
                EspeceORM.updateEspece(this);
            }
        }
    }

    
}
