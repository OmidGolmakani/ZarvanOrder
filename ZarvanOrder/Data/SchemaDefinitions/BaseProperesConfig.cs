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
        where TIdentityType : struct
        where TEntity : Model.Entites.AuditDeleteEntity<TIdentityType>
    {
        protected virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.LastModified);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(120);
            builder.Property(p => p.CreatedDate);
            builder.Property(p => p.CreatedBy).HasMaxLength(120);
            builder.Property(p => p.DeletedDate);
            builder.Property(p => p.DeletedBy).HasMaxLength(120);
        }
    }
}
