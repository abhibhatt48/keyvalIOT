using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace keyvalueIoT.Models
{
    public class KeyValueContext : DbContext
    {
        public KeyValueContext(DbContextOptions<KeyValueContext> options)
            : base(options)
        {
        }

        public DbSet<Keyvalue> KeyItems { get; set; } = null!;
    }
}

