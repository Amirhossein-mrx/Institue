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
     public class InstructorsService:IInstructors
    {
        string connectionString = "Data Source=172.18.176.74\\sana; Initial Catalog=AmirD;Integrated Security=true";

        public bool Delete(int id)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From Instructors Where Id=(@Id)";
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

        public bool Insert(InstructorViewModel instructor)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query= "Insert Into Instructors (InstructorName) values (@InstructorName)";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@InstructorName", instructor.InstructorName);

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
                string query = "select * from Instructors";
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);        
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return dataTable;
            }         
        }

        public InstructorViewModel SelectRow(int instructorid)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            InstructorViewModel instructor = new InstructorViewModel();
            //string name;
            try
            {
                string query = "select * from Instructors where Id=" + instructorid;
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                adapter.Fill(dataTable);
                instructor.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                instructor.InstructorName = dataTable.Rows[0]["InstructorName"].ToString();


                //student = dataTable.Rows[0]["Name"].ToString();
                return instructor;
            }
            catch
            {
                return instructor;
            }
            
        }

        public bool Update(InstructorViewModel instructor)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
           
                string query = "Update Instructors Set InstructorName=@InstructorNam Where Id=@Id";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@InstructorName", instructor.InstructorName);

                command.Parameters.AddWithValue("@Id", instructor.Id);
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
