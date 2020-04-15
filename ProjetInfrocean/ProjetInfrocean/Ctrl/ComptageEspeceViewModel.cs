using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetInfrocean.Ctrl
{
    public class ComptageEspeceViewModel
    {
        private int idComptageEspece;
        private ComptageViewModel idComptage;
        private EspeceViewModel idEspece;
        private int quantite;

        public ComptageEspeceViewModel() { }

        public ComptageEspeceViewModel(int idComptageEspece, ComptageViewModel idComptageProperty, EspeceViewModel idEspeceProperty, int quantite)
        {
            this.idComptageEspece = idComptageEspece;
            this.idComptage = idComptageProperty;
            this.idEspece = idEspeceProperty;
            this.quantiteProperty = quantite;
            
        }
        public int idComptageEspeceProperty
        {
            get { return idComptageEspece; }
        }

        public ComptageViewModel idComptageProperty
        {
            get { return idComptage; }
        }

        public EspeceViewModel idEspeceProperty
        {
            get { return idEspece; }
            

        }
        public int quantiteProperty
        {
            get { return quantite; }
            set
            {
                this.quantite = value;
                OnPropertyChanged("quantite");
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
                ComptageEspeceORM.updateComptage(this);
            }
        }
    }
}

