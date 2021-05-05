using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using S3Eksamen_PET.Models;
using S3Eksamen_PET.ViewModel;

namespace S3Eksamen_PET.Views
{
    /// <summary>
    /// Interaction logic for PersonsView.xaml
    /// </summary>
    public partial class PersonsView : UserControl
    {
        PersonViewModel view;

        ObservableCollection<PersonModel> PersonList;
        PersonModel SelectedUser;

        public PersonsView()
        {
            InitializeComponent();
            
            view = new PersonViewModel();

            LoadData();

            dataPersons.ItemsSource = PersonList;
        }

        public void LoadData()
        {
            PersonList = new ObservableCollection<PersonModel>(view.GetAllPersons());
        }

        private void dataPersons_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedUser = dataPersons.SelectedItem as PersonModel;

        }

        private void btnCreatePerson_Click(object sender, RoutedEventArgs e)
        {
            PersonList.Add(new AgentModel { Id = -1, Name = "Ny bruger" });

            dataPersons.SelectedIndex = PersonList.Count - 1;
        }

        private void btnSavePerson_Click(object sender, RoutedEventArgs e)
        {

            view.SavePerson(SelectedUser);
        }
    }
}
