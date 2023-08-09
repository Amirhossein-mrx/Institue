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
     public class EnrollmentsService:IEnrollments
    {
        string connectionString = "Data Source=172.18.176.74\\sana; Initial Catalog=AmirD;Integrated Security=true";

        public bool Delete(int id)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query = "Delete From Enrollments Where Id=(@Id)";
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

        public List<EnrollmentsViewModel> enrolldetails(int courseid)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            List<EnrollmentsViewModel> enrollments = new List<EnrollmentsViewModel>();
            
            //string name;
            try
            {
                string query = "select * from Enrollments where CourseId=" + courseid;
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                adapter.Fill(dataTable);
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    EnrollmentsViewModel enrollment = new EnrollmentsViewModel();
                    enrollment.Id = Convert.ToInt32(dataTable.Rows[i]["Id"]);
                    enrollment.StudentId = Convert.ToInt32(dataTable.Rows[i]["StudentId"]);
                    enrollment.CourseId = Convert.ToInt32(dataTable.Rows[i]["CourseId"]);
                    enrollment.Date = dataTable.Rows[i]["Date"].ToString();
                    enrollments.Add(enrollment);
                }
               
                
                //student = dataTable.Rows[0]["Name"].ToString();
                return enrollments;
            }
            catch
            {
                return enrollments;
            }
        }

        public bool Insert(EnrollmentsViewModel enrollment)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query= "Insert Into Enrollments (StudentId,CourseId,Date) values (@StudentId,@CourseId,@Date)";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@StudentId", enrollment.StudentId  );
                command.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                command.Parameters.AddWithValue("@Date", enrollment.Date);
                
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
                string query = "select * from Enrollments";
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);        
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch
            {
                return dataTable;
            }         
        }

        public EnrollmentsViewModel SelectRow(int enrollmentid)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            DataTable dataTable = new DataTable();
            EnrollmentsViewModel enrollment = new EnrollmentsViewModel();
            //string name;
            try
            {
                string query = "select * from Enrollments where Id=" + enrollmentid;
                SqlDataAdapter adapter = new SqlDataAdapter(query, Connection);
                adapter.Fill(dataTable);
                enrollment.Id = Convert.ToInt32(dataTable.Rows[0]["Id"]);
                enrollment.StudentId = Convert.ToInt32(dataTable.Rows[0]["StudentId"]);
                enrollment.CourseId = Convert.ToInt32(dataTable.Rows[0]["CourseId"]);
                enrollment.Date = dataTable.Rows[0]["Date"].ToString();

                //student = dataTable.Rows[0]["Name"].ToString();
                return enrollment;
            }
            catch
            {
                return enrollment;
            }
            
        }

        public bool Update(EnrollmentsViewModel enrollment)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
           
                string query = "Update Enrollments Set StudentId=@StudentId,CourseId=@CourseId,Date=@Date Where Id=@Id";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@StudentId", enrollment.StudentId);
                command.Parameters.AddWithValue("@CourseId", enrollment.CourseId);
                command.Parameters.AddWithValue("@Id", enrollment.Id);
                command.Parameters.AddWithValue("@Date", enrollment.Date);
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
