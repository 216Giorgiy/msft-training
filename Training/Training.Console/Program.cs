using Data;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Training {
    class Program {
        static void Main(string[] args) {

            //TrainingContext context = new TrainingContext();
            //var retVal = context.Courses.Add(new Course() { Name = ".Net Core Advanced" });

            HttpClient client = new HttpClient();
            Course course = new Course() { Name = "test console" };
            StringContent content = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");

            client.PostAsync("https://localhost:44397/api/training", content);

            Console.ReadKey();

        }
    }
}
