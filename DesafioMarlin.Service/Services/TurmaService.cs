using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Infraestructure.Data.Interfaces;
using DesafioMarlin.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioMarlin.Services
{
    public class TurmaService : ITurmaService
    {
        private readonly ITurmaRepository _repository;

        public TurmaService(ITurmaRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Turma>> Get() => await _repository.Get();

        public async Task<Turma> GetTurmaByNumero(int numero) => await _repository.GetTurmaByNumero(numero);

        public async Task Insert(Turma obj) => await _repository.Insert(obj);

        public async Task Update(Turma obj) => await _repository.Update(obj);

        public async Task Delete(Turma obj) => await _repository.Delete(obj);

        public async Task<bool> HasAlunos(Turma obj)
        {
            Turma turma = await _repository.GetTurmaByNumero(obj.Numero);

            var result = turma.Alunos.Count > 0 ? true : false;

            return result;
        }
        
        public async Task<bool> HasLessThanFiveAlunos(Turma obj)
        {
            Turma turma = await _repository.GetTurmaByNumero(obj.Numero);

            var result = turma.Alunos.Count < 5 ? true : false;

            return result;
        }


    }
}
