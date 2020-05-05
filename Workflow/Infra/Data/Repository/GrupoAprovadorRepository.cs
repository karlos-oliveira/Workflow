using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;
using Workflow.Shared;

namespace Workflow.Infra.Data.Repository
{

    public class GrupoAprovadorRepository : IGrupoAprovadorRepository
    {
        private readonly IContext _context;

        public GrupoAprovadorRepository(IContext context)
        {
            _context = context;
        }

        public GrupoAprovador ConsultarGrupoAprovador(Guid IdGrupoAprovador)
        {
            var ga = _context.GrupoAprovador.Where(x => x.IdGrupoAprovador == IdGrupoAprovador).ToList();

            if (ga.Count > 0)
                return ga.First();
                
            throw new Exception("Grupo Aprovador não encontrado");
        }

        public List<GrupoAprovador> ConsultarGrupoAprovadores(Guid IdConta)
        {
            return _context.GrupoAprovador.Where(x => x.IsAtivo && x.IdConta == IdConta).ToList();
        }

        public void CriarGrupoAprovador(GrupoAprovador inputs)
        {
            _context.GrupoAprovador.Add(inputs);
            _context.Commit();
        }

        public void DeletarGrupoAprovador(Guid IdGrupoAprovador)
        {
            var ga = _context.GrupoAprovador.Find(IdGrupoAprovador);

            if (ga == null)
                throw new Exception("Grupo Aprovador não encontrado");
            
            ga.IsAtivo = false;
            _context.Commit();
        }

        public void EditarGrupoAprovador(GrupoAprovador inputs)
        {
            _context.GrupoAprovador.Update(inputs);
            _context.Commit();
        }
    }

}
