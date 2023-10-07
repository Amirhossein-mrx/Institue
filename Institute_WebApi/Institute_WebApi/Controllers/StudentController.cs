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
    public class StudentController : ControllerBase
    {
        IStudent _StudentService;
        public StudentController()
        {
            _StudentService = new StudentService();
        }

        [HttpGet("getAll")]
        public ActionResult Get()
        {
            DataTable StudentTabel = new DataTable();
            StudentTabel = _StudentService.SelectAll();
            StudentViewModel[] students = new StudentViewModel[StudentTabel.Rows.Count];
            for (int i = 0; i < StudentTabel.Rows.Count; i++)
            {
                DataRow row = StudentTabel.Rows[i];

                students[i] = new()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Family = row["Family"].ToString(),
                };
            }
            return Ok(students);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            StudentViewModel Name = _StudentService.SelectRow(id);
            return Ok(Name);

        }

        [HttpPost("addnew")]
        public Result add(StudentViewModel2 newStudent)
        {
            StudentViewModel student = new StudentViewModel()
            {

                Name = newStudent.Name,
                Family = newStudent.Family,


            };
            Result result=new Result();
            bool issuccss = _StudentService.Insert(student);
            if (issuccss)
            {
                result.Message = "Successful";
                return result;
            }
            else
            {
                result.Message = "Fail";
                return result;
            }
        }


        [HttpDelete("delete/{id}")]
        public Result Delete(int id)
        {
            bool issuccss = _StudentService.Delete(id);
            Result result = new Result();
           
            if (issuccss)
            {
                result.Message = "Successful";
                return result;
            }
            else
            {
                result.Message = "Fail";
                return result;
            }
        }

        [HttpPut("update")]
        public string Update(int id, string name, string family)
        {
            StudentViewModel student = new StudentViewModel()
            {
                Id = id,
                Name = name,
                Family = family,

            };
            bool issuccss = _StudentService.Update(student);
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
