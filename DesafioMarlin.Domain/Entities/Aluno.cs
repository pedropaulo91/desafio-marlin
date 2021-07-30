using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DesafioMarlin.Domain.Entities
{
    public class Aluno: BaseEntity
    {
        public uint Matricula { get; set; }
        public string Nome { get; set; }
        public List<Turma> Turmas { get; set; }
    }
}
