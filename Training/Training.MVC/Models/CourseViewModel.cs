using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models {
    public class CourseViewModel : Course {

        [Display(Name="Name training"), Required]
        public override string Name { get => base.Name; set => base.Name = value; }
    }
}