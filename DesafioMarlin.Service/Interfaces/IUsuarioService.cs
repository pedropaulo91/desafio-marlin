using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Domain.Interfaces;
using System.Threading.Tasks;

namespace DesafioMarlin.Service.Interfaces
{
    public interface IUsuarioService: IBaseService<Usuario>
    {
        Task<Usuario> GetUsuario(Usuario usuario);
    }
}
