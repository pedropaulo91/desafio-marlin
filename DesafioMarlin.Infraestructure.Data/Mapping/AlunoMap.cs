using DesafioMarlin.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DesafioMarlin.Infraestructure.Data.Mapping
{
    public class AlunoMap : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.HasKey(a => a.Matricula);
            builder.Property(a => a.Nome).IsRequired();
            builder.HasMany(a => a.Turmas)
                .WithMany(t => t.Alunos)
                .UsingEntity(j => j.ToTable("AlunoTurma"));
                    
        }
    }
}
