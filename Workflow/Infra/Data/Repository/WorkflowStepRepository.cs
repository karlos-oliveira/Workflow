using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;
using Workflow.Shared;

namespace Workflow.Infra.Data.Repository
{

    public class WorkflowStepRepository : IWorkflowStepRepository
    {
        private readonly IContext _context;

        public WorkflowStepRepository(IContext context)
        {
            _context = context;
        }

        public List<WorkflowStep> ConsultarStepsPorWorkflow(Guid IdWorkflow)
        {
            return _context.WorkflowStep.Where(x => x.IdWorkflow == IdWorkflow).ToList();
        }

        public WorkflowStep ConsultarWorkflowStep(Guid IdWorkflowStep)
        {
            return _context.WorkflowStep.Where(x => x.IdWorkflowStep == IdWorkflowStep).First();
        }

        public WorkflowStep ConsultarWorkflowStep(Guid IdWorkflow, Guid IdStep)
        {
            return _context.WorkflowStep.Where(x => x.IdWorkflow == IdWorkflow 
                                                 && x.IdStep == IdStep).First();
        }

        public List<WorkflowStep> ConsultarWorkflowSteps()
        {
            return _context.WorkflowStep.ToList();
        }

        public void CriarWorkflowStep(WorkflowStep inputs)
        {
            _context.WorkflowStep.Add(inputs);
            _context.Commit();
        }

        public void DeletarWorkflowStep(Guid IdWorkflowStep)
        {
            _context.WorkflowStep.Remove(_context.WorkflowStep.Find(IdWorkflowStep));
            _context.Commit();
        }

        public void EditarWorkflowStep(WorkflowStep inputs)
        {
            _context.WorkflowStep.Update(inputs);
            _context.Commit();
        }
    }

}
