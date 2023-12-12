using System.ComponentModel.DataAnnotations;

namespace blazor_task_random.Models
{
    public class Class
    {
        [Key]
        public int Cid { get; set; }
        public string? Name { get; set; }
        public string? RoomNumber { get; set; }
        public int Fid { get; set; }
    }
}
