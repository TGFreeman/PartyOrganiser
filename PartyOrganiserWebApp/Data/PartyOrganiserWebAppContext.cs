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

        public DbSet<PartyOrganiserWebApp.Models.Party> Party { get; set; } = default!;
    }
}
