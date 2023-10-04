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
    public class CoursController : ControllerBase
    {
        ICourse _CoursesService;
        public CoursController()
        {
            _CoursesService = new CoursesService();
        }

        [HttpGet("getAll")]
        public ActionResult Get()
        {
            DataTable CoursTable = new DataTable();
            CoursTable = _CoursesService.SelectAll();
            CoursViewModel2[] Cours = new CoursViewModel2[CoursTable.Rows.Count];
            for (int i = 0; i < CoursTable.Rows.Count; i++)
            {
                DataRow row = CoursTable.Rows[i];

                Cours[i] = new()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CoursName = row["CoursName"].ToString(),
                    InstructorName =row["InstructorName"].ToString(),
                    //IsDelete = Convert.ToInt32(row["IsDelete"]),
                };
            }
            return Ok(Cours);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            CoursViewModel Name = _CoursesService.SelectRow(id);
            if (Name.IsDelete == 0)
            {

                return Ok(Name);
            }
            else
            {
                return Ok("No Find");
            }
        }

        [HttpPost("addnew")]
        public Result add(CourseAddViewModel couse)
        {
            CoursViewModel cours = new CoursViewModel()
            {

                CoursName = couse.coursname,
                InstructorsId = couse.instructorsid,
                IsDelete=0
            };

            bool issuccss = _CoursesService.Insert(cours);
            Result result=new Result();
            if (issuccss)
            {
                result.Message = "Success";
                return result;
            }
            else
            {
                 result.Message = "Fail";
                 return result;
            }
        }

        [HttpDelete("delete")]
        public string Delete(int id)
        {
            bool issuccss = _CoursesService.Delete(id);
            if (issuccss)
            {
                return "Successful";
            }
            else
            {
                return "Fail";
            }
        }

        [HttpPut("{id}/{coursname}/{instructorsId}")]
        public ActionResult Update(int id, string coursname, int instructorsId)
        {
            CoursViewModel cours = new CoursViewModel()
            {
                Id=id,
                CoursName = coursname,
                InstructorsId = instructorsId,
                IsDelete=0

            };
            bool issuccss = _CoursesService.Update(cours);
            if (issuccss)
            {
                return Ok("Successful");
            }
            else
            {
                return Ok("Fail");
            }
        }

    }
}
