using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Configurations
{

    public class StatusConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.ToTable("Status");

            builder.Property(x => x.IdStatus).IsRequired();
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.IsAtivo).HasDefaultValue(true).IsRequired();
            builder.Property(x => x.BloqueiaAndamento).HasDefaultValue(false).IsRequired();

            builder.HasKey(x => x.IdStatus);
        }
    }
}
