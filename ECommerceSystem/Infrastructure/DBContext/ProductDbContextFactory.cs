using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.IO;

namespace Infrastructure.DBContext
{
    public class ProductDbContextFactory : IDesignTimeDbContextFactory<productDb>
    {
        public productDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<productDb>();

            // get connection string from Presentation project
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../ECommerceSystem"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
            

            var connectionString = configuration.GetConnectionString("Product");
            optionsBuilder.UseSqlServer(connectionString);

            return new productDb(optionsBuilder.Options);
        }
    }
}
