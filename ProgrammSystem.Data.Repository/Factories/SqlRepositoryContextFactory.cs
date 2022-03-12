using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ProgramSystem.Data.Repository.Factories
{
    public class SqlRepositoryContextFactory : IRepositoryContextFactory
    {
        public RepositoryContext Create()
        {
            string connectionString = "Data Source = rpkDB.db";

            var optionsBuilder = new DbContextOptionsBuilder<RepositoryContext>();
            optionsBuilder.UseSqlite(connectionString);
            optionsBuilder.LogTo(Console.WriteLine);
            optionsBuilder.EnableSensitiveDataLogging();

            return new RepositoryContext(optionsBuilder.Options);
        }
    }
}
