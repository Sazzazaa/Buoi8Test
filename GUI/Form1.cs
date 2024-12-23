using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL.Models;
namespace GUI
{
    public partial class Form1 : Form
    {
        private readonly StudentService studentService = new StudentService();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var students = studentService.GetSTUDENTs();
            dataGridView1.DataSource = students;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                Student Student = new Student()
                {
                    StudentID = txtID.Text,
                    FullName = txtName.Text,
                    AverageScore = int.Parse(cbbFaculty.Text),
                    FacultyID = int.Parse(txtFacultyID.Text)
                };

                bool result = studentService.InsertStudent(Student);
                var students = studentService.GetSTUDENTs();
                dataGridView1.DataSource = students;
            }
        }
    }
}
