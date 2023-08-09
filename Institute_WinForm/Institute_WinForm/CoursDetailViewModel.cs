using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute_WinForm
{
    public class CoursDetailViewModel
    {
        public CoursViewModel Cours { get; set; }
        public InstructorViewModel Instructor { get; set; }
        public StudentViewModel Students { get; set; }
        public EnrollmentsViewModel Enroll { get; set; }
    }
}
