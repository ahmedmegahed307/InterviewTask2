using AFS_.NET_Developer_Test.Models;
using Microsoft.EntityFrameworkCore;

namespace AFS_.NET_Developer_Test.InfraStructure
{
    public class ProjectContext : DbContext
    {

        public ProjectContext(DbContextOptions<ProjectContext> options)
           : base(options)
        {
        }
        public ProjectContext()
        {

        }

        public DbSet<Contents> Contents { get; set; }

    }
}
