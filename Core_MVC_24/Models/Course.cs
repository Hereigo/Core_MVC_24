using System.ComponentModel.DataAnnotations.Schema;

namespace Core_MVC_24.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CourseID { get; set; }

        public string Title { get; set; }
        
        public int Credits { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
