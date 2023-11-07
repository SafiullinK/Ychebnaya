using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using Ychebnaya.Function;

namespace Ychebnaya.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExamPage.xaml
    /// </summary>
    public partial class ExamPage : Page
    {
        public static ObservableCollection<Exam> examList { get; set; }
        public static List<Employee> employees { get; set; }
        public static List<Prepod> prepods = new List<Prepod>();
        public ExamPage(Employee employee2)
        {
            InitializeComponent();
            prepods = new List<Prepod>(DBConnection.ychebnayaEntities.Prepod.ToList().Where(x => x.Id_Employee == employee2.Id));
            this.DataContext = this;
            examList = ExamFunction.GetExam();
            Prepod.Text = employee2.Surname;
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void DisciplinaLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new StudentsPage((Exam)DisciplinaLv.SelectedItem));
        }
    }
}
