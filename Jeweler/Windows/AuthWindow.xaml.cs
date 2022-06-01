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
using Jeweler.EF;
using Jeweler.ClassHelper;

namespace Jeweler.Windows
{
    /// <summary>
    /// Логика взаимодействия для AuthWindow.xaml
    /// </summary>
    public partial class AuthWindow : Window
    {
        public AuthWindow()
        {
            InitializeComponent();
            txtLogin.Focus();
        }

        string GetCapcha()
        {
            Random random = new Random();
            string str = string.Empty;
            string getStr = string.Empty;
            str = "1234567890";
            for (int i = 65; i < 91; i++)
            {
                str += (char)i;
            }


            for (int i = 0; i < 5; i++)
            {
                getStr += str[random.Next(36)];
            }
            return getStr;
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            tbCapcha.Text = GetCapcha();
        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (UserSearch.GetUser(txtLogin.Text, txtPassword.Text) || UserSearch.GetUser(txtLogin.Text, txtPassword.Text) && txtCapcha.Text == GetCapcha())
                {
                    MainWindow adminWindow = new MainWindow();
                    this.Hide();
                    adminWindow.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show("Пользователя с такими данными не существует");
                    tbTitleCapcha.Visibility = Visibility.Visible;
                    txtCapcha.Visibility = Visibility.Visible;
                    tbCapcha.Visibility = Visibility.Visible;
                    btnUpdate.Visibility = Visibility.Visible;
                    tbCapcha.Text = GetCapcha();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAuthGuest_Click(object sender, RoutedEventArgs e)
        {
            ClientAndManagerWindow clientAndManagerWindow = new ClientAndManagerWindow();
            this.Hide();
            clientAndManagerWindow.ShowDialog();
            this.Show();
        }
    }
}

