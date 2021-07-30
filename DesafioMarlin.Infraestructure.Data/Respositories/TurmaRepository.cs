using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Infraestructure.Data.Context;
using DesafioMarlin.Infraestructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Infraestructure.Data.Respositories
{
    public class TurmaRepository : ITurmaRepository
    {
        private readonly SqlServerContext _context;

        public TurmaRepository(SqlServerContext context)
        {
            _context = context;
        }

        public async Task<List<Turma>> Get() => await _context.Turmas.AsNoTracking().ToListAsync();

        public async Task<Turma> GetTurmaByNumero(int numero) => await _context.Turmas.AsNoTracking()
            .Where(turma => turma.Numero == numero)
            .FirstOrDefaultAsync();

        public async Task Insert(Turma obj)
        {
            _context.Turmas.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Turma obj)
        {
            _context.Entry<Turma>(obj).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Turma obj)
        {
            _context.Entry<Turma>(obj).State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

    }
}
