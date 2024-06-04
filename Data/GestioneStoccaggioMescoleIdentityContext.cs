using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;
using GestioneStoccaggioMescoleIdentity.Models;

namespace GestioneStoccaggioMescoleIdentity.Data
{
    public class GestioneStoccaggioMescoleIdentityContext : DbContext
    {
        public GestioneStoccaggioMescoleIdentityContext (DbContextOptions<GestioneStoccaggioMescoleIdentityContext> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie.Models.Mescola> Mescola { get; set; } = default!;

        public DbSet<GestioneStoccaggioMescoleIdentity.Models.Cliente> Cliente { get; set; } = default!;
    }
}
