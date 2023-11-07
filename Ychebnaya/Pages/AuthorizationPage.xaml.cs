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
                if (employee2 != null && employee2.Doljnost == "преподаватель")
                {
                    MessageBox.Show($"Вы входите как {employee2.Surname} ({employee2.Doljnost})!");
                    NavigationService.Navigate(new ExamPage(employee2));
                }
                else if (employee2 != null && employee2.Doljnost == "зав. кафедрой")
                {
                    MessageBox.Show($"Вы входите как {employee2.Surname} ({employee2.Doljnost})!");
                    NavigationService.Navigate(new DepartmentPage());
                }
                else if (employee2 != null && employee2.Doljnost == "инженер")
                {
                    MessageBox.Show($"Вы входите как {employee2.Surname} ({employee2.Doljnost})!");
                    NavigationService.Navigate(new IngenerPage());
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
