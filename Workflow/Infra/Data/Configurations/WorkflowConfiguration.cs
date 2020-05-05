using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Workflow.Infra.Data.Configurations
{

    public class WorkflowConfiguration : IEntityTypeConfiguration<Models.Workflow>
    {
        public void Configure(EntityTypeBuilder<Models.Workflow> builder)
        {
            builder.ToTable("Workflow");

            builder.Property(x => x.IdWorkflow).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descricao);
            builder.Property(x => x.IdConta).IsRequired();
            builder.Property(x => x.IsAtivo).HasDefaultValue(true).IsRequired();
            builder.Property(x => x.IsModelo).HasDefaultValue(false).IsRequired();

            builder.HasKey(x => x.IdWorkflow);
        }
    }
}
