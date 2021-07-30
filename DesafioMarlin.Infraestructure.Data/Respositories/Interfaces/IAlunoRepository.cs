using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioMarlin.Infraestructure.Data.Interfaces
{
    public interface IAlunoRepository: IBaseRepository<Aluno>
    {
        Task<Aluno> GetAlunoByMatricula(int matricula);
    }
}