using DBProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TrainingAPI.Controllers {
    public class StudentController : ApiController {
        public NewCodeFirstModel DBModel { get; set; }

        public StudentController() {
            DBModel = new NewCodeFirstModel();
        }

        public IEnumerable<Student> Get() {
            return DBModel.Students;
        }

        public Student Post([FromBody]string name) {
            if(!String.IsNullOrEmpty(name)) {
                Student createdStudent = DBModel.Students.Add(new Student { Name = name });
                DBModel.SaveChanges();
                return createdStudent;
            }
            return null;

        }

        public void Put(int id, [FromBody]string name) {
            var student = DBModel.Students.FirstOrDefault(s => s.Id == id); 
            if(student != null) {
                student.Name = name;
            }

            DBModel.SaveChanges();
        }


    }
}
