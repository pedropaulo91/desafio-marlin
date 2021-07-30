using DesafioMarlin.Domain.Entities;

namespace DesafioMarlin.Service.Interfaces
{
    public interface ITokenService
    {
         string GenerateToken(Usuario usuario);
    }
}
