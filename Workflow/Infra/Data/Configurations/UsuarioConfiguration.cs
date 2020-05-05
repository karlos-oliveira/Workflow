using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Workflow.Models;

namespace Workflow.Infra.Data.Configurations
{

    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(x => x.IdUsuario).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.IdConta).IsRequired();
            builder.Property(x => x.IsAtivo).HasDefaultValue(true).IsRequired();

            builder.HasKey(x => x.IdUsuario);
        }
    }
}
