using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project.Models;

namespace project.Data
{
    public class RoomContext : DbContext
    {
        public RoomContext (DbContextOptions<RoomContext> options)
            : base(options)
        {
        }

        public DbSet<project.Models.Room> Room { get; set; }
    }
}
