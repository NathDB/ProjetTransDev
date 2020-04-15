using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class CommuneViewModel : INotifyPropertyChanged
    {
        private int idCommune;
        private int idDepartement;
        private string codePostal;
        private string nom;
     

        public CommuneViewModel()
        {

        }
        public CommuneViewModel(int idCommune, int idDepartement, string codePostal, string nom)
        {
            this.idCommune = idCommune;
            this.idDepartement = idDepartement;
            this.codePostalProperty = codePostal;
            this.nomProperty = nom;
        }

        public int idCommuneProperty
        {
            get { return idCommune; }
        }
        public int idDepartementProperty
        {
            get { return idDepartement; }
        }

        public string codePostalProperty
        {
            get { return codePostal; }
            set
            {
                codePostal = value;
                OnPropertyChanged("codePostalProperty");
            }
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
                CommuneORM.updateCommune(this);
            }
        }
    }

    
}
