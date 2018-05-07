using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBProject {
    [Table("tbl_Course")]
    public class Course {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }

        [Display( Name = "Test")]
        public string Name { get; set; }

        public List<Student> Students { get; set; }
    }
}
