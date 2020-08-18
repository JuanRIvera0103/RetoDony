using RetoDony.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RetoDony.Models.DAL
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext():base("cn")
        {
        }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Cargo> Cargo { get; set; }
    }
}