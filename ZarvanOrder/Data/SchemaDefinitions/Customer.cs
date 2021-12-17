using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Data.SchemaDefinitions
{
    public class Customer : BaseProperesConfig<long, Model.Entites.Customer>
    {
        public override void Configure(EntityTypeBuilder<Model.Entites.Customer> builder)
        {
            builder.Property(p => p.Code).HasMaxLength(15).IsRequired().IsUnicode();
            builder.Property(p => p.CompanyName).HasMaxLength(150);
            builder.Property(p => p.CustomerType).IsRequired();
            builder.Property(p => p.Name).HasMaxLength(60);
            builder.Property(p => p.Family).HasMaxLength(60);
            builder.Property(p => p.RefId).IsRequired();
            builder.Property(p => p.UserId).IsRequired();
            builder.Property(p => p.Reminded).IsRequired().HasPrecision(18,2);
            builder.HasOne(p => p.UserCustomer).
                WithMany(p => p.Customers).
                HasForeignKey(p => p.UserId).
                OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.NoAction);
            base.Configure(builder);
        }
    }
}
