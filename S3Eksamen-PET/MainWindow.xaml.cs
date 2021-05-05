using System;
using System.Collections.Generic;
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

namespace S3Eksamen_PET
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public UserModel CurrentUser;

        /// <summary>        
        /// Initializes the main window with the logged in user
        /// </summary>
        /// <param name="userViewModel">The current ViewModel for the logged in user</param>
        public MainWindow(UserViewModel userViewModel)
        {
            InitializeComponent();

            CurrentUser = userViewModel.CurrentUser;

            this.Title = $"PET | Logget ind som {CurrentUser.Username} ({CurrentUser.Person.Name})";
        }
    }
}
