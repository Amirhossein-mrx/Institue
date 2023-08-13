using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute_WebApi.Models
{
    public class CoursDetailViewModel
    {
        public CoursViewModel Cours { get; set; }
        public InstructorViewModel Instructor { get; set; }
        //public StudentViewModel Students { get; set; }
        public List<EnrollmentsViewModel> Enroll { get; set; }

        //public string CoursName { get; set; }
        //public string InstructorName { get; set; }
        //public string StudentName { get; set; }
        //public string studentfamily { get; set; }
        //public int CoursId { get; set; }
        //public int StudentId { get; set; }
        //public int InstructorId { get; set; }
    }
}
