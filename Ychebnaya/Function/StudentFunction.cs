using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ychebnaya.DB;

namespace Ychebnaya.Function
{
    public class StudentFunction
    {
        public static ObservableCollection<Student> students { get; set; }
        public static ObservableCollection<Student> GetStudents()
        {
            return new ObservableCollection<Student>(DBConnection.ychebnayaEntities.Student.ToList());
        }
    }
}
