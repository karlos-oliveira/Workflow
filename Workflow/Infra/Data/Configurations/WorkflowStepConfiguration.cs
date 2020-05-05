using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Configurations
{

    public class WorkflowStepConfiguration : IEntityTypeConfiguration<WorkflowStep>
    {
        public void Configure(EntityTypeBuilder<WorkflowStep> builder)
        {
            builder.ToTable("WorkflowStep");

            builder.Property(x => x.IdWorkflowStep).IsRequired();
            builder.Property(x => x.IdStep).IsRequired();
            builder.Property(x => x.IdStepAnterior);
            builder.Property(x => x.IdStepProximo);
            builder.Property(x => x.IdWorkflow).IsRequired();
            builder.Property(x => x.IdStatus).IsRequired();
            builder.Property(x => x.IdUsuarioAtualizacao);
            builder.Property(x => x.DataAtualizacao);
            builder.Property(x => x.Ordem).IsRequired();
            builder.Property(x => x.IsStepCorrente).HasDefaultValue(false).IsRequired();

            builder.HasKey(x => x.IdWorkflowStep);
        }
    }
}
