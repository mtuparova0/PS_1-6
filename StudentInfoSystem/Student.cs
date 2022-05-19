using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfoSystem
{
    public class Student { 
   
        public int StudentId { get; set; }
        public string firstName { get; set; }    
        public string secondName { get; set; }   
        public string lastName { get; set; }

      
        public string faculty { get; set; }
    
        public string program { get; set; }

        public string degree { get; set; }
 
        public string status { get; set; }
        
        public string facultyNumber { get; set; }

     
        public int course { get; set; }
    
        public int flow { get; set; }

        public int group { get; set; }
        public byte[] Photo { get; set; }

        public float grade { get; set; }

        public Student() { }

        public Student(int StudentId, string firstName, string secondName, string lastName, string faculty, string program,
            string degree, string status, string facultyNumber, int course, int flow, int group, float grade)
        {
            this.StudentId = StudentId;
            this.firstName = firstName;
            this.secondName = secondName;
            this.lastName = lastName;
            this.faculty = faculty;
            this.program = program;
            this.degree = degree;
            this.status = status;
            this.facultyNumber = facultyNumber;
            this.course = course;
            this.flow = flow;
            this.group = group;
            this.grade = grade;
        }

    }
}
