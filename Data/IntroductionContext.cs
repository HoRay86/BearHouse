using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class IntroductionContext : DbContext
    {
        public IntroductionContext(DbContextOptions<IntroductionContext> options)
            : base(options)
        {
        }

        public DbSet<project.Models.Introduction> Introduction { get; set; }
    }
}
