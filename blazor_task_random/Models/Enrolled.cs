using System.ComponentModel.DataAnnotations;

namespace blazor_task_random.Models
{
    public class Enrolled
    {
        [Key]
        public int Id { get; set; }
        public int Sid { get; set; }
        public int Cid { get; set; }
    }
}
