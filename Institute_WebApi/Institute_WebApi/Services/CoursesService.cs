using Institute_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Institute_WebApi
{
     public class CoursesService : ICourse
    {
        string connectionString = "Data Source=172.18.176.74\\sana; Initial Catalog=AmirD;Integrated Security=true";

        public bool Delete(int id)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From Courses Where Id=(@Id)";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool Insert(CoursViewModel course)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query= "Insert Into Courses (CoursName,InstructorsId) values (@CoursName,@InstructorsId)";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@CoursName", course.CoursName);
                command.Parameters.AddWithValue("@InstructorsId", course.InstructorsId);
                Connection.Open();
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                Connection.Close();
            }
        }


        public DataTable SelectAll()
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            try
            {
                string query = "select * from Courses";
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);        
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return dataTable;
            }         
        }

        public CoursViewModel SelectRow(int courseid)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            CoursViewModel student = new CoursViewModel();
            //string name;
            try
            {
                string query = "select * from Courses where Id=" + courseid;
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                adapter.Fill(dataTable);
                student.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                student.CoursName = dataTable.Rows[0]["CoursName"].ToString();
                student.InstructorsId = Convert.ToInt32(dataTable.Rows[0]["InstructorsId"]);


                //student = dataTable.Rows[0]["Name"].ToString();
                return student;
            }
            catch
            {
                return student;
            }
            
        }

        public bool Update(CoursViewModel cours)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
           
                string query = "Update Courses Set CoursName=@CoursName,InstructorsId=@InstructorsId  Where Id=@Id";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@CoursName", cours.CoursName);
                command.Parameters.AddWithValue("@InstructorsId", cours.InstructorsId);
                command.Parameters.AddWithValue("@Id", cours.Id);
                Connection.Open();

                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                Connection.Close();
            }
        }
    }
}
