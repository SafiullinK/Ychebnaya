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
    /// Логика взаимодействия для DepartmentPage.xaml
    /// </summary>
    public partial class DepartmentPage : Page
    {
        public static List<Kafedra> kafedras { get; set; }
        public static Kafedra kaf { get; set; }
        public static List<Fackultet> fackultets = new List<Fackultet>();

        public DepartmentPage()
        {
            InitializeComponent();
            kafedras = new List<Kafedra>(DBConnection.ychebnayaEntities.Kafedra.ToList());
            this.DataContext = this;
            kafedraslv.ItemsSource = kafedras;
            fackultets = new List<Fackultet>(DBConnection.ychebnayaEntities.Fackultet.ToList());
            FackultyCb.ItemsSource = fackultets;
            FackultyCb.DisplayMemberPath = "Name";

        }

        private void DisciplinaLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            kaf = kafedraslv.SelectedItem as Kafedra;
        }
        private void DisciplinaLv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            kaf = kafedraslv.SelectedItem as Kafedra;
            NavigationService.Navigate(new DisciplinePage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AuthorizationPage());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if(kafedraslv.SelectedItems.Count >= 1)
            {
                if(kafedraslv.SelectedItems.Count >1)
                {
                    MessageBox.Show("Выберите только 1 строку для изменения!");
                }
                else
                {
                    if (DisciplinaNameTb.Text.Length < 1 || ObemTb.Text.Trim().Length>2)
                        MessageBox.Show("Заполните все поля верно, шифр должен состоять максимум из 2 букв!");
                    else
                    {
                        Kafedra kafedra = ((Kafedra)kafedraslv.SelectedItem);
                        kafedra = DBConnection.ychebnayaEntities.Kafedra.Where(x => x.Kafedra_id == kafedra.Kafedra_id).First();
                        kafedra.Name = DisciplinaNameTb.Text;
                        kafedra.Shifr = ObemTb.Text.Trim();
                        DBConnection.ychebnayaEntities.SaveChanges();
                        MessageBox.Show("Готово!");
                        kafedraslv.ItemsSource = DBConnection.ychebnayaEntities.Kafedra.ToList();
                    }
                }
            }
            else
            {
        
                    Kafedra kafedra = new Kafedra
                    {
                        Shifr = ObemTb.Text.Trim(),
                        Name = DisciplinaNameTb.Text,
                        Fackultet =(FackultyCb.SelectedItem as Fackultet).Fackultet_id 
                        
                    };
                    DBConnection.ychebnayaEntities.Kafedra.Add(kafedra);
                    DBConnection.ychebnayaEntities.SaveChanges();
                    MessageBox.Show("Готово!");
                    kafedraslv.ItemsSource = DBConnection.ychebnayaEntities.Kafedra.ToList();
                
            }
        }
    }
        
}

