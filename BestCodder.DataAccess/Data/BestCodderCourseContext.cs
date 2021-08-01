using Microsoft.EntityFrameworkCore;

namespace BestCodder.DataAccess.Data
{
    public class BestCodderCourseContext : DbContext
    {
        public BestCodderCourseContext(DbContextOptions<BestCodderCourseContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}
