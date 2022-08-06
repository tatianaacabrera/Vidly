using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidly.Models;

namespace Vidly.Data
{
    public class VidlyContext : DbContext
    {
        public VidlyContext (DbContextOptions<VidlyContext> options)
            : base(options)
        {
        }

        public DbSet<Vidly.Models.Customer> Customer { get; set; } = default!;

        public DbSet<Vidly.Models.Movie>? Movie { get; set; }
        public DbSet<Vidly.Models.MembershipType>? MembershipType { get; set; }
        public DbSet<Vidly.Models.Genre>? Genre { get; set; }


    }
}
