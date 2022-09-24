using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PartyOrganiserWebApp.Models;

namespace PartyOrganiserWebApp.Data
{
    public class PartyOrganiserWebAppContext : DbContext
    {
        public PartyOrganiserWebAppContext (DbContextOptions<PartyOrganiserWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<PartyOrganiserWebApp.Models.Party> Parties { get; set; } = default!;
        public DbSet<PartyOrganiserWebApp.Models.Drink> Drinks { get; set; } = default!;
        public DbSet<PartyOrganiserWebApp.Models.Person> People { get; set; } = default!;
        public DbSet<PartyOrganiserWebApp.Models.Attendance> Attendances { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
           
    }
    }
}
