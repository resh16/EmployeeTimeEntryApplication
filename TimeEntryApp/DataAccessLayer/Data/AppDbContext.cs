using BusinessObjectLayer.Models;
using DataAccessLayer.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Break> Breaks { get; set; }
        public virtual DbSet<TimeEntry> Entries { get; set; }
        public virtual DbSet<ApplicationUser> user { get; set; }
    }
}
