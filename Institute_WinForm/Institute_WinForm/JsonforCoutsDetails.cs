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
    }
}
