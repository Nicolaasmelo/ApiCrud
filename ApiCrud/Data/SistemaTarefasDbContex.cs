using ApiCrud.Data.Map;
using ApiCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Data
{
    public class SistemaTarefasDbContex : DbContext
    {
        public SistemaTarefasDbContex(DbContextOptions<SistemaTarefasDbContex> options)
            :base(options) 
        {

        }


        public DbSet<UsuarioModels> Usuarios { get; set; }
        
        //public DbSet<TarefaModels> Tarefa { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
