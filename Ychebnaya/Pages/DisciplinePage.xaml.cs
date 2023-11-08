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
    /// Логика взаимодействия для DisciplinePage.xaml
    /// </summary>
    public partial class DisciplinePage : Page
    {
       public static List<Disciplina> disciplina { get; set; }
        public DisciplinePage()
        {
            InitializeComponent();

            DisciplinaLv.ItemsSource = new List<Disciplina>(DBConnection.ychebnayaEntities.Disciplina.ToList().Where(x => x.Ispolnitel == DepartmentPage.kaf.Kafedra_id));
            this.DataContext = this;
            DepartmentNameTb.Text = DepartmentPage.kaf.Name;
            disciplina = new List<Disciplina>(DBConnection.ychebnayaEntities.Disciplina.ToList());
            DisciplinaCb.ItemsSource = disciplina;
            DisciplinaCb.DisplayMemberPath = "Name";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (DisciplinaLv.SelectedItem != null)
            {
                DBConnection.ychebnayaEntities.Disciplina.Remove(DisciplinaLv.SelectedItem as Disciplina);
                DBConnection.ychebnayaEntities.SaveChanges();
                MessageBox.Show("Данные удалены!");

                DisciplinaLv.ItemsSource = new List<Disciplina>(DBConnection.ychebnayaEntities.Disciplina.ToList());
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            if(DisciplinaCb == null)
            {
                MessageBox.Show("Заполните все поля");
            }
            else
            {
                Disciplina disciplina = new Disciplina
                {
                    
                    Obem = (DisciplinaCb.SelectedItem as Disciplina).Obem,
                    Name = (DisciplinaCb.SelectedItem as Disciplina).Name,
                    Ispolnitel = DepartmentPage.kaf.Kafedra_id

                };
                DBConnection.ychebnayaEntities.Disciplina.Add(disciplina);
                DBConnection.ychebnayaEntities.SaveChanges();
                MessageBox.Show("Данные записаны");
                DisciplinaLv.ItemsSource = new List<Disciplina>(DBConnection.ychebnayaEntities.Disciplina.ToList());
                DisciplinaCb.SelectedItem = null;
            }
        }

        private void DisciplinaLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
