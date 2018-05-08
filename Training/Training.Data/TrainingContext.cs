using System;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data {
    public partial class TrainingContext : DbContext {

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        public TrainingContext() : base("name=TrainingDatabase") {
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
        }
    }
}
