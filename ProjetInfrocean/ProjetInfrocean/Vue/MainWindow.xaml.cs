using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Linq;
using System.Windows.Media;
using System.Collections.ObjectModel;
using ProjetInfrocean.DAL;
using ProjetInfrocean.ORM;
using ProjetInfrocean.Ctrl;

namespace ProjetInfrocean
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int selectedPersonneId;
        int selectedEtudeId;
        int selectedPlageId;

        PersonneViewModel myDataObjectPersonne; // Objet de liaison
        EtudeViewModel myDataObjectEtude; // Objet de liaison
        PlageViewModel myDataObjectPlage; // Objet de liaison

        ObservableCollection<PersonneViewModel> lp;
        ObservableCollection<EtudeViewModel> le;
        ObservableCollection<PlageViewModel> lpl;

        int compteur = 0;

        public MainWindow()
        {
            InitializeComponent();
            DalConnexion.OpenConnection();

            //CREATION DE LA LISTE A PARTIR DE LA BDD VIA LE FICHIER ORM
            lp = PersonneORM.listePersonnes();
            le = EtudeORM.listeEtudes();
            lpl = PlageORM.listePlages();

            //LIEN AVEC la VIEW
            listePersonnes.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            listeEtudes.ItemsSource = le;
            listePlages.ItemsSource = lpl;
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }
        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObjectPersonne.prenomPersonneProperty = prenom.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObjectPersonne.nomPersonneProperty = nom.Text;
        }
        public void titreChanged(object sender, TextChangedEventArgs e)
        {
            myDataObjectEtude.titreEtudeProperty = titre.Text;
        }

        //UPDATE
        private void updatePersonneButton_DoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObjectPersonne = new PersonneViewModel();
            myDataObjectPersonne.nomPersonneProperty = nom.Text;
            myDataObjectPersonne.prenomPersonneProperty = prenom.Text;


            PersonneViewModel nouveau = new PersonneViewModel(+1, myDataObjectPersonne.nomPersonneProperty, myDataObjectPersonne.prenomPersonneProperty, myDataObjectPersonne.etudePersonneProperty, myDataObjectPersonne.isAdminPersonneProperty);
            lp.Add(nouveau);
            PersonneORM.updatePersonne(nouveau);
            listePersonnes.Items.Refresh();
            MessageBox.Show("==>update");

        }

        //FONCTIONS SUPPRIMER AU DOUBLE CLICK
        private void supprimerPersonneButton_Click(object sender, RoutedEventArgs e)
        {
            PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
            lp.Remove(toRemove);
            listePersonnes.Items.Refresh();
            PersonneORM.supprimerPersonne(selectedPersonneId);
        }
        private void supprimerPlageButton_Click(object sender, RoutedEventArgs e)
        {
            PlageViewModel toRemove = (PlageViewModel)listePlages.SelectedItem;
            lpl.Remove(toRemove);
            listePlages.Items.Refresh();
            PlageORM.supprimerPlage(selectedPlageId);
        }
        private void supprimerEtudeButton_Click(object sender, RoutedEventArgs e)
        {
            EtudeViewModel toRemove = (EtudeViewModel)listeEtudes.SelectedItem;
            le.Remove(toRemove);
            listeEtudes.Items.Refresh();
            EtudeORM.supprimerEtude(selectedEtudeId);
        }

        
        //FONCTIONS LISTES DES DONNEES
        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < lp.Count) && (listePersonnes.SelectedIndex >= 0))
            {
                selectedPersonneId = (lp.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idPersonneProperty;
            }
        }
        private void listeEtudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtudes.SelectedIndex < lp.Count) && (listeEtudes.SelectedIndex >= 0))
            {
                selectedEtudeId = (le.ElementAt<EtudeViewModel>(listeEtudes.SelectedIndex)).idEtudeProperty;
            }
        }
        private void listePlages_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePlages.SelectedIndex < lp.Count) && (listePlages.SelectedIndex >= 0))
            {
                selectedPlageId = (lpl.ElementAt<PlageViewModel>(listePlages.SelectedIndex)).idPlageProperty;
            }
        }

        //FONCTIONS AJOUTER AU CLICK
        private void ajoutPersonneButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectPersonne = new PersonneViewModel();
            myDataObjectPersonne.nomPersonneProperty = nom.Text;
            myDataObjectPersonne.prenomPersonneProperty = prenom.Text;

           
            PersonneViewModel nouveau = new PersonneViewModel(+1, myDataObjectPersonne.nomPersonneProperty, myDataObjectPersonne.prenomPersonneProperty, myDataObjectPersonne.etudePersonneProperty, myDataObjectPersonne.isAdminPersonneProperty);
            lp.Add(nouveau);
            PersonneORM.insertPersonne(nouveau);
            listePersonnes.Items.Refresh();
            MessageBox.Show("==>insert");
        }
        private void ajoutEtudeButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectEtude = new EtudeViewModel();
            myDataObjectEtude.titreEtudeProperty = titre.Text;
            myDataObjectEtude.dateCreationEtudeProperty = dateCrea.Text;
            myDataObjectEtude.dateFinEtudeProperty = dateFin.Text;


            EtudeViewModel nouveau = new EtudeViewModel(+1, myDataObjectEtude.titreEtudeProperty, myDataObjectEtude.dateCreationEtudeProperty, myDataObjectEtude.dateFinEtudeProperty);
            le.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            listeEtudes.Items.Refresh();
            MessageBox.Show("==>insert");
        }
        private void ajoutPlageButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectPlage = new PlageViewModel();
            myDataObjectPlage.nomPlageProperty = nomPlage.Text;
            myDataObjectPlage.departementPlageProperty = departement.Text;

            PlageViewModel nouveau = new PlageViewModel(+1, myDataObjectPlage.nomPlageProperty, myDataObjectPlage.departementPlageProperty, myDataObjectPlage.communePlageProperty);
            lpl.Add(nouveau);
            PlageORM.insertPlage(nouveau);
            listePlages.Items.Refresh();
            MessageBox.Show("==>insert");
        }

    }
}
