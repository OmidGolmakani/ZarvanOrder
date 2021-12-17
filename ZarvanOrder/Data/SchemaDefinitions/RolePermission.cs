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
        BaseProperesConfig<long,Model.Entites.RolePermission>
    {
        public override void Configure(EntityTypeBuilder<Model.Entites.RolePermission> builder)
        {
            builder.ToTable("RolePermission");
            builder.Property(p => p.RoleId).IsRequired();
            builder.Property(p => p.Token).IsRequired().HasMaxLength(600);
            builder.Property(p => p.Url).IsRequired().HasMaxLength(300);
            builder.HasOne(p => p.Role).WithMany(p => p.RolePermissions).
                HasForeignKey(p => p.RoleId).OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
