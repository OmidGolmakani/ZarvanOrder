using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ZarvanOrder.Data.SchemaDefinitions
{
    public class MarketerAccessRegion : BaseProperesConfig<long, Model.Entites.MarketerAccessRegion>
    {
        public override void Configure(EntityTypeBuilder<Model.Entites.MarketerAccessRegion> builder)
        {
            builder.ToTable("MarketerAccessRegion");
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.RegionId).IsRequired();
            builder.HasOne(p => p.Marketer)
                   .WithMany(p => p.MarketerAccessRegions)
                   .OnDelete(DeleteBehavior.NoAction)
                   .HasForeignKey(p => p.UserId);
            builder.HasOne(p => p.Region)
                  .WithMany(p => p.MarketerAccessRegions)
                  .OnDelete(DeleteBehavior.NoAction)
                  .HasForeignKey(p => p.RegionId);
            base.Configure(builder);
        }
    }
}
