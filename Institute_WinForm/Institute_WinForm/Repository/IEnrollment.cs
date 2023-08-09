
using System.Data;

namespace Institute_WinForm.Repository
{
   public interface IEnrollment
    {

        DataTable SelectAll();
        EnrollmentsViewModel SelectRow(int courseid);
        bool Insert(EnrollmentsViewModel enroll);
        bool Update(EnrollmentsViewModel course);
        bool Delete(int id);
    }
}
