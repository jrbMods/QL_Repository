using Microsoft.EntityFrameworkCore;
namespace QL2026_Exam;
public class SchoolContext : DbContext
{
    public DbSet<Student> Students => Set<Student>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=school.db");
    }
}