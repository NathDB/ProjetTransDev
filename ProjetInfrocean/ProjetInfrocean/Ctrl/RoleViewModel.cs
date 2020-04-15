using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class RoleViewModel : INotifyPropertyChanged
    {
        private int id;
        private string nom;
        private string description;
     

        public RoleViewModel()
        {

        }
        public RoleViewModel(int id, string nom, string description)
        {
            this.id = id;
            this.nomProperty = nom;
            this.descriptionProperty = description;
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
        
        public string descriptionProperty
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged("descriptionProperty");
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
                RoleORM.updateRole(this);
            }
        }
    }

    
}
