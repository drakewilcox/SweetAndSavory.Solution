using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SweetAndSavory.Models
{
  public class DrakeWilcoxContextFactory : IDesignTimeDbContextFactory<DrakeWilcoxContext>
  {
    DrakeWilcoxContext IDesignTimeDbContextFactory<DrakeWilcoxContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<DrakeWilcoxContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new DrakeWilcoxContext(builder.Options);
    }
  }
}