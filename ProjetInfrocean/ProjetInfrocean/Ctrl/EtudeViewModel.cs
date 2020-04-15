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
        private string titre;
        private Boolean statut;
        private EquipeViewModel idEquipeEtude;

       
        public EtudeViewModel(){}
        public EtudeViewModel(int idEtude, string titre, Boolean statut, EquipeViewModel idEquipeEtude)
        {
            this.idEtude = idEtude;
            this.titreProperty = titre;
            this.statutProperty = statut;
            this.idEquipeEtude = idEquipeEtude;
        }
        public EtudeViewModel(int idEtude, string titre, Boolean statut)
        {
            this.idEtude = idEtude;
            this.titreProperty = titre;
            this.statutProperty = statut;
        }

        public int idEtudeProperty
        {
            get { return idEtude; }
        }

        public string titreProperty
        {
            get { return titre; }
            set
            {
                titre = value;
                OnPropertyChanged("titreProperty");
            }
        }
        public Boolean statutProperty
        {
            get { return statut; }
            set
            {
                statut = value;
                OnPropertyChanged("statutProperty");
            }
        }
        public EquipeViewModel idEquipeEtudeProperty
        {
            get { return idEquipeEtude; }
            set
            {
                idEquipeEtude = value;
                OnPropertyChanged("idEquipeEtudeProperty");
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
