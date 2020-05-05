using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Models
{
    public class GrupoAprovadorUsuario
    {
        public Guid IdGrupoAprovadorUsuario { get; set; }
        public Guid IdGrupoAprovador { get; set; }
        public Guid IdUsuario { get; set; }
    }
}
