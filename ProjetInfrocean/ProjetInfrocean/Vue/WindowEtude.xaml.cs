using ProjetInfrocean.Ctrl;
using ProjetInfrocean.DAL;
using ProjetInfrocean.ORM;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProjetInfrocean.Vue
{
    /// <summary>
    /// Logique d'interaction pour WindowEtude.xaml
    /// </summary>
    public partial class WindowEtude : Window
    {
        int selectedEtudeId;

        EtudeViewModel myDataObjectEtude; // Objet de liaison

        ObservableCollection<EtudeViewModel> le;
        ObservableCollection<EtudeViewModel> lEtudePlage;
        
        public WindowEtude()
        {
            InitializeComponent();
            DalConnexion.OpenConnection();

            le = EtudeORM.listeEtudes();
            lEtudePlage = EtudeORM.requeteEtudePlage();

            //Conversion dateTime
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "yyyy-MM-dd";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;

            listeEtudes.ItemsSource = le;
            //listeEtudePlage.ItemsSource = lEtudePlage;
            //choixEtudes.ItemsSource = le;



            // Automatically resize height and width relative to content
            this.SizeToContent = SizeToContent.WidthAndHeight;
        }
        //LISTE
        private void listeEtudes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((listeEtudes.SelectedIndex < le.Count) && (listeEtudes.SelectedIndex >= 0))
            {
                selectedEtudeId = (le.ElementAt<EtudeViewModel>(listeEtudes.SelectedIndex)).idEtudeProperty;
            }
        }
        //AJOUTER
        private void ajoutEtudeButton_Click(object sender, RoutedEventArgs e)
        {
            myDataObjectEtude = new EtudeViewModel();
            myDataObjectEtude.titreEtudeProperty = titre.Text;
            myDataObjectEtude.dateCreationEtudeProperty = (DateTime)dateCrea.SelectedDate;
            myDataObjectEtude.dateFinEtudeProperty = (DateTime)dateFin.SelectedDate;


            EtudeViewModel nouveau = new EtudeViewModel(+1, myDataObjectEtude.titreEtudeProperty, myDataObjectEtude.dateCreationEtudeProperty, myDataObjectEtude.dateFinEtudeProperty);
            le.Add(nouveau);
            EtudeORM.insertEtude(nouveau);
            listeEtudes.Items.Refresh();
            MessageBox.Show("==>insert");
        }
        //SUPPRIMER
        private void supprimerEtudeButton_Click(object sender, RoutedEventArgs e)
        {
            EtudeViewModel toRemove = (EtudeViewModel)listeEtudes.SelectedItem;
            le.Remove(toRemove);
            listeEtudes.Items.Refresh();
            EtudeORM.supprimerEtude(selectedEtudeId);
        }

        //Retour Menu
        private void openMainWindow(object sender, RoutedEventArgs e)
        {
            MainWindow objet = new MainWindow();
            this.Visibility = Visibility.Hidden;
            objet.Show();
        }

    }
}
