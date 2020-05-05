using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Repository
{

    public interface IGrupoAprovadorUsuarioRepository
    {
        void CriarGrupoAprovadorUsuario(GrupoAprovadorUsuario inputs);
        GrupoAprovadorUsuario ConsultarGrupoAprovadorUsuario(Guid IdGrupoAprovadorUsuario);
        List<GrupoAprovadorUsuario> ConsultarGrupoAprovadorUsuarios();
        List<GrupoAprovadorUsuario> ConsultarGrupoAprovadorUsuarios(Guid IdGrupoAprovador);
        bool IsUsuarioNoGrupo(Guid IdGrupoAprovador, Guid IdUsuario);
        void EditarGrupoAprovadorUsuario(GrupoAprovadorUsuario inputs);
        void DeletarGrupoAprovadorUsuario(Guid IdGrupoAprovadorUsuario);
    }

}
