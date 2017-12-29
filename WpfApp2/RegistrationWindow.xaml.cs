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
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connection = @"server=localhost;database=hospital;uid=root;password=1234";
            string userLogin= user_login.Text;
            string userPassword = user_pwd.Password.ToString();
            int user_status = 0;

            MySqlConnection mySql = new MySqlConnection(connection);
            string insertUserCommand = "insert into log_pass(login, " +
                "password, user_status) " +
                "values" +
                "('" + userLogin +
                "','" + userPassword + "','" + user_status + "');";
            MySqlCommand command = new MySqlCommand(insertUserCommand, mySql);

            try
            {
                if (mySql.State == System.Data.ConnectionState.Closed) {
                    mySql.Open();
                }
                
                //command.ExecuteReader();
                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0)
                {
                    MessageBox.Show("Регистрация прошла успешно!");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally {
                mySql.Close();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
