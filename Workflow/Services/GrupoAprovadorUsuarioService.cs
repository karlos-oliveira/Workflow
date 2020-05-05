using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Infra.Data.Repository;
using Workflow.Models;

namespace Workflow.Services
{

    public class GrupoAprovadorUsuarioService : IGrupoAprovadorUsuarioService
    {
        private readonly IGrupoAprovadorUsuarioRepository _repo;
        public GrupoAprovadorUsuarioService(IGrupoAprovadorUsuarioRepository repo)
        {
            _repo = repo;
        }

        public GrupoAprovadorUsuario ConsultarGrupoAprovadorUsuario(Guid IdGrupoAprovadorUsuario)
        {
            return _repo.ConsultarGrupoAprovadorUsuario(IdGrupoAprovadorUsuario);
        }

        public List<GrupoAprovadorUsuario> ConsultarGrupoAprovadorUsuarios()
        {
            return _repo.ConsultarGrupoAprovadorUsuarios();
        }

        public List<GrupoAprovadorUsuario> ConsultarGrupoAprovadorUsuarios(Guid IdGrupoAprovador)
        {
            return _repo.ConsultarGrupoAprovadorUsuarios(IdGrupoAprovador);
        }

        public void CriarGrupoAprovadorUsuario(GrupoAprovadorUsuario inputs)
        {
            inputs.IdGrupoAprovadorUsuario = Guid.NewGuid();

            _repo.CriarGrupoAprovadorUsuario(inputs);
        }

        public void DeletarGrupoAprovadorUsuario(Guid IdGrupoAprovadorUsuario)
        {
            _repo.DeletarGrupoAprovadorUsuario(IdGrupoAprovadorUsuario);
        }

        public void EditarGrupoAprovadorUsuario(GrupoAprovadorUsuario inputs)
        {
            _repo.EditarGrupoAprovadorUsuario(inputs);
        }

        public bool IsUsuarioNoGrupo(Guid IdGrupoAprovador, Guid IdUsuario)
        {
            return _repo.IsUsuarioNoGrupo(IdGrupoAprovador, IdUsuario);
        }
    }

}
