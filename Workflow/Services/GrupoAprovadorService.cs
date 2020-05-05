using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Infra.Data.Repository;
using Workflow.Models;

namespace Workflow.Services
{

    public class GrupoAprovadorService : IGrupoAprovadorService
    {
        private readonly IGrupoAprovadorRepository _repo;
        public GrupoAprovadorService(IGrupoAprovadorRepository repo)
        {
            _repo = repo;
        }

        public GrupoAprovador ConsultarGrupoAprovador(Guid IdGrupoAprovador)
        {
            return _repo.ConsultarGrupoAprovador(IdGrupoAprovador);
        }

        public List<GrupoAprovador> ConsultarGrupoAprovadores(Guid IdConta)
        {
            return _repo.ConsultarGrupoAprovadores(IdConta);
        }

        public void CriarGrupoAprovador(GrupoAprovador inputs)
        {
            inputs.IdGrupoAprovador = Guid.NewGuid();

            _repo.CriarGrupoAprovador(inputs);
        }

        public void DeletarGrupoAprovador(Guid IdGrupoAprovador)
        {
            _repo.DeletarGrupoAprovador(IdGrupoAprovador);
        }

        public void EditarGrupoAprovador(GrupoAprovador inputs)
        {
            _repo.EditarGrupoAprovador(inputs);
        }
    }

}
