using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Services
{

    public interface IGrupoAprovadorUsuarioService
    {
        void CriarGrupoAprovadorUsuario(GrupoAprovadorUsuario inputs);
        GrupoAprovadorUsuario ConsultarGrupoAprovadorUsuario(Guid IdGrupoAprovadorUsuario);
        List<GrupoAprovadorUsuario> ConsultarGrupoAprovadorUsuarios();
        bool IsUsuarioNoGrupo(Guid IdGrupoAprovador, Guid IdUsuario);
        List<GrupoAprovadorUsuario> ConsultarGrupoAprovadorUsuarios(Guid IdGrupoAprovador);
        void EditarGrupoAprovadorUsuario(GrupoAprovadorUsuario inputs);
        void DeletarGrupoAprovadorUsuario(Guid IdGrupoAprovadorUsuario);
    }

}
