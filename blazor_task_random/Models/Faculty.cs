using System.ComponentModel.DataAnnotations;

namespace blazor_task_random.Models
{
    public class Faculty
    {
        [Key]
        public int Fid { get; set; }
        public string? Fname { get; set; }
        public int Deptid { get; set; }
        public int Standing { get; set; }
    }
}
