using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HiringDev.Dominio.Model;
using Microsoft.EntityFrameworkCore;

namespace HiringDev.Infra.Contexto
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {

        }
        public DatabaseContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<BuscaVideos> BuscaVideos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies(false);
        }
    }
}
