using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserGUI
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {

        private DateTime previousSelectedDate;

        public SignUp()
        {
            InitializeComponent();
            previousSelectedDate = birthdateDatePicker.SelectedDate ?? DateTime.MinValue;
        }


        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtEmail.Focus();
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text) && txtEmail.Text.Length > 0)
            {
                textEmail.Visibility = Visibility.Collapsed;
            }
            else
            {
                textEmail.Visibility = Visibility.Visible;
            }
        }

        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Password) && txtPassword.Password.Length > 0)
            {
                textPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                textPassword.Visibility = Visibility.Visible;
            }
        }





        private void textUserName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textUserName.Focus();
        }

        private void txtUserName_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textUserName.Text) && textUserName.Text.Length > 0)
            {
                textUserName.Visibility = Visibility.Collapsed;
            }
            else
            {
                textUserName.Visibility = Visibility.Visible;
            }
        }

        private void textFirstName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textFirstName.Focus();
        }

        private void txtFirstName_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textFirstName.Text) && textFirstName.Text.Length > 0)
            {
                textFirstName.Visibility = Visibility.Collapsed;
            }
            else
            {
                textFirstName.Visibility = Visibility.Visible;
            }
        }

        private void textSecondName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textSecondName.Focus();
        }

        private void txtSecondName_TextChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(textSecondName.Text) && textSecondName.Text.Length > 0)
            {
                textSecondName.Visibility = Visibility.Collapsed;
            }
            else
            {
                textSecondName.Visibility = Visibility.Visible;
            }
        }

        private void textBirthDate_MouseDown(object sender, MouseButtonEventArgs e)
        {
            textBirthDate.Focus();
        }

        private void signUpButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

    }
}
