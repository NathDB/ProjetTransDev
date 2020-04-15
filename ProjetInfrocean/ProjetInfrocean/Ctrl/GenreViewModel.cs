using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class GenreViewModel : INotifyPropertyChanged
    {
        private int id;
        private string nom;
     

        public GenreViewModel()
        {

        }
        public GenreViewModel(int id, string nom)
        {
            this.id = id;
            this.nomProperty = nom;
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
                GenreORM.updateGenre(this);
            }
        }
    }

    
}
