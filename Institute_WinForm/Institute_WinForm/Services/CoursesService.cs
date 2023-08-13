using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Institute_WinForm
{
    public class CoursesService : IInstitue_Cours
    {


        //string Url = "http://localhost:19785/api";
        string Url = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        public bool Delete(int id)
        {
            try
            {
                string Url_SelectAll = Url + "/Cours/delete?id=" + id;
                using (HttpClient Client = new HttpClient())
                {
                    var Result = Client.DeleteAsync(Url_SelectAll).Result;
                  
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }

        }

        public bool Insert(EnrollmentsViewModel enroll)
        {
            try
            {
                string Url_SelectAll = Url + "/Enroll/addnew";

                using (HttpClient Client = new HttpClient())
                {
                  
                    string jsonString = JsonConvert.SerializeObject(enroll);

                    //var result =  Client.PutAsync(Url_SelectAll);
                    //var Result= Client.PostAsync(Url_SelectAll, System.Net.Http.HttpContent ? content).Result;
                    //var cours = JsonConvert.DeserializeObject<string>(Result);


                    using (HttpContent httpContent = new StringContent(jsonString))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        HttpResponseMessage response = Client.PostAsync(Url_SelectAll, httpContent).Result;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public List<CoursViewModel> SelectAllCousrs()
        {
            List<CoursViewModel> cours = new List<CoursViewModel>();
            try
            {
                string Url_SelectAll = Url + "/Cours/getAll";
                using (HttpClient Client = new HttpClient())
                {
                    var Result = Client.GetStringAsync(Url_SelectAll).Result;

                    cours = JsonConvert.DeserializeObject<List<CoursViewModel>>(Result);
                    return cours;
                }

            }
            catch (Exception)
            {

                return cours;
            }
          
        }

        public List<CoursDetailViewModel> SelectCoursDetails(int id)
        {
            throw new NotImplementedException();
        }

        public CoursViewModel SelectRow(int courseid)
        {

            string Url_SelectAll = Url + "/Cours/" + courseid;
            using (HttpClient Client = new HttpClient())
            {
                var Result = Client.GetStringAsync(Url_SelectAll).Result;

                var cours = JsonConvert.DeserializeObject<CoursViewModel>(Result);

                return cours;

            }
        }

        public JsonforCoutsDetails CoursDetails(int cousrid)
        {
            string Url_SelectAll = Url + "/CoursDetails/" + cousrid;
            using (HttpClient Client = new HttpClient())
            {
                var Result = Client.GetStringAsync(Url_SelectAll).Result;

                var coursDetails = JsonConvert.DeserializeObject<JsonforCoutsDetails>(Result);

                return coursDetails;
            }
        }

        public bool Update(CoursViewModel course)
        {
            try
            { 
                string Url_SelectAll = Url + "/Cours/"+ course.Id +"/"+ course.CoursName + "/" + course.InstructorsId;
                
                using (HttpClient Client = new HttpClient())
                {
                    string name = "abc";
                    string jsonString = JsonConvert.SerializeObject(name); 

                    //var result =  Client.PutAsync(Url_SelectAll);
                    //var Result= Client.PostAsync(Url_SelectAll, System.Net.Http.HttpContent ? content).Result;
                    //var cours = JsonConvert.DeserializeObject<string>(Result);


                    using (HttpContent httpContent = new StringContent(jsonString))
                    {
                        httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        HttpResponseMessage response = Client.PutAsync(Url_SelectAll, httpContent).Result;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        
        }

        public StudentViewModel StudentfindbyID(int studentid)
        {

            string Url_SelectAll = Url + "/Student/" + studentid;
            using (HttpClient Client = new HttpClient())
            {
                var Result = Client.GetStringAsync(Url_SelectAll).Result;

                var studentDetails = JsonConvert.DeserializeObject<StudentViewModel>(Result);


                return studentDetails;
            }
        }


        public List<StudentViewModel> SelectAllStudents()
        {
            List<StudentViewModel> students = new List<StudentViewModel>();
            try
            {
                string Url_SelectAll = Url + "/Student/getAll";
                using (HttpClient Client = new HttpClient())
                {
                    var Result = Client.GetStringAsync(Url_SelectAll).Result;

                    students = JsonConvert.DeserializeObject<List<StudentViewModel>>(Result);
                    return students;
                }
            }
            catch (Exception)
            {

                return students;
            }
           
        }

        public List<InstructorViewModel> SelectAllInstructor()
        {
            List<InstructorViewModel> instructor = new List<InstructorViewModel>();
            try
            {
                string Url_SelectAll = Url + "/Instructors/getAll";
                using (HttpClient Client = new HttpClient())
                {
                    var Result = Client.GetStringAsync(Url_SelectAll).Result;

                     instructor = JsonConvert.DeserializeObject<List<InstructorViewModel>>(Result);
                    return instructor;
                }
            }
            catch (Exception)
            {

                return instructor; 
            }
           
        }
    }
}
