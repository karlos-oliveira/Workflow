using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Configurations
{

    public class GrupoAprovadorUsuarioConfiguration : IEntityTypeConfiguration<GrupoAprovadorUsuario>
    {
        public void Configure(EntityTypeBuilder<GrupoAprovadorUsuario> builder)
        {
            builder.ToTable("GrupoAprovadorUsuario");

            builder.Property(x => x.IdGrupoAprovadorUsuario).IsRequired();
            builder.Property(x => x.IdUsuario).IsRequired();
            builder.Property(x => x.IdGrupoAprovador).IsRequired();

            builder.HasKey(x => x.IdGrupoAprovadorUsuario);
        }
    }
}
