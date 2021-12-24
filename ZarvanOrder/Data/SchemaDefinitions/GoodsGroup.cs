using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Data.SchemaDefinitions
{
    public class GoodsGroup : BaseProperesConfig<int, Model.Entites.GoodsGroup>
    {
        public override void Configure(EntityTypeBuilder<Model.Entites.GoodsGroup> builder)
        {
            builder.ToTable("GoodsGroup");
            builder.Property(p => p.RefId);
            builder.Property(p => p.FatherId);
            builder.Property(p => p.Code).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(120);
            builder.HasIndex(p => new { p.RefId, p.Code, p.Name }).IsUnique();
            builder.HasOne(p => p.FatherGoodsGroup)
                   .WithMany(p => p.ChildGoodsGroups)
                   .HasForeignKey(p=> p.FatherId)
                   .OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
