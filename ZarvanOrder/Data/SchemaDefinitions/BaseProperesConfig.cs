using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Data.SchemaDefinitions
{
    public class BaseProperesConfig<TIdentityType, TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : Interfaces.Entites.IAuditEntity<TIdentityType>
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(p => p.CreatedBy).HasMaxLength(10);
        }
    }
}
