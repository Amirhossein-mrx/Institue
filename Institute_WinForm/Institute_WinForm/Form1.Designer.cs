
namespace Institute_WinForm
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbCours = new System.Windows.Forms.ListBox();
            this.btn_CoursDetails = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.txtStudent = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtInstructors = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDetails = new System.Windows.Forms.ListBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Student = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Instructor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lbCours
            // 
            this.lbCours.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbCours.FormattingEnabled = true;
            this.lbCours.ItemHeight = 19;
            this.lbCours.Location = new System.Drawing.Point(0, 0);
            this.lbCours.Name = "lbCours";
            this.lbCours.Size = new System.Drawing.Size(263, 330);
            this.lbCours.TabIndex = 0;
            // 
            // btn_CoursDetails
            // 
            this.btn_CoursDetails.Location = new System.Drawing.Point(272, 264);
            this.btn_CoursDetails.Name = "btn_CoursDetails";
            this.btn_CoursDetails.Size = new System.Drawing.Size(114, 35);
            this.btn_CoursDetails.TabIndex = 1;
            this.btn_CoursDetails.Text = "Cours Detail";
            this.btn_CoursDetails.UseVisualStyleBackColor = true;
            this.btn_CoursDetails.Click += new System.EventHandler(this.btn_CoursDetails_Click);
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(6, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(55, 19);
            this.Label1.TabIndex = 2;
            this.Label1.Text = "Student";
            // 
            // txtStudent
            // 
            this.txtStudent.Location = new System.Drawing.Point(104, 22);
            this.txtStudent.Name = "txtStudent";
            this.txtStudent.Size = new System.Drawing.Size(158, 26);
            this.txtStudent.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtInstructors);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtStudent);
            this.groupBox1.Controls.Add(this.Label1);
            this.groupBox1.Location = new System.Drawing.Point(272, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 94);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // txtInstructors
            // 
            this.txtInstructors.Location = new System.Drawing.Point(104, 53);
            this.txtInstructors.Name = "txtInstructors";
            this.txtInstructors.Size = new System.Drawing.Size(158, 26);
            this.txtInstructors.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Instructor";
            // 
            // lbDetails
            // 
            this.lbDetails.FormattingEnabled = true;
            this.lbDetails.ItemHeight = 19;
            this.lbDetails.Location = new System.Drawing.Point(278, 113);
            this.lbDetails.Name = "lbDetails";
            this.lbDetails.Size = new System.Drawing.Size(262, 137);
            this.lbDetails.TabIndex = 5;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Student,
            this.Instructor,
            this.Date});
            this.dataGridView1.Location = new System.Drawing.Point(621, 21);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(560, 278);
            this.dataGridView1.TabIndex = 6;
            // 
            // Student
            // 
            this.Student.DataPropertyName = "Student";
            this.Student.HeaderText = "Student";
            this.Student.Name = "Student";
            // 
            // Instructor
            // 
            this.Instructor.DataPropertyName = "Instructor";
            this.Instructor.HeaderText = "Instructor";
            this.Instructor.Name = "Instructor";
            // 
            // Date
            // 
            this.Date.DataPropertyName = "Date";
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 330);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbDetails);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_CoursDetails);
            this.Controls.Add(this.lbCours);
            this.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbCours;
        private System.Windows.Forms.Button btn_CoursDetails;
        private System.Windows.Forms.Label Label1;
        private System.Windows.Forms.TextBox txtStudent;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtInstructors;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbDetails;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Student;
        private System.Windows.Forms.DataGridViewTextBoxColumn Instructor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Date;
    }
}

