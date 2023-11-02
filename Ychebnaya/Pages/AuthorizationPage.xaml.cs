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
using Ychebnaya.DB;

namespace Ychebnaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static List<Employee> employee = new List<Employee>(); 
        public AuthorizationPage()
        {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e)
        {
            if (loginTb.Text.Length == 0)
            {
                MessageBox.Show("Введите логин");
            }
            else
            {
                int login = Convert.ToInt32(loginTb.Text);
                string password = passwordTb.Password.Trim();
                employee = new List<Employee>(DBConnection.ychebnayaEntities.Employee.ToList());
                Employee employee2 = employee.FirstOrDefault(i => i.Id == login && i.Password == password);
                if (employee2 != null)
                {
                    NavigationService.Navigate(new ExamPage());
                    MessageBox.Show($"Добро пожаловать {employee2.Surname}");
                }
                else
                {
                    MessageBox.Show("Что-то введено не верно,выполините вход через гостя");
                }
            }
        }

        private void Guest_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DisciplinePage());
        }
    }
    }
