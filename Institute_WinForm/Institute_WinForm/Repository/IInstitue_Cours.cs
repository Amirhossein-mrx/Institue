
using System.Collections.Generic;
using System.Data;



namespace Institute_WinForm
{
     public interface IInstitue_Cours
    {

        List<CoursViewModel> SelectAll();
        JsonforCoutsDetails instructorfindbycousrid(int cousrid);
        List<CoursDetailViewModel> SelectCoursDetails(int id);
        CoursViewModel SelectRow(int courseid);
        bool Insert(CoursViewModel enroll);
        bool Update(CoursViewModel course);
        bool Delete(int id);
    }

}
