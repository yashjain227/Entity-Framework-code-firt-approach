using Microsoft.EntityFrameworkCore;

namespace codefirst.Models
{
    public class StudentDbContext :DbContext
    {

        public StudentDbContext(DbContextOptions option) :base(option)
        {

        }
        public DbSet<Student>Students { get; set; }

    }
}
