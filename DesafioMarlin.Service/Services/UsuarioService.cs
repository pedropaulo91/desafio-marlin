using DesafioMarlin.Domain.Entities;
using DesafioMarlin.Infraestructure.Data.Interfaces;
using DesafioMarlin.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DesafioMarlin.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> GetUsuario(Usuario usuario) => await _repository.GetUsuario(usuario);

        public Task Delete(Usuario obj)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<Usuario>> Get()
        {
            throw new System.NotImplementedException();
        }


        public Task Insert(Usuario obj)
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Usuario obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
