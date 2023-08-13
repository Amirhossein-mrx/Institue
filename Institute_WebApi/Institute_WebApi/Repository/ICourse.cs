using Institute_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Institute_WebApi
{
     public interface ICourse
    {
        List<CoursDetailViewModel> coursDetails(int id);
        DataTable SelectAll();
        CoursViewModel SelectRow(int courseid);
        bool Insert(CoursViewModel course);
        bool Update(CoursViewModel course);
        bool Delete(int id);
    }

}
