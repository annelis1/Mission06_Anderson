using Microsoft.EntityFrameworkCore;

namespace Mission06_Anderson.Models
{
    public class MovieSubmissionContext : DbContext
    {
        public MovieSubmissionContext(DbContextOptions<MovieSubmissionContext> options) : base(options) 
        { 
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
        
    }
}
