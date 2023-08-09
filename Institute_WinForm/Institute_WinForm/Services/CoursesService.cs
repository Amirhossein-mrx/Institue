
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Institute_WinForm
{
    public class CoursesService : IInstitue_Cours
    {

       
        string Url = "http://localhost:19785/api";

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(CoursViewModel enroll)
        {
            throw new NotImplementedException();
        }

        public List<CoursViewModel>SelectAll()
        {
            string Url_SelectAll = Url+"/Cours/getAll";
            using (HttpClient Client = new HttpClient())
            {
                var Result = Client.GetStringAsync(Url_SelectAll).Result;

                var cours = JsonConvert.DeserializeObject<List<CoursViewModel>>(Result);
                return cours;
            }
            
        }

        public List<CoursDetailViewModel> SelectCoursDetails(int id)
        {
            throw new NotImplementedException();
        }

        public CoursViewModel SelectRow(int courseid)
        {
            
            string Url_SelectAll = Url + "/Cours/"+courseid;
            using (HttpClient Client = new HttpClient())
            {
                var Result = Client.GetStringAsync(Url_SelectAll).Result;

                var cours = JsonConvert.DeserializeObject<CoursViewModel>(Result);
                return cours;
            }
        }

        public JsonforCoutsDetails instructorfindbycousrid(int cousrid)
        {
            string Url_SelectAll = Url + "/CoursDetails/getcourse?id=" + cousrid;
            using (HttpClient Client = new HttpClient())
            {
                var Result = Client.GetStringAsync(Url_SelectAll).Result;

                var coursDetails = JsonConvert.DeserializeObject<JsonforCoutsDetails>(Result);

                
                return coursDetails;
            }
        }

        public bool Update(CoursViewModel course)
        {
            throw new NotImplementedException();
        }
    }
}
