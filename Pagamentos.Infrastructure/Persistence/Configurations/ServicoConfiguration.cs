using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pagamentos.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pagamentos.Infrastructure.Persistence.Configurations
{
    public class ServicoConfiguration : IEntityTypeConfiguration<Servicos>
    {
        public void Configure(EntityTypeBuilder<Servicos> builder)
        {
            builder
                .HasKey(s => s.Id);

            builder
                .HasOne(u => u.Prestadores)
                .WithMany(f => f.Servicos)
                .HasForeignKey(u => u.IdPrestador)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
