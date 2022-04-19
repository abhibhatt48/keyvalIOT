using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class KeyvalueContext : DbContext
    {
        public KeyvalueContext(DbContextOptions options)
            : base(options)
        {
        }
        public DbSet<Keyvalue> KeyItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Keyvalue>().HasData(new Keyvalue
            {
                Key = "temp_word",
                Value = "74"



            }, new Keyvalue
            {
                Key = "temp_art",
                Value = "44"

            });
        }
    }
}
