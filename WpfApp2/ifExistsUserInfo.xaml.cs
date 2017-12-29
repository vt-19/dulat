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
    /// Interaction logic for ifExistsUserInfo.xaml
    /// </summary>
    public partial class ifExistsUserInfo : Window
    {
        public ifExistsUserInfo()
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
           

            MySqlConnection mySql = new MySqlConnection(connection);
            string insertUserCommand = "insert into info_patients(firstName, " +
                "secondName, lastName, illnessName, birthDate, address) " +
                "values" +
                "('" + firstName +
                "','" + secondName + "','" + lastName + "','" + illnessName + "','" + date + "','" + addresS + "');";
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
