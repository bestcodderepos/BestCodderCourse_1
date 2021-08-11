using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BestCodder.DataAccess.Data
{
    public class BestCodderCourseContext : IdentityDbContext
    {
        public BestCodderCourseContext(DbContextOptions<BestCodderCourseContext> options)
            : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
    }
}
