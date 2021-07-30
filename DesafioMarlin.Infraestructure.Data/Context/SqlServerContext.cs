using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Infraestructure.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DesafioMarlin.Infraestructure.Data.Context
{
    public class SqlServerContext: DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options): base(options)
        {

        }


        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new AlunoMap());
        }


    }
}
