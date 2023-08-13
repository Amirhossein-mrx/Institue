
using System.Collections.Generic;
using System.Data;



namespace Institute_WinForm
{
     public interface IInstitue_Cours
    {

        List<CoursViewModel> SelectAllCousrs();
        List<StudentViewModel> SelectAllStudents();
        List<InstructorViewModel> SelectAllInstructor();
        JsonforCoutsDetails CoursDetails(int cousrid);
        StudentViewModel StudentfindbyID(int studentid);
        List<CoursDetailViewModel> SelectCoursDetails(int id);
        CoursViewModel SelectRow(int courseid);
        bool Insert(EnrollmentsViewModel enroll);
        bool Update(CoursViewModel course);
        bool Delete(int id);
    }

}
