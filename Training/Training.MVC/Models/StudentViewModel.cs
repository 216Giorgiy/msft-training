using Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc.Models {
    public class StudentViewModel : Student {

        [Display(Name="Name student"), Required]
        public override string Name { get => base.Name; set => base.Name = value; }
    }
}