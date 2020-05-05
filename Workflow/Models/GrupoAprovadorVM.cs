using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class GrupoAprovadorVM : GrupoAprovador
    {
        public GrupoAprovadorVM()
        {
            this.Aprovadores = new List<Usuario>();
        }

        public GrupoAprovadorVM(GrupoAprovador inputs)
        {
            this.IdGrupoAprovador = inputs.IdGrupoAprovador;
            this.Descricao = inputs.Descricao;
            this.IsAtivo = inputs.IsAtivo;
            this.Nome = inputs.Nome;
            this.Aprovadores = new List<Usuario>();
        }
        public List<Usuario> Aprovadores { get; set; }
    }
}
