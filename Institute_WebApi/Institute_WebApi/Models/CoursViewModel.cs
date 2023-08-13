using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute_WebApi.Models
{
    public class CoursViewModel
    {
        public int Id { get; set; }
        public string CoursName { get; set; }
        public int InstructorsId { get; set; }
        public int IsDelete { get; set; }
    }
}
