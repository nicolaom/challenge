using challenge.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Data
{
    public class ChallengeContext :DbContext
    {
        public ChallengeContext (DbContextOptions<ChallengeContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Despesa>()
                .HasOne(despesa => despesa.Categoria)
                .WithMany(categoria => categoria.Despesas)
                .HasForeignKey(despesa => despesa.IdCategoria);

            builder.Entity<Receita>()
                .HasOne(receita => receita.Categoria)
                .WithMany(categoria => categoria.Receitas)
                .HasForeignKey(receita => receita.IdCategoria);
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
    }
}
