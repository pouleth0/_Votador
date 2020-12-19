using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AlterdataVotador.Models;

namespace AlterdataVotador.Data
{
    public class AlterdataVotadorContext : DbContext
    {
        public AlterdataVotadorContext (DbContextOptions<AlterdataVotadorContext> options)
            : base(options)
        {
        }

        public DbSet<MelhoriasVotar> MelhoriasVotar { get; set; }

        public DbSet<ModulosVotar> ModulosVotar { get; set; }

        public DbSet<UsuariosAcess> UsuariosAcess { get; set; }

        public DbSet<UsuarioVota> UsuarioVotar { get; set; }

        public DbSet<VotarHome> VotaHome { get; set; }

    }
}
