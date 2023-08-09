using Institute_WebApi.Models;
using System.Collections.Generic;
using System.Data;

namespace Institute_WebApi
{
    public interface IEnrollments
    {
        bool Delete(int id);
        bool Insert(EnrollmentsViewModel enrollment);
        DataTable SelectAll();
        EnrollmentsViewModel SelectRow(int enrollmentsid);

        List<EnrollmentsViewModel> enrolldetails(int courseid);
        bool Update(EnrollmentsViewModel enrollment);
    }
}