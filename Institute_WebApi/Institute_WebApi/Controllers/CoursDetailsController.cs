using Institute_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Institute_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursDetailsController : ControllerBase
    {
        IEnrollments _Enrollments;
        ICourse _Course;
        IStudent _Student;
        IInstructors _Instructors;
        public CoursDetailsController()
        {
            _Enrollments = new EnrollmentsService();
            _Course = new CoursesService();
            _Student = new StudentService();
            _Instructors = new InstructorsService();
        }

        [HttpGet("getcourse")]
        public ActionResult GetCourse(int id)
        {

            CoursViewModel cours = new CoursViewModel();
            cours = _Course.SelectRow(id);

            InstructorViewModel instructor = new InstructorViewModel();
            instructor = _Instructors.SelectRow(cours.InstructorsId);


            List<EnrollmentsViewModel> enroll = new List<EnrollmentsViewModel>();
            enroll = _Enrollments.enrolldetails(cours.Id);
            

            //StudentViewModel student = new StudentViewModel();
            //student = _Student.SelectRow(enroll.StudentId);


            CoursDetailViewModel coursDetaicls = new CoursDetailViewModel()
            {
                Cours=cours,
                //Students=student,
                Enroll=enroll,
                Instructor=instructor
            };
            return Ok(coursDetaicls);
        }
    }
}
