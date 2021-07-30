using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioMarlin.Infraestructure.Data.Interfaces
{
    public interface ITurmaRepository: IBaseRepository<Turma>
    {
        Task<Turma> GetTurmaByNumero(int numero); 
    }
}