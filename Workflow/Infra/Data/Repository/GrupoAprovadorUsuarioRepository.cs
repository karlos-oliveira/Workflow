using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;
using Workflow.Shared;

namespace Workflow.Infra.Data.Repository
{

    public class GrupoAprovadorUsuarioRepository : IGrupoAprovadorUsuarioRepository
    {
        private readonly IContext _context;

        public GrupoAprovadorUsuarioRepository(IContext context)
        {
            _context = context;
        }

        public GrupoAprovadorUsuario ConsultarGrupoAprovadorUsuario(Guid IdGrupoAprovadorUsuario)
        {
            return _context.GrupoAprovadorUsuario.Where(x => x.IdGrupoAprovadorUsuario == IdGrupoAprovadorUsuario).First();
        }

        public List<GrupoAprovadorUsuario> ConsultarGrupoAprovadorUsuarios()
        {
            return _context.GrupoAprovadorUsuario.ToList();
        }

        public List<GrupoAprovadorUsuario> ConsultarGrupoAprovadorUsuarios(Guid IdGrupoAprovador)
        {
            return _context.GrupoAprovadorUsuario.Where(x => x.IdGrupoAprovador == IdGrupoAprovador).ToList();
        }

        public bool IsUsuarioNoGrupo(Guid IdGrupoAprovador, Guid IdUsuario)
        {
            var usrGrp = _context.GrupoAprovadorUsuario.Where(x => x.IdGrupoAprovador == IdGrupoAprovador
                                                          && x.IdUsuario == IdUsuario).ToList();
            return (usrGrp.Count > 0);
        }

        public void CriarGrupoAprovadorUsuario(GrupoAprovadorUsuario inputs)
        {
            _context.GrupoAprovadorUsuario.Add(inputs);
            _context.Commit();
        }

        public void DeletarGrupoAprovadorUsuario(Guid IdGrupoAprovadorUsuario)
        {
            _context.GrupoAprovadorUsuario.Remove(_context.GrupoAprovadorUsuario.Find(IdGrupoAprovadorUsuario));
            _context.Commit();
        }

        public void EditarGrupoAprovadorUsuario(GrupoAprovadorUsuario inputs)
        {
            _context.GrupoAprovadorUsuario.Update(inputs);
            _context.Commit();
        }
    }

}
