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
        public DisciplinePage()
        {
            InitializeComponent();
            DisciplinaLv.ItemsSource = new List<Disciplina>(DBConnection.ychebnayaEntities.Disciplina.ToList());
            //TovarsLv.ItemsSource = new List<Tovar>(Connection.pracktica3Entities.Tovar.ToList());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
            
        }

    }
}
