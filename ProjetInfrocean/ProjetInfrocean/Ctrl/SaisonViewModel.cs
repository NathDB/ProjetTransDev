using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class SaisonViewModel : INotifyPropertyChanged
    {
        private int id;
        private string saison;
     

        public SaisonViewModel()
        {

        }
        public SaisonViewModel(int id, string saison)
        {
            this.id = id;
            this.saisonProperty = saison;
        }

        public int idProperty
        {
            get { return id; }
        }

        public string saisonProperty
        {
            get { return saison; }
            set
            {
                saison = value;
                OnPropertyChanged("saisonProperty");
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
                SaisonORM.updateSaison(this);
            }
        }
    }

    
}
