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

                DisciplinaLv.ItemsSource = new List<Disciplina>(DBConnection.ychebnayaEntities.Disciplina.ToList().Where(x => x.Ispolnitel == DepartmentPage.kaf.Kafedra_id));
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            
            int hours;
            if(DisciplinaLv.SelectedItems.Count >= 1)
            {
                if(DisciplinaLv.SelectedItems.Count >1)
                {
                    MessageBox.Show("Выберите только 1 строку для изменения!");
                }
                else
                {
                    if (DisciplinaNameTb.Text.Length < 1 || ObemTb.Text.Length < 1 || !int.TryParse(ObemTb.Text, out hours))
                        MessageBox.Show("Заполните все поля верно!");
                    else
                    {
                        Disciplina dis = ((Disciplina)DisciplinaLv.SelectedItem);
                        dis = DBConnection.ychebnayaEntities.Disciplina.Where(x => x.Ispolnitel == DepartmentPage.kaf.Kafedra_id).First();
                        dis.Name = DisciplinaNameTb.Text;
                        dis.Obem = hours;
                        DBConnection.ychebnayaEntities.SaveChanges();
                        MessageBox.Show("Готово!");
                        DisciplinaLv.ItemsSource = DBConnection.ychebnayaEntities.Disciplina.Where(x => x.Ispolnitel == DepartmentPage.kaf.Kafedra_id).ToList();
                    }
                }
            }
            else
            {
                if (DisciplinaNameTb == null || ObemTb == null)
                {
                    MessageBox.Show("Заполните все поля");
                }
                else
                {
                    Disciplina disciplina = new Disciplina
                    {
                        Obem = Convert.ToInt32(ObemTb.Text.Trim()),
                        Name = DisciplinaNameTb.Text.Trim(),
                        Ispolnitel = DepartmentPage.kaf.Kafedra_id

                    };
                    DBConnection.ychebnayaEntities.Disciplina.Add(disciplina);
                    DBConnection.ychebnayaEntities.SaveChanges();
                    MessageBox.Show("Данные записаны");
                    DisciplinaLv.ItemsSource = new List<Disciplina>(DBConnection.ychebnayaEntities.Disciplina.ToList().Where(x => x.Ispolnitel == DepartmentPage.kaf.Kafedra_id));
                    DisciplinaNameTb.Text = null;
                    ObemTb.Text = null;
                }
            }
            
        }

        private void DisciplinaLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
