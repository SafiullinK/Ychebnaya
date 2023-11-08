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
            DisciplineNameTb.Text = ExamPage.exam.Disciplina.Name;
            DisciplineDateTb.Text = ExamPage.exam.date.ToString().Split(' ')[0];
            students = StudentFunction.GetStudents().ToList();
            exams = new List<Exam>(DBConnection.ychebnayaEntities.Exam.ToList().Where(x => x.date == ExamPage.exam.date && x.Disciplina == exam.Disciplina));
            this.DataContext = this;
            StudentLv.ItemsSource = exams;
            StudentCb.ItemsSource = students;
            StudentCb.DisplayMemberPath = "ID";
            


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
            if (StudentCb.SelectedItem == null)
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                Exam exam = new Exam
                {
                    date = ExamPage.exam.date,
                    id_prepod = ExamPage.exam.id_prepod,
                    id_discipline = ExamPage.exam.id_discipline,
                    auditoriya = ExamPage.exam.auditoriya,
                    id_student = (StudentCb.SelectedItem as Student).ID
                };

                DBConnection.ychebnayaEntities.Exam.Add(exam);
                DBConnection.ychebnayaEntities.SaveChanges();

                MessageBox.Show("Данные записаны!");

                StudentLv.ItemsSource = new List<Exam>(DBConnection.ychebnayaEntities.Exam.ToList().Where(x => x.date == ExamPage.exam.date && x.Disciplina == ExamPage.exam.Disciplina));

                StudentCb.SelectedItem = null;
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (StudentLv.SelectedItem != null)
            {
                DBConnection.ychebnayaEntities.Exam.Remove(StudentLv.SelectedItem as Exam);
                DBConnection.ychebnayaEntities.SaveChanges();

                MessageBox.Show("Данные удалены!");

                StudentLv.ItemsSource = new List<Exam>(DBConnection.ychebnayaEntities.Exam.ToList().Where(x => x.date == ExamPage.exam.date && x.Disciplina == ExamPage.exam.Disciplina));
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления!");
            }
        }
    }
}
