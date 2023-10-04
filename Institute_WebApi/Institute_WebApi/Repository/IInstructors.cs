using Institute_WebApi.Models;
using System.Collections.Generic;
using System.Data;

namespace Institute_WebApi
{
    public interface IInstructors
    {
        //bool Delete(int id);
        bool Insert(InstructorViewModel2 instructor);
        DataTable SelectAll();
        InstructorViewModel SelectRow(int instructorid);
       // bool Update(InstructorViewModel instructor);
    }
}