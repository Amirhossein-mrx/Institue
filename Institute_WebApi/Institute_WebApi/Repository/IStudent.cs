using Institute_WebApi.Models;
using System.Data;

namespace Institute_WebApi
{
    public interface IStudent
    {
        bool Delete(int id);
        bool Insert(StudentViewModel student);
        DataTable SelectAll();
        StudentViewModel SelectRow(int studentid);
        bool Update(StudentViewModel student);
    }
}