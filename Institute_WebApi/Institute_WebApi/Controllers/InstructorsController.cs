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
    public class InstructorsController : ControllerBase
    {
        IInstructors _InstructorsService;
        public InstructorsController()
        {
            _InstructorsService = new InstructorsService();
        }

        [HttpGet("getAll")]
        public ActionResult Get()
        {
            DataTable instrTable = new DataTable();
            instrTable = _InstructorsService.SelectAll();
            InstructorViewModel[] Instructors = new InstructorViewModel[instrTable.Rows.Count];
            for (int i = 0; i < instrTable.Rows.Count; i++)
            {
                DataRow row = instrTable.Rows[i];

                Instructors[i] = new()
                {
                    Id = Convert.ToInt32(row["Id"]),
                    InstructorName = row["InstructorName"].ToString(),
                  
                };
            }
            return Ok(Instructors);
        }

        [HttpPost("addnew")]
        public Result add(InstructorViewModel2 newStudent)
        {
           
            Result result = new Result();
            bool issuccss = _InstructorsService.Insert(newStudent);
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
    }
}
