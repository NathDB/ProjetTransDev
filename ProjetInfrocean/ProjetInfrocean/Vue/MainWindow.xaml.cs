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
        PersonneViewModel myDataObject; // Objet de liaison
        ObservableCollection<PersonneViewModel> lp;

        int compteur = 0;

        public MainWindow()
        {
            InitializeComponent();
            DalConnexion.OpenConnection();

            // Initialisation de la liste des personnes via la BDD.
            lp = PersonneORM.listePersonnes();

            //LIEN AVEC la VIEW
            listePersonnes.ItemsSource = lp; // bind de la liste avec la source, permettant le binding.
            // this.DataContext = lp; // bind de la liste avec la source, permettant le binding mais de façon globale sur toute la fenetre
        }
        public void prenomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.prenomPersonneProperty = prenomTextBox.Text;
        }
        public void nomChanged(object sender, TextChangedEventArgs e)
        {
            myDataObject.nomPersonneProperty = nomTextBox.Text;
        }

        private void nomPrenomButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            myDataObject = new PersonneViewModel();
            myDataObject.prenomPersonneProperty = prenomTextBox.Text;
            myDataObject.nomPersonneProperty = nomTextBox.Text;
            PersonneViewModel nouveau = new PersonneViewModel(PersonneDAL.getMaxIdPersonne() + 1, myDataObject.nomPersonneProperty, myDataObject.prenomPersonneProperty);
            lp.Add(nouveau);
            PersonneORM.insertPersonne(nouveau);
            listePersonnes.Items.Refresh();
            compteur = lp.Count();
        }
        private void supprimerButton_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            PersonneViewModel toRemove = (PersonneViewModel)listePersonnes.SelectedItem;
            lp.Remove(toRemove);
            listePersonnes.Items.Refresh();
            PersonneORM.supprimerPersonne(selectedPersonneId);
        }
        private void VClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Blue !");
        }
        private void RClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Red !");
        }
        private void BClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Blue !");
        }

        private void listePersonnes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listePersonnes.SelectedIndex < lp.Count) && (listePersonnes.SelectedIndex >= 0))
            {
                selectedPersonneId = (lp.ElementAt<PersonneViewModel>(listePersonnes.SelectedIndex)).idPersonneProperty;
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            grigrid.Height = sliderHeight.Value + 200;
        }
    }
}
