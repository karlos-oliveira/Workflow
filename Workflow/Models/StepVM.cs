using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class StepVM : Step
    {
        public StepVM() { }
        public StepVM(Step inputs)
        {
            this.IdStep = inputs.IdStep;
            this.IdGrupoAprovador = inputs.IdGrupoAprovador;
            this.Descricao = inputs.Descricao;
            this.Nome = inputs.Nome;
            this.IsAtivo = inputs.IsAtivo;
        }
        public GrupoAprovadorVM GrupoAprovador { get; set; }
    }
}
