using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_WinForm
{
    public class JsonforCoutsDetails
    {
        public CoursViewModel cours { get; set; }
        public InstructorViewModel instructor { get; set; }
        //public StudentViewModel students { get; set; }
        public List<EnrollmentsViewModel> enroll { get; set; }
        //public string CoursName { get; set; }
        //public string InstructorName { get; set; }
        //public string StudentName { get; set; }
        //public string studentfamily { get; set; }
        //public int CoursId { get; set; }
        //public int StudentId { get; set; }
        //public int InstructorId { get; set; }
    }
}
