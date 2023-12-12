using blazor_task_random.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace blazor_task_random.Data
{
    public class myDbContext : DbContext
    {
        public myDbContext(DbContextOptions<myDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Faculty> Faculty { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Enrolled> Enrolled { get; set; }
        public DbSet<Marks> Marks { get; set; }



        // LINQ Query 1
        public IEnumerable<string> GetStudentsWithoutMarks()
        {
            return Students
                .Join(Enrolled,
                      student => student.Sid,
                      enrolled => enrolled.Sid,
                      (student, enrolled) => new { Student = student, Enrolled = enrolled })
                .GroupJoin(Marks,
                            enrollment => enrollment.Enrolled.Id,
                            mark => mark.EnrollmentId,
                            (enrollment, marks) => new { Student = enrollment.Student, Marks = marks })
                .Where(joinResult => joinResult.Marks.All(mark => mark == null))
                .Select(joinResult => joinResult.Student.Sname)
                .ToList();
        }

        // LINQ Query 2
        public IEnumerable<object> GetAverageAgeByMajor()
        {
            return Students
                .GroupBy(student => student.Major)
                .Select(group => new
                {
                    Major = group.Key,
                    AverageAge = group.Average(student => student.Age)
                })
                .ToList();
        }

        // LINQ Query 3
        public IEnumerable<object> GetStudentsEnrolledInMoreThanTwoClasses()
        {
            return Students
                .Join(Enrolled,
                      student => student.Sid,
                      enrolled => enrolled.Sid,
                      (student, enrolled) => new { Student = student, Enrolled = enrolled })
                .GroupBy(joinResult => joinResult.Student.Sname)
                .Where(group => group.Count() > 2)
                .Select(group => new
                {
                    StudentName = group.Key,
                    NumberOfClasses = group.Count()
                })
                .ToList();
        }
    }
}
