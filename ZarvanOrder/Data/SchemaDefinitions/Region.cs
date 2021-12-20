using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Data.SchemaDefinitions
{
    public class Region : BaseProperesConfig<int, Model.Entites.Region>
    {
        public override void Configure(EntityTypeBuilder<Model.Entites.Region> builder)
        {
            builder.ToTable("Region");
            builder.Property(p => p.RegionFatherId);
            builder.Property(p => p.RefId).IsRequired();
            builder.Property(p => p.RegionCode).IsRequired();
            builder.Property(p => p.RegionName).HasMaxLength(60).IsRequired();
            builder.Property(p => p.Active).HasDefaultValueSql("1");
            builder.HasOne(p => p.FatherRegion)
                   .WithMany(p => p.ChildRegion)
                   .HasForeignKey(p => p.RegionFatherId)
                   .OnDelete(DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
