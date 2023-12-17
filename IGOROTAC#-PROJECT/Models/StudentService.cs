using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IGOROTAC__PROJECT.Models
{
    public class StudentService

    {
        private static List<Student> StudentList;

        public StudentService()
        {
            StudentList = new List<Student>() {
                new Student{Id=1,Name="Jhonlee Garcia",Age=25, Course="BSIT", Year= "3rd Year"}
            
            };
        }

        public List<Student> GetAll()
        {
            return StudentList;
        }

        public bool Add(Student newStudent)
        {
            if (newStudent.Age < 16 && newStudent.Age > 100)
                throw new ArgumentException("Invalid age");
            StudentList.Add(newStudent);
            return true;
        }

        public bool Update(Student updateStudent)
        {
            bool isUpdated = false;
            for (int index = 0; index < StudentList.Count; index++)
            {
                if (StudentList[index].Id == updateStudent.Id)
                {
                    StudentList[index].Name = updateStudent.Name;
                    StudentList[index].Age = updateStudent.Age;
                    StudentList[index].Course = updateStudent.Course;
                    StudentList[index].Year = updateStudent.Year;

                    isUpdated = true;
                    break;
                }
            }
            return isUpdated;
        }

        public bool Delete(int id)
        {
            bool isDeleted = false;
            for (int index = 0; index < StudentList.Count; index++)
            {
                if (StudentList[index].Id == id)
                {
                    StudentList.RemoveAt(index);
                    isDeleted = true;
                    break;
                }
            }
            return isDeleted;
        }

        public Student Search(int id)
        {
            return StudentList.FirstOrDefault(e => e.Id == id);
        }


    }
}
