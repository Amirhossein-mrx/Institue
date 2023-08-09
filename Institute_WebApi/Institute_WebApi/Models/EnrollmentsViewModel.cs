using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute_WebApi.Models
{
    public class EnrollmentsViewModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public string Date { get; set; }
    }
}
