using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq;

namespace Institute_WinForm
{
    public partial class Form1 : Form
    {
        IInstitue_Cours coursService;
        List<CoursViewModel> cours = new List<CoursViewModel>();
        List<StudentViewModel> students = new List<StudentViewModel>();
        List<InstructorViewModel> instructor = new List<InstructorViewModel>();
        Dictionary<int, string> coursAndId = new Dictionary<int, string>();
        Dictionary<int, string> instructorAndId = new Dictionary<int, string>();
       // Dictionary<int, string> StudentAndId = new Dictionary<int, string>();
        public Form1()
        {
            InitializeComponent();
            coursService = new CoursesService();
        }
        void Refresh()
        {
            coursAndId.Clear();
            comboBox1.Items.Clear();
            lbCours.Items.Clear();
            lbDetails.Items.Clear();
            instructorAndId.Clear();
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            cours = coursService.SelectAllCousrs();
            for (int i = 0; i < cours.Count; i++)
            {
                if (cours[i].IsDelete == 1)
                {
                    coursAndId.Add(cours[i].Id, cours[i].CoursName+"D");
                }
                else
                {
                     lbCours.Items.Add(cours[i].CoursName);
                     coursAndId.Add( cours[i].Id, cours[i].CoursName);
                }
            }

            students = coursService.SelectAllStudents();
            for (int i = 0; i < students.Count; i++)
            {
                //lbStudent.Items.Add(students[i].Name + "," + students[i].Family);
                int index = dataGridView1.Rows.Add();
                dataGridView1.Rows[index].Cells[0].Value = students[i].Id;
                dataGridView1.Rows[index].Cells[1].Value = students[i].Name;
                dataGridView1.Rows[index].Cells[2].Value = students[i].Family;

                //StudentAndId.Add(students[i].Id, students[i].Name);
            }

            instructor = coursService.SelectAllInstructor();
            for (int i = 0; i < instructor.Count; i++)
            {
                instructorAndId.Add(instructor[i].Id, instructor[i].InstructorName);
                comboBox1.Items.Add(instructor[i].InstructorName);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btn_CoursDetails_Click(object sender, EventArgs e)
        {
            lbDetails.Items.Clear();
            JsonforCoutsDetails coutsDetails = new JsonforCoutsDetails();
            string a = lbCours.SelectedItem.ToString();

            var myKey = coursAndId.FirstOrDefault(x => x.Value == a).Key;
            coutsDetails =coursService.CoursDetails(myKey);

            comboBox1.Text = coutsDetails.instructor.InstructorName;

            txtCoursName.Text = coutsDetails.cours.CoursName ;

            for (int i = 0; i < coutsDetails.enroll.Count; i++)
            {
                lbDetails.Items.Add(coutsDetails.enroll[i].Date);
                var Studentsdetails = coursService.StudentfindbyID(coutsDetails.enroll[i].StudentId);
                lbDetails.Items.Add("Student : " + Studentsdetails.Name + "," + Studentsdetails.Family);
                //StudentsId.Add(coutsDetails.enroll[i].StudentId);
            }
            //txtStudent.Text=coursService.StudentfindbyID(coutsDetails.enroll)
           
            //txtDate.Text = coutsDetails.enroll.Date;
            //dataGridView1.DataSource =;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a=lbCours.SelectedItem.ToString();
            var myKey = coursAndId.FirstOrDefault(x => x.Value == a).Key;
            if (coursService.Delete(myKey))
            {
                MessageBox.Show("Successful");
                coursAndId.Clear();
                Refresh();
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            var myKey_instructor = instructorAndId.FirstOrDefault(x => x.Value == comboBox1.Text).Key;

            string a = lbCours.SelectedItem.ToString();
            var myKey = coursAndId.FirstOrDefault(x => x.Value == a).Key;
            JsonforCoutsDetails coutsDetails = new JsonforCoutsDetails();
            coutsDetails = coursService.CoursDetails(myKey);
            //string a = lbCours.SelectedItem.ToString();
            //int b = coursAndId[a];

            CoursViewModel coursUpdate = new CoursViewModel()
            {
                Id = myKey,
                CoursName = txtCoursName.Text,
                InstructorsId = myKey_instructor
            };


            if (coursService.Update(coursUpdate))
            {
                MessageBox.Show("Successful");
                //coursAndId.Clear();
                Refresh();
            }
            else
            {
                MessageBox.Show("Fail");
            }
            txtCoursName.Text = "";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (isvalid())
            {
                var mykey_Student = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                var myKey_cours = coursAndId.FirstOrDefault(x => x.Value == txtCoursName.Text).Key;

                EnrollmentsViewModel EnrollDetails = new EnrollmentsViewModel()
                {
                    StudentId = mykey_Student,
                    CourseId = myKey_cours,
                    Date = dateTimePicker1.Value.ToShortDateString(),
                };

                if (coursService.Insert(EnrollDetails))
                {
                    MessageBox.Show("Successful");
                }
                else
                {
                    MessageBox.Show("Fail");
                }
            }
           
        }
        bool isvalid()
        {
            if (txtCoursName.Text=="")
            {
                MessageBox.Show("Enter Your CoursName", "Warninng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Enter Your Instructor", "Warninng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
