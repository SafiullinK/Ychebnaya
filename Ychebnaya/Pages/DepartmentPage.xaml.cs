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
        public DepartmentPage()
        {
            InitializeComponent();
            kafedras = new List<Kafedra>(DBConnection.ychebnayaEntities.Kafedra.ToList());
            this.DataContext = this;
            kafedraslv.ItemsSource = kafedras; 

        }

        private void DisciplinaLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
