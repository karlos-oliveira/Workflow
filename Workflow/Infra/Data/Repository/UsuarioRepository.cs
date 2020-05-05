using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;
using Workflow.Shared;

namespace Workflow.Infra.Data.Repository
{

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IContext _context;

        public UsuarioRepository(IContext context)
        {
            _context = context;
        }

        public Usuario ConsultarUsuario(Guid IdUsuario)
        {
            return _context.Usuario.Where(x => x.IdUsuario == IdUsuario).First();
        }

        public List<Usuario> ConsultarUsuarios(Guid IdConta)
        {
            return _context.Usuario.Where(x => x.IsAtivo && x.IdConta == IdConta).ToList();
        }

        public void CriarUsuario(Usuario inputs)
        {
            _context.Usuario.Add(inputs);
            _context.Commit();
        }

        public void DeletarUsuario(Guid IdUsuario)
        {
            var usr = _context.Usuario.Find(IdUsuario);

            if (usr == null)
                throw new Exception("Usuário não encontrado");

            usr.IsAtivo = false;
            _context.Commit();
        }

        public void EditarUsuario(Usuario inputs)
        {
            _context.Usuario.Update(inputs);
            _context.Commit();
        }
    }

}
