using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Institute_WinForm
{
    public partial class Form1 : Form
    {
        IInstitue_Cours coursService;
        List<CoursViewModel> cours = new List<CoursViewModel>();
        public Form1()
        {
            InitializeComponent();
            coursService = new CoursesService();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            cours=coursService.SelectAll();
            for (int i=0;i<cours.Count;i++)
            {
                
                lbCours.Items.Add("CoursName: "+ cours[i].CoursName+ "Instructors: " + cours[i].InstructorsId);
                
            }
            
        }

        private void btn_CoursDetails_Click(object sender, EventArgs e)
        {
            lbDetails.Items.Clear();
            DataTable DetailsTabel = new DataTable();
            JsonforCoutsDetails coutsDetails = new JsonforCoutsDetails();
            coutsDetails=coursService.instructorfindbycousrid(cours[lbCours.SelectedIndex].Id);


            DataColumn StudentColumn = new DataColumn();
            DataColumn InstructorColumn = new DataColumn();
            DataColumn DateColumn = new DataColumn();
            DetailsTabel.Columns.Add(StudentColumn);
            DetailsTabel.Columns.Add(InstructorColumn);
            DetailsTabel.Columns.Add(DateColumn);

            txtInstructors.Text = coutsDetails.instructor.InstructorName;
            for (int i = 0; i < coutsDetails.enroll.Count; i++)
            {
                lbDetails.Items.Add("Date : " + coutsDetails.enroll[i].Date);
                lbDetails.Items.Add("Student : " + coutsDetails.enroll[i].StudentId);

            }
            
           
            //txtDate.Text = coutsDetails.enroll.Date;
            //dataGridView1.DataSource =;


        }
    }
}
