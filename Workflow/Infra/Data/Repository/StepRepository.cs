using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;
using Workflow.Shared;

namespace Workflow.Infra.Data.Repository
{

    public class StepRepository : IStepRepository
    {
        private readonly IContext _context;

        public StepRepository(IContext context)
        {
            _context = context;
        }

        public Step ConsultarStep(Guid IdStep)
        {
            return _context.Step.Where(x => x.IdStep == IdStep).First();
        }

        public List<Step> ConsultarSteps(Guid IdConta)
        {
            return _context.Step.Where(x => x.IsAtivo && x.IdConta == IdConta).ToList();
        }

        public void CriarStep(Step inputs)
        {
            _context.Step.Add(inputs);
            _context.Commit();
        }

        public void DeletarStep(Guid IdStep)
        {
            _context.Step.Find(IdStep).IsAtivo = false;
            _context.Commit();
        }

        public void EditarStep(Step inputs)
        {
            _context.Step.Update(inputs);
            _context.Commit();
        }
    }

}
