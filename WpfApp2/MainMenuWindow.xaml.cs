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
using MySql.Data;
using MySql.Data.MySqlClient;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainMenuWindow.xaml
    /// </summary>
    public partial class MainMenuWindow : Window
    {


        public MainMenuWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void saveButton(object sender, RoutedEventArgs e)
        {
            string connection = @"server=localhost;database=hospital;uid=root;password=1234";
            string firstName = fName.Text;
            string secondName = sName.Text;
            string lastName = lName.Text;
            string illnessName = illness.Text;
            string date = birth.Text;
            string addresS = address.Text;
            int status_id = 1;

            MySqlConnection mySql = new MySqlConnection(connection);
            string insertUserCommand = "insert into info_patients(firstName, " +
                "secondName, lastName, illnessName, birthDate, address) " +
                "values" +
                "('" + firstName +
                "','" + secondName + "','" + lastName + "','" + illnessName + "','" + date + "','" + addresS + "');";

            string updateCommand = " ";
            MySqlCommand command = new MySqlCommand(insertUserCommand, mySql);

            try
            {
                if (mySql.State == System.Data.ConnectionState.Closed)
                {
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
            finally
            {
                mySql.Close();
            }
        }
    }
    
}
