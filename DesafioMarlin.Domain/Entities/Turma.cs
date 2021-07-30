using System.Collections.Generic;

namespace DesafioMarlin.Domain.Entities
{
    public class Turma: BaseEntity
    {
        public int Numero { get; set; }
        public List<Aluno> Alunos { get; set; }

    }
}
