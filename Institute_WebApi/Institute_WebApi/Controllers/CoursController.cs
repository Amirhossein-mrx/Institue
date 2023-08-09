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
            CoursViewModel[] Cours = new CoursViewModel[CoursTable.Rows.Count];
            for (int i = 0; i < CoursTable.Rows.Count; i++)
            {
                DataRow row = CoursTable.Rows[i];

                Cours[i] = new()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    CoursName = row["CoursName"].ToString(),
                    InstructorsId = Convert.ToInt32(row["InstructorsId"]),
                };
            }
            return Ok(Cours);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            CoursViewModel Name = _CoursesService.SelectRow(id);
            return Ok(Name);

        }

        [HttpPost("addnew")]
        public string add( string coursname, int instructorsid)
        {
            CoursViewModel cours = new CoursViewModel()
            {

                CoursName = coursname,
                InstructorsId = instructorsid,
                
               
            };

            bool issuccss = _CoursesService.Insert(cours);
            if (issuccss)
            {
                return "successful";
            }
            else
            {
                return "Fail";
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

        [HttpPut("update")]
        public string Update(int id, string coursname, int instructorsId)
        {
            CoursViewModel cours = new CoursViewModel()
            {
                Id=id,
                CoursName = coursname,
                InstructorsId = instructorsId,

            };
            bool issuccss = _CoursesService.Update(cours);
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
