using Institute_WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Institute_WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        IEnrollments _Enrollments;
        public EnrollController()
        {
            _Enrollments = new EnrollmentsService();
        }

        [HttpGet("getAll")]
        public ActionResult Get()
        {
            DataTable EnrollTable = new DataTable();
            EnrollTable = _Enrollments.SelectAll();
            EnrollmentsViewModel[] Enroll = new EnrollmentsViewModel[EnrollTable.Rows.Count];
            for (int i = 0; i < EnrollTable.Rows.Count; i++)
            {
                DataRow row = EnrollTable.Rows[i];

                Enroll[i] = new()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    StudentId = Convert.ToInt32(row["StudentId"]),
                    CourseId = Convert.ToInt32(row["CourseId"]),
                    Date = row["Date"].ToString(),
                    
                };
            }
            return Ok(Enroll);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            EnrollmentsViewModel Name = _Enrollments.SelectRow(id);
            return Ok(Name);

        }

        [HttpPost("addnew")]
        public JsonResult add(EnrollmentsViewModel a)
        {
            EnrollmentsViewModel Enroll = new EnrollmentsViewModel()
            {
               
                StudentId = a.StudentId,
                CourseId = a.CourseId,
                Date= a.Date,
            };

            bool issuccss = _Enrollments.Insert(Enroll);
            if (issuccss)
            {
                return new JsonResult("successful");
            }
            else
            {
                return new JsonResult("Fail");
            }
        }


        [HttpDelete("delete")]
        public string Delete(int id)
        {
            bool issuccss = _Enrollments.Delete(id);
            if (issuccss)
            {
                return "Successful";
            }
            else
            {
                return "Fail";
            }
        }

        [HttpPut("update")]
        public string Update(int id, int studentid, int courseid,string date)
        {
            EnrollmentsViewModel cours = new EnrollmentsViewModel()
            {
                Id = id,
                StudentId = studentid,
                CourseId = courseid,
                Date = date,

            };
            bool issuccss = _Enrollments.Update(cours);
            if (issuccss)
            {
                return "Successful";
            }
            else
            {
                return "Fail";
            }
        }
    }
}
