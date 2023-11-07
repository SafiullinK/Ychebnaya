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
        private object selectedItem;

        public static List<Student> students = new List<Student> {};
        public StudentsPage(Exam exam)
        {
            InitializeComponent();
            students = StudentFunction.GetStudents().ToList();
            students = students.Where(x => exam.id_student == x.ID).ToList();
            this.DataContext = this;
            StudentLv.ItemsSource = students;
            


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
