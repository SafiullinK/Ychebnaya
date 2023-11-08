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
    /// Логика взаимодействия для IngenerPage.xaml
    /// </summary>
    public partial class IngenerPage : Page
    {
        public static List<Employee> employees = new List<Employee>();
        public static Employee emp { get; set; }
        public IngenerPage()
        {
            InitializeComponent();
            employees = new List<Employee>(DBConnection.ychebnayaEntities.Employee.ToList().Where(x => x.Doljnost != "инженер"));
            this.DataContext = this;
            DisciplinaLv.ItemsSource = employees.ToList();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void DisciplinaLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           emp = DisciplinaLv.SelectedItem as Employee;
            NavigationService.Navigate(new EmployeeRedactPage());
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            int zarp;
            if(EmployeeName.Text.Trim().Length == 0 || DoljnostTb.Text.Trim().Length == 0 || ZarplataTb.Text.Trim().Length == 0 || PasswordTb.Text.Trim().Length == 0 || !int.TryParse(ZarplataTb.Text, out zarp))
            {
                MessageBox.Show("Заполните все поля правильно");
            }
            else
            {
                Employee emp = new Employee
                {
                    Surname = EmployeeName.Text,
                    Doljnost = DoljnostTb.Text,
                    Zarplata = zarp,
                    Password = PasswordTb.Text.Trim()
                };
                DBConnection.ychebnayaEntities.Employee.Add(emp);
                DBConnection.ychebnayaEntities.SaveChanges();
                DisciplinaLv.ItemsSource = new List<Employee>(DBConnection.ychebnayaEntities.Employee.ToList().Where(x => x.Doljnost != "инженер"));
            }
        }
    }
}
