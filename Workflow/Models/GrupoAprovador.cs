using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class GrupoAprovador
    {
        public Guid IdGrupoAprovador { get; set; }
        public Guid IdConta { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public bool IsAtivo { get; set; }
    }
}
