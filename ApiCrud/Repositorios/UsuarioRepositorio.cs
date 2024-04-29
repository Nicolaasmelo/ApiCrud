using ApiCrud.Repositorios.Interfaces;
using ApiCrud.Models;
using ApiCrud.Data;
using Microsoft.EntityFrameworkCore;

namespace ApiCrud.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDbContex _dbContex;
        public UsuarioRepositorio(SistemaTarefasDbContex sistemaTarefasDbContex)
        {
            _dbContex = sistemaTarefasDbContex;
        }
        public async Task<UsuarioModels> BuscarPorId(int id)
        {
           return  _dbContex.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<UsuarioModels>> BuscarTodosUsuarios()
        {
            return _dbContex.Usuarios.ToList();
        }
        public async Task<UsuarioModels> Adicionar(UsuarioModels usuario)
        {
           await _dbContex.Usuarios.AddAsync(usuario);
            await _dbContex.SaveChangesAsync();

            return usuario;
        }
        public async Task<UsuarioModels> Atualizar(UsuarioModels usuario, int id)
        {
            UsuarioModels usuarioPorId = await BuscarPorId(id);

            if(usuarioPorId ==null)
            {
                throw new Exception("Usuario não foi encontrado no banco ");
            }
            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbContex.Usuarios.Update(usuarioPorId); ;
            await _dbContex.SaveChangesAsync();
            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModels usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception("Usuario não foi encontrado no banco ");
            }
            _dbContex.Usuarios.Remove(usuarioPorId);
            await _dbContex.SaveChangesAsync();
            return true;
        }

      

        
    }
}
