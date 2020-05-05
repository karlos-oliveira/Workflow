using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class Step
    {
        public Guid IdStep { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Guid IdGrupoAprovador { get; set; }
        public Guid IdConta { get; set; }
        public bool IsAtivo { get; set; }
    }
}
