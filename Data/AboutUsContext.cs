using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class AboutUsContext : DbContext
    {
        public AboutUsContext(DbContextOptions<AboutUsContext> options)
            : base(options)
        {
        }

        public DbSet<project.Models.AboutUs> AboutUs { get; set; }
    }
}
