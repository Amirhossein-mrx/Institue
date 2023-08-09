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
    }
}
