using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Data.SchemaDefinitions
{
    public class RolePermission :
        IEntityTypeConfiguration<Model.Entites.RolePermission>
    {
        public void Configure(EntityTypeBuilder<Model.Entites.RolePermission> builder)
        {
            builder.ToTable("RolePermission")
                .HasKey(p => p.Id);
            builder.Property(p => p.LastModified);
            builder.Property(p => p.LastModifiedBy).HasMaxLength(120);
            builder.Property(p => p.CreatedDate);
            builder.Property(p => p.CreatedBy).HasMaxLength(120);
            builder.Property(p => p.DeletedDate);
            builder.Property(p => p.DeletedBy).HasMaxLength(120);
            builder.Property(p => p.RoleId).IsRequired();
            builder.Property(p => p.Token).IsRequired().HasMaxLength(600);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(300);
            builder.HasOne(p => p.Role).WithMany(p => p.RolePermissions).
                HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
