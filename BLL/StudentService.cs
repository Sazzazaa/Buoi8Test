using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BLL
{
    public class StudentService
    {
        private StudentDBContext db = new StudentDBContext();


        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }
        public bool InsertStudent(Student order)
        {
            try
            {
                    db.Students.Add(order);
                    db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public List<object> GetSTUDENTs()
        {
            // Chỉ select các cột cần
            var data = from st in db.Students
                       join fa in db.Faculties on st.FacultyID equals fa.FacultyID
                       select new
                       {
                           StudentID = st.StudentID,
                           FullName = st.FullName,
                           AverageScore = st.AverageScore,
                           FacultyName = fa.FacultyName,

                       };
            return data.ToList<object>();


        }
        public void UpdateTable(Student student)
        {
            var existingTable = db.Students.FirstOrDefault(t => t.StudentID == student.StudentID);
            if (existingTable != null)
            {
                existingTable.FullName = student.FullName;
                existingTable.FacultyID = student.FacultyID;
                db.SaveChanges();
            }
        }
        public void DeleteTable(string studentID)
        {
            var student = db.Students.FirstOrDefault(t => t.StudentID == studentID);
            if (studentID != null)
            {
                db.Students.Remove(student);
                db.SaveChanges();
            }
        }
    }
}


