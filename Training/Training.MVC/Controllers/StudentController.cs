using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Mvc.Controllers
{
    public class StudentController : Controller {
        private string RootUrl { get; set; }

        public StudentController() {
            RootUrl = ConfigurationManager.AppSettings["api:url"];
        }

        public ActionResult Index() {
            List<Student> retVal = new List<Student>();

            Uri url = new Uri(RootUrl + "api/student");

            var response = HttpClientHelper.Request(url, HttpMethod.Get);

            retVal = JsonConvert.DeserializeObject<List<Student>>(response, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });
            
            return View(retVal);
        }

        public ActionResult Create() {
            return View();
        }

        public ActionResult Edit(int id) {
            Student retVal = new Student();
            Uri url = new Uri(RootUrl + $"api/student/{id}");
            var response = HttpClientHelper.Request(url, HttpMethod.Get);

            retVal = JsonConvert.DeserializeObject<Student>(response, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });

            return View(retVal);
        }

        [HttpPost]
        public ActionResult Edit(int id, Student student) {
           
            Uri url = new Uri(RootUrl + $"api/student/{id}");
            string body = JsonConvert.SerializeObject(student);
            var response = HttpClientHelper.Request(url, HttpMethod.Put, body);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Create(Student student) {
            Uri url = new Uri(RootUrl + "api/student");

            string body = JsonConvert.SerializeObject(student);
            HttpClientHelper.Request(url, HttpMethod.Post, body);

            return RedirectToAction("Index");
        }
    }
}