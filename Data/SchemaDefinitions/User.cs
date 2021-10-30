﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZarvanOrder.Data.SchemaDefinitions
{
    public class User :
       IEntityTypeConfiguration<Model.Entites.User>
    {
        public void Configure(EntityTypeBuilder<Model.Entites.User> builder)
        {
            builder.ToTable("AspNetUsers")
                .HasKey(c => c.Id);
            builder.Property(p => p.Name).HasMaxLength(60);
            builder.Property(p => p.Family).HasMaxLength(60);
            builder.Property(p => p.UserName).HasMaxLength(100);
            builder.Property(p => p.NormalizedUserName).HasMaxLength(100);
            builder.Property(p => p.PasswordHash).HasMaxLength(200);
            builder.Property(p => p.Email).HasMaxLength(70);
            builder.Property(p => p.NormalizedEmail).HasMaxLength(70);
            builder.Property(p => p.PhoneNumber).HasMaxLength(12);
            builder.Property(p => p.PhoneNumberConfirmed).HasDefaultValue(false);
            builder.Property(p => p.EmailConfirmed).HasDefaultValue(false);
            builder.Property(p => p.AccessFailedCount).HasDefaultValue(0);
            builder.Property(p => p.ConcurrencyStamp).HasMaxLength(200).IsRequired();
            builder.Property(p => p.SecurityStamp).HasMaxLength(2000).IsRequired();
            builder.Property(p => p.TwoFactorEnabled);
            builder.Property(p => p.LockoutEnd);
            builder.Property(p => p.LockoutEnabled);
            builder.Property(p => p.NationalCode).HasMaxLength(10);
        }
    }
}
