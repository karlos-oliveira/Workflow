using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Repository
{

    public interface IGrupoAprovadorRepository
    {
        void CriarGrupoAprovador(GrupoAprovador inputs);
        GrupoAprovador ConsultarGrupoAprovador(Guid IdGrupoAprovador);
        List<GrupoAprovador> ConsultarGrupoAprovadores(Guid IdConta);
        void EditarGrupoAprovador(GrupoAprovador inputs);
        void DeletarGrupoAprovador(Guid IdGrupoAprovador);
    }

}
