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
    public class PrestadorConfiguration : IEntityTypeConfiguration<Prestadores>
    {
        public void Configure(EntityTypeBuilder<Prestadores> builder)
        {
            builder
                .HasKey(s => s.Id);
        }
    }
}
