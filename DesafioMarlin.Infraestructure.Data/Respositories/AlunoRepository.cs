using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Infraestructure.Data.Context;
using DesafioMarlin.Infraestructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Infraestructure.Data.Respositories
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly SqlServerContext _context;

        public AlunoRepository(SqlServerContext context)
        {
            _context = context;
        }
        public async Task<List<Aluno>> Get() => await _context.Alunos.AsNoTracking().ToListAsync();

        public async Task<Aluno> GetAlunoByMatricula(int matricula) => await _context.Alunos.AsNoTracking()
            .Where(aluno => aluno.Matricula == matricula)
            .FirstOrDefaultAsync();


        public async Task Insert(Aluno obj)
        {
            _context.Alunos.Add(obj);
            await _context.SaveChangesAsync(); ;
        }
        public async Task Update(Aluno obj)
        {
            _context.Entry<Aluno>(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Aluno obj)
        {
            _context.Entry<Aluno>(obj).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
