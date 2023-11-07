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
    /// Логика взаимодействия для StudentsPage.xaml
    /// </summary>
    public partial class StudentsPage : Page
    {
        public static List<Exam> exams { get; set; }

        public static List<Student> students = new List<Student> {};
        public StudentsPage(Exam exam)
        {
            InitializeComponent();
            students = StudentFunction.GetStudents().ToList();
            exams = new List<Exam>(DBConnection.ychebnayaEntities.Exam.ToList().Where(x => x.date == exam.date && x.Disciplina == exam.Disciplina));
            this.DataContext = this;
            StudentLv.ItemsSource = exams;
            


        }

        /*public StudentsPage(object selectedItem)
        {
            this.selectedItem = selectedItem;
        }*/

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DisciplinaLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new StudentAdd());
        }
    }
}
