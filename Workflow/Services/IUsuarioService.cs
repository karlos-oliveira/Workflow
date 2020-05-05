using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Services
{

    public interface IUsuarioService
    {
        void CriarUsuario(Usuario inputs);
        Usuario ConsultarUsuario(Guid IdUsuario);
        List<Usuario> ConsultarUsuarios(Guid IdConta);
        void EditarUsuario(Usuario inputs);
        void DeletarUsuario(Guid IdUsuario);
    }

}
