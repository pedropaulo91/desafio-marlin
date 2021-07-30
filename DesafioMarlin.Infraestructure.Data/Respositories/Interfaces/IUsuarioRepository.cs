using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Domain.Interfaces;
using System.Threading.Tasks;

namespace DesafioMarlin.Infraestructure.Data.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuario(Usuario usuario);
    }
}