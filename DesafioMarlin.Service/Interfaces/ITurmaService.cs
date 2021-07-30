using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Domain.Interfaces;
using System.Threading.Tasks;

namespace DesafioMarlin.Service.Interfaces
{
    public interface ITurmaService: IBaseService<Turma>
    {
        Task<Turma> GetTurmaByNumero(int numero);
        Task<bool> HasAlunos(Turma obj);
        Task<bool> HasLessThanFiveAlunos(Turma obj);
    }
}
