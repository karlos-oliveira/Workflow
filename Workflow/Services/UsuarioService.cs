using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Infra.Data.Repository;
using Workflow.Models;

namespace Workflow.Services
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _repo;

        public UsuarioService(IUsuarioRepository repo)
        {
            _repo = repo;
        }

        public Usuario ConsultarUsuario(Guid IdUsuario)
        {
            return _repo.ConsultarUsuario(IdUsuario);
        }

        public List<Usuario> ConsultarUsuarios(Guid IdConta)
        {
            return _repo.ConsultarUsuarios(IdConta);
        }

        public void CriarUsuario(Usuario inputs)
        {
            inputs.IdUsuario = Guid.NewGuid();

            _repo.CriarUsuario(inputs);
        }

        public void DeletarUsuario(Guid IdUsuario)
        {
            _repo.DeletarUsuario(IdUsuario);
        }

        public void EditarUsuario(Usuario inputs)
        {
            _repo.EditarUsuario(inputs);
        }
    }

}
