using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace OwnedTypesEquals.Nothing
{
    public class DataContextCreator
    {
        private readonly DbContextOptions<DataContext> _options;

        public DataContextCreator()
        {
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseInMemoryDatabase(Guid.NewGuid().ToString()).UseInternalServiceProvider(serviceProvider);

            _options = optionsBuilder.Options;

            using (var context = CreateContext())
            {
                context.Database.EnsureCreated();
                context.SaveChanges();
            }
        }

        public DataContext CreateContext()
        {
            return new DataContext(_options);
        }
    }
}