using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    class DbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            ApplicationDbContext appConfig = new ApplicationDbContext();
            var opsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            opsBuilder.UseSqlServer(appConfig.sqlConnectionString);
            return new AppDbContext(opsBuilder.Options);
        }
    }
}
