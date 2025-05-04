using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MBAModulo1.Core.Data;

namespace MBAModulo1.Core.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            
            var connectionString = "Data Source=app.db"; 

            optionsBuilder.UseSqlite(connectionString); 

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
