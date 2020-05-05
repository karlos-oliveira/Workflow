using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Shared;

namespace Workflow.Infra.Data.Repository
{

    public class WorkflowRepository : IWorkflowRepository
    {
        private readonly IContext _context;

        public WorkflowRepository(IContext context)
        {
            _context = context;
        }

        public Models.Workflow ConsultarWorkflow(Guid IdWorkflow)
        {
            return _context.Workflow.Where(x => x.IdWorkflow == IdWorkflow).First();
        }

        public List<Models.Workflow> ConsultarWorkflows(Guid IdConta)
        {
            return _context.Workflow.Where(x => x.IsAtivo && x.IdConta == IdConta).ToList();
        }

        public List<Models.Workflow> ConsultarWorkflowsModelo(Guid IdConta)
        {
            return _context.Workflow.Where(x => x.IsAtivo && x.IsModelo && x.IdConta == IdConta).ToList();
        }

        public void CriarWorkflow(Models.Workflow inputs)
        {
            _context.Workflow.Add(inputs);
            _context.Commit();
        }

        public void DeletarWorkflow(Guid IdWorkflow)
        {
            _context.Workflow.Find(IdWorkflow).IsAtivo = false;
            _context.Commit();
        }

        public void EditarWorkflow(Models.Workflow inputs)
        {
            _context.Workflow.Update(inputs);
            _context.Commit();
        }
    }

}
