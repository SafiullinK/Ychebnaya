using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ychebnaya.DB;

namespace Ychebnaya.Function
{
    public class ExamFunction
    {
        public static ObservableCollection<Exam> exams { get; set; }
        public static ObservableCollection<Exam> GetExam()
        {
            return new ObservableCollection<Exam>(DBConnection.ychebnayaEntities.Exam.ToList());
        }
    }
}
