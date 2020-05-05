using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Configurations
{

    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.ToTable("Step");

            builder.Property(x => x.IdStep).IsRequired();
            builder.Property(x => x.IdGrupoAprovador).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descricao);
            builder.Property(x => x.IdConta).IsRequired();
            builder.Property(x => x.IsAtivo).HasDefaultValue(true).IsRequired();

            builder.HasKey(x => x.IdStep);
        }
    }
}
