using ChallengeDotnet.Dtos;
using ChallengeDotnet.Models;

namespace ChallengeDotnet.Repository.Interfaces
{
    public interface IUsuarioFactory
    {
        Task<Usuario> GetUsuarioById(int UsuarioId);
        Task<Usuario> CreateUsuario(UsuarioDto usuario);
        Task<Usuario> UpdateUsuario(UsuarioChangeDataDto usuario);
    }
}
