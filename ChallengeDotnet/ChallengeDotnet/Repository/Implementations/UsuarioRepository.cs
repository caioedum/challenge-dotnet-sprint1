using ChallengeDotnet.Data;
using ChallengeDotnet.Dtos;
using ChallengeDotnet.Models;
using ChallengeDotnet.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ChallengeDotnet.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioFactory
    {
        private readonly dbContext _context;
        public UsuarioRepository(dbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> GetUsuarioById(int UsuarioId)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == UsuarioId);
        }

        public async Task<Usuario> CreateUsuario(UsuarioDto usuario)
        {
            var getUsuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == usuario.Email);
            if (getUsuario == null)
            {
                Usuario novoUsuario = new Usuario
                {
                    CPF = usuario.CPF,
                    Nome = usuario.Nome,
                    Sobrenome = usuario.Sobrenome,
                    Email = usuario.Email,
                    Senha = usuario.Senha,
                    DataNascimento = usuario.DataNascimento,
                    Genero = usuario.Genero,
                    DataCadastro = usuario.DataCadastro
                };
                _context.Usuarios.Add(novoUsuario);
                await _context.SaveChangesAsync();
                return novoUsuario;
            }
            return null;
        }

        public async Task<Usuario> UpdateUsuario(UsuarioChangeDataDto usuario)
        {
            var getUsuario = await _context.Usuarios.FindAsync(usuario.Email);
            if (getUsuario != null)
            {
                getUsuario.CPF = usuario.CPF;
                getUsuario.Nome = usuario.Nome;
                getUsuario.Sobrenome = usuario.Sobrenome;
                getUsuario.Email = usuario.Email;
                getUsuario.Senha = usuario.Senha;
                getUsuario.DataNascimento = usuario.DataNascimento;
                getUsuario.Genero = usuario.Genero;
                getUsuario.DataNascimento = usuario.DataNascimento;

                _context.Usuarios.Update(getUsuario);
                await _context.SaveChangesAsync();
                return getUsuario;
            }
            return null;
        }
    }
}
