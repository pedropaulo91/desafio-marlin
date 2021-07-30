using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Infraestructure.Data.Interfaces;
using DesafioMarlin.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioMarlin.Services
{
    public class AlunoService : IAlunoService
    {
        private readonly IAlunoRepository _repository;

        public AlunoService(IAlunoRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Aluno>> Get() => await _repository.Get();

        public async Task<Aluno> GetAlunoByMatricula(int matricula) => await _repository.GetAlunoByMatricula(matricula);

        public async Task Insert(Aluno obj) => await _repository.Insert(obj);

        public async Task Update(Aluno obj) => await _repository.Update(obj);
        
        public async Task Delete(Aluno obj) => await _repository.Delete(obj);

        

    }
}
