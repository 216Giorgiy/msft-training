using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Api.Controllers {
    public class TrainingController : ApiController {

        private TrainingContext context { get; set; }

        public TrainingController() {
            context = new TrainingContext();
        }

        public Course Get(int id) {
            Course retVal = null;

            try {
                retVal = context.Courses.Where(c => c.Id == id).FirstOrDefault();
            } catch (Exception ex) {
                AppTrace.Error(ex.Message);
                throw;
            }

            return retVal;
        }

        public List<Course> Get() {
            List<Course> retVal = new List<Course>();

            try {
                retVal = context.Courses.ToList<Course>();
            } catch (Exception ex) {
                AppTrace.Error(ex.Message);
                throw;
            }

            return retVal;
        }

        public Course Post(Course course) {
            Course retVal = null;

            try {
                //create the object in the database
                retVal = context.Courses.Add(course);

                context.SaveChanges();
            } catch (Exception ex) {
                //Trace the error
                AppTrace.Error(ex.Message);
                throw;
            }
            
            return retVal;
        }
    }
}
