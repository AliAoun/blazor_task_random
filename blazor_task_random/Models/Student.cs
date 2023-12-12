using System.ComponentModel.DataAnnotations;

namespace blazor_task_random.Models
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }
        public string? Sname { get; set; }
        public string? Major { get; set; }
       
        public int Standing { get; set; }
        public decimal Age { get; internal set; }
    }
}
