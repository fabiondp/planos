using Api.Data.Mapping;
using Api.Domain.Entities;
using Data.Mapping;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext: DbContext
    {
        public DbSet<ChaveAPIEntity> Pessoas { get; set; }
        public MyContext (DbContextOptions<MyContext> options): base (options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ChaveAPIEntity>(new ChaveAPIMap().Configure);
            modelBuilder.Entity<PlanoEntity>(new PlanoMap().Configure);
            modelBuilder.Entity<ServicosEntity>(new ServicosMap().Configure);
            modelBuilder.Entity<PlanoServicosEntity>(new PlanoServicosMap().Configure);
            modelBuilder.Entity<PlanoCalculoUnidadesEntity>(new PlanoCalculoUnidadesMap().Configure);
            modelBuilder.Entity<PlanoCalculoFuncionariosEntity>(new PlanoCalculoFuncionariosMap().Configure);
        }

        
    }
}