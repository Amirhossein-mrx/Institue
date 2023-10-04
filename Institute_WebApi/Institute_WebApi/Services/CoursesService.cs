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
        string connectionString = "Data Source=172.18.176.74\\sana; Initial Catalog=AmirD; Integrated Security=false; User ID=sana;Password=Tot@licd;";


        public List<CoursDetailViewModel> coursDetails(int id)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            List<CoursDetailViewModel> coursDetail = new List<CoursDetailViewModel>();
            try
            {
                string query = @"select c.Id as 'CoursId',c.CoursName as 'CoursName',I.InstructorName as 'InstructorName' ,s.Id as 'StudentId',s.Name as 'studentname',s.Family as'studentfamily' from Courses as c
                                    left join Instructors as I on c.InstructorsId = I.Id
                                    left join Enrollments as e on c.Id = e.CourseId
                                    left join Students as s on s.Id = e.StudentId
                                    where c.Id =@id";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Id", id);
                Connection.Open();
                //command.ExecuteNonQuery();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                    
                        coursDetail.Add(new()
                        {
                            //CoursId = (int)reader["CoursId"],
                            //CoursName = (string)reader["CoursName"],
                            //InstructorName = (string)reader["InstructorName"],
                            //StudentId = (int)reader["StudentId"],
                            //StudentName = (string)reader["studentname"],
                            //studentfamily = (string)reader["studentfamily"],
                        });
                    }
                    return coursDetail;
                }

            }
            catch(Exception ex)
            {
                return coursDetail;
            }
            finally
            {
                Connection.Close();
            }
        }

        public bool Delete(int id)
        {
            SqlConnection Connection = new SqlConnection(connectionString);
            try
            {
                string query = "update Courses SET IsDelete=1 Where Id=(@Id); delete from Enrollments where CourseId=@id2";
                SqlCommand command = new SqlCommand(query, Connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Id2", id);
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
                string query= "Insert Into Courses (CoursName,InstructorsId,IsDelete) values (@CoursName,@InstructorsId,0)";
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
                string query = @"select C.Id, C.CoursName,I.InstructorName from Courses as C
                                join Instructors as I on c.InstructorsId = I.Id
                                where IsDelete = 0";
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
                student.IsDelete = Convert.ToInt32(dataTable.Rows[0]["IsDelete"]);


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
           
                string query = "Update Courses Set CoursName=@CoursName,InstructorsId=@InstructorsId,IsDelete=0  Where Id=@Id";
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
