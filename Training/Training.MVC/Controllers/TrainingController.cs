using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Web.Mvc;

namespace Mvc.Controllers {
    public class TrainingController : Controller {
        private string RootUrl { get; set; }

        public TrainingController() {
            RootUrl = ConfigurationManager.AppSettings["api:url"];
        }

        public ActionResult Index() {
            List<Course> retVal = new List<Course>();

            Uri url = new Uri(RootUrl + "api/training");

            var response = HttpClientHelper.Request(url, HttpMethod.Get);
            retVal = JsonConvert.DeserializeObject<List<Course>>(response, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });

            return View(retVal);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Course course) {
            Uri url = new Uri(RootUrl + "api/training");

            string body = JsonConvert.SerializeObject(course);
            HttpClientHelper.Request(url, HttpMethod.Post, body);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id) {
            Course retVal = new Course();
            Uri url = new Uri(RootUrl + $"api/training/{id}");
            var response = HttpClientHelper.Request(url, HttpMethod.Get);

            retVal = JsonConvert.DeserializeObject<Course>(response, new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore
            });

            return View(retVal);
        }

        [HttpPost]
        public ActionResult Edit(int id, Course student) {

            Uri url = new Uri(RootUrl + $"api/training/{id}");
            string body = JsonConvert.SerializeObject(student);
            var response = HttpClientHelper.Request(url, HttpMethod.Put, body);
            return RedirectToAction("Index");
        }
    }
}