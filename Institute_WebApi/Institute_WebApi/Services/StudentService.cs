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
     public class StudentService : IStudent
    {
        string connectionString = "Data Source=172.18.176.74\\sana; Initial Catalog=AmirD;Integrated Security=true";

        public bool Delete(int id)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From Students Where Id=(@Id)";
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

        public bool Insert(StudentViewModel Student)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query= "Insert Into Students (Name,Family) values (@Name,@Family)";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Name", Student.Name);
                command.Parameters.AddWithValue("@Family", Student.Family);

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
                
                string query = "select * from Students";
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);        
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return dataTable;
            }         
        }
        

        public StudentViewModel SelectRow(int studentid)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            StudentViewModel student = new StudentViewModel();
            //string name;
            try
            {
                string query = "select * from Students where Id="+studentid;
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                adapter.Fill(dataTable);
                student.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                student.Name = dataTable.Rows[0]["Name"].ToString();
                student.Family = dataTable.Rows[0]["Family"].ToString();

                //student = dataTable.Rows[0]["Name"].ToString();
                return student;
            }
            catch
            {
                return student;
            }
            
        }

        public bool Update(StudentViewModel Student)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
           
                string query = "Update Students Set Name=@Name,Family=@Family  Where Id=@Id";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Name", Student.Name);
                command.Parameters.AddWithValue("@Family", Student.Family);
                command.Parameters.AddWithValue("@Id", Student.Id);
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
