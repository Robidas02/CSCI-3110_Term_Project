using CSCI_3110_Term_Project.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace CSCI_3110_Term_Project.Services
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Teams> Teams => Set<Teams>();
        public DbSet<Pokemon> Pokemon => Set<Pokemon>();
        public DbSet<Moves> Moves => Set<Moves>();
        public DbSet<Items> Items => Set<Items>();
        public DbSet<Abilities> Abilities => Set<Abilities>();
        public DbSet<PokemonInstance> PokemonInstance => Set<PokemonInstance>();
    }

}
