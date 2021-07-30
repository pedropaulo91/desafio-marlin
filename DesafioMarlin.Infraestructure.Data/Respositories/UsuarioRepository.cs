using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Infraestructure.Data.Context;
using DesafioMarlin.Infraestructure.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMarlin.Infraestructure.Data.Respositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly SqlServerContext _context;

        public UsuarioRepository(SqlServerContext context)
        {
            _context = context;
        }
        
        public async Task<Usuario> GetUsuario(Usuario usuario) => await _context.Usuarios.AsNoTracking()
                .Where(u => u.Username.ToLower().Equals(usuario.Username.ToLower()) && u.Password.Equals(usuario.Password))
                .FirstOrDefaultAsync();


    }
}
