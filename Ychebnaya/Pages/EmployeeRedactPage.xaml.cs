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
    /// Логика взаимодействия для EmployeeRedactPage.xaml
    /// </summary>
    public partial class EmployeeRedactPage : Page
    {
        public static List<Employee> employees = new List<Employee>();
        public EmployeeRedactPage()
        {
            InitializeComponent();
            employees = new List<Employee>(DBConnection.ychebnayaEntities.Employee.ToList().Where(x => x.Id == IngenerPage.emp.Id));
            DisciplinaLv.ItemsSource = employees.ToList();
            EmpnameTb.Text = IngenerPage.emp.Surname;
            DoljnostTb.Text = IngenerPage.emp.Doljnost;
            ZarplataTb.Text = Convert.ToString(IngenerPage.emp.Zarplata);
            PasswordTb.Text = IngenerPage.emp.Password;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();

        }

        private void RedactBt_Click(object sender, RoutedEventArgs e)
        {
            if (EmpnameTb.Text.Length == 0 || DoljnostTb.Text.Length == 0 || ZarplataTb.Text.Length == 0 || PasswordTb.Text.Length == 0)
            {
                MessageBox.Show("Заполните данные");
            }
            else
            {
                Employee emp = ((Employee)IngenerPage.emp);
                emp = DBConnection.ychebnayaEntities.Employee.Where(x => x.Id == IngenerPage.emp.Id).First();
                emp.Surname = EmpnameTb.Text;
                emp.Doljnost = DoljnostTb.Text;
                emp.Zarplata = Convert.ToInt32(ZarplataTb.Text);
                emp.Password = PasswordTb.Text;
                DBConnection.ychebnayaEntities.SaveChanges();
                MessageBox.Show("Успешно");
                DisciplinaLv.ItemsSource = new List<Employee>(DBConnection.ychebnayaEntities.Employee.ToList().Where(x => x.Id == IngenerPage.emp.Id));
            }
        }

        private void DeleteBt_Click(object sender, RoutedEventArgs e)
        {
            //if (DisciplinaLv.SelectedItem != null)
            //{
            //    DBConnection.ychebnayaEntities.Disciplina.Remove(DisciplinaLv.SelectedItem as Disciplina);
            //    DBConnection.ychebnayaEntities.SaveChanges();
            //    MessageBox.Show("Данные удалены!");

            //    DisciplinaLv.ItemsSource = new List<Disciplina>(DBConnection.ychebnayaEntities.Disciplina.ToList().Where(x => x.Ispolnitel == DepartmentPage.kaf.Kafedra_id));
            //}
            DBConnection.ychebnayaEntities.Employee.Remove(IngenerPage.emp as Employee);
            DBConnection.ychebnayaEntities.SaveChanges();
            MessageBox.Show("Данные удалены!");
            DisciplinaLv.ItemsSource = new List<Employee>(DBConnection.ychebnayaEntities.Employee.ToList().Where(x => x.Id == IngenerPage.emp.Id));
        }

        private void DisciplinaLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
