using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Configurations
{

    public class GrupoAprovadorConfiguration : IEntityTypeConfiguration<GrupoAprovador>
    {
        public void Configure(EntityTypeBuilder<GrupoAprovador> builder)
        {
            builder.ToTable("GrupoAprovador");

            builder.Property(x => x.IdGrupoAprovador).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Descricao);
            builder.Property(x => x.IdConta).IsRequired();
            builder.Property(x => x.IsAtivo).HasDefaultValue(true).IsRequired();

            builder.HasKey(x => x.IdGrupoAprovador);
        }
    }
}
