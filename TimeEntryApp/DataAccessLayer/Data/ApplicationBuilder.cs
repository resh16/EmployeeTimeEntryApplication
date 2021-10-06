using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Data
{
    class ApplicationDbContext
    {
        public ApplicationDbContext() 
        {
            var configBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(),"appsettings.json");
            configBuilder.AddJsonFile(path, false);
            var root = configBuilder.Build();
            var appSetting = root.GetSection("ConnectionStrings:DefaultConnection");
            sqlConnectionString = appSetting.Value;
        }   

        public string sqlConnectionString { get; set; }
    }
}
