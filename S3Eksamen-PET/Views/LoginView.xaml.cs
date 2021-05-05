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
using System.Windows.Shapes;
using S3Eksamen_PET.ViewModel;

namespace S3Eksamen_PET.Views
{
    /// <summary>
    /// Interaction logic for LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        private UserViewModel view;

        public LoginView()
        {
            InitializeComponent();

            view = new UserViewModel();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (view.Login(txtUsername.Text, txtPassword.Password))
            {
                MainWindow mainWindow = new MainWindow(view);
                App.Current.MainWindow = mainWindow;

                this.Close();
                mainWindow.Show();
            }
            else
            {
                lblError.Visibility = Visibility.Visible;
            }

        }

        private void btnGuestLogin_Click(object sender, RoutedEventArgs e)
        {
            view.GuestLogin();

            MainWindow mainWindow = new MainWindow(view);
            App.Current.MainWindow = mainWindow;

            this.Close();
            mainWindow.Show();
        }
    }
}
