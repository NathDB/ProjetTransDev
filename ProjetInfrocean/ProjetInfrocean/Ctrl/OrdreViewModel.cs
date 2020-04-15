using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class OrdreViewModel : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private int idClasseOrdre;
     

        public OrdreViewModel()
        {

        }
        public OrdreViewModel(int id, string nom, int idClasseOrdre)
        {
            this.id = id;
            this.nomProperty = nom;
            this.idClassOrdreProperty = idClasseOrdre;
        }

        public int idProperty
        {
            get { return id; }
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
        
        public string idClassOrdreProperty
        {
            get { return idClasseOrdre; }
            set
            {
                idClasseOrdre = value;
                OnPropertyChanged("idClassOrdreProperty");
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
                OrdreORM.updateOrdre(this);
            }
        }
    }

    
}
