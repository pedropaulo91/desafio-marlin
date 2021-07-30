using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Domain.Interfaces;
using System.Threading.Tasks;

namespace DesafioMarlin.Service.Interfaces
{
    public interface IAlunoService: IBaseService<Aluno>
    {
        Task<Aluno> GetAlunoByMatricula(int matricula);
 
    }
}
