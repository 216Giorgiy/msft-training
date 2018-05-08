using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers {
    public class StudentController : ApiController {

        private TrainingContext context { get; set; }

        public StudentController() {
            context = new TrainingContext();
        }

        public Student Get(int id) {
            Student retVal = null;

            try {
                //find the object in the database
                retVal = context.Students.Where(c => c.Id == id).FirstOrDefault();
            } catch (Exception ex) {
                AppTrace.Error(ex.Message);
                throw;
            }

            return retVal;
        }

        public List<Student> Get() {
            List<Student> retVal = new List<Student>();

            try {
                //find the object in the database
                retVal = context.Students.ToList<Student>();
            } catch (Exception ex) {
                AppTrace.Error(ex.Message);
                throw;
            }
            
            return retVal;
        }

        public Student Post(Student student) {
            Student retVal = null;

            try {
                //construct the object for the database
                Student studentItem = new Student() { Name = student.Name };

                //create the object in the database
                retVal = context.Students.Add(studentItem);

                context.SaveChanges();
            } catch (Exception ex) {
                //Trace the error
                AppTrace.Error(ex.Message);
                throw;
            }
            
            return retVal;
        }

        public void Put(Student student) {
            try {
                //create the object in the database
                Student studentItem = context.Students.Where(s=> s.Id == student.Id).FirstOrDefault();

                if(student != null) {
                    studentItem.Name = student.Name;
                    context.SaveChanges();
                }

                //context.SaveChanges();
            } catch (Exception ex) {
                //Trace the error
                AppTrace.Error(ex.Message);
                throw;
            }
        }
    }
}
