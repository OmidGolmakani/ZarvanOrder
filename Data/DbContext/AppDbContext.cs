using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Data.DbContext
{
    public class AppDbContext : IdentityDbContext<User,
                                                  Role,
                                                  long,
                                                  UserClaim,
                                                  UserRole,
                                                  UserLogin,
                                                  RoleClaim,
                                                  UserToken>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options,
                            IHttpContextAccessor httpContext) : base(options)
        {

            
        }
        //public DbSet<Category> Categories{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new CategoryEntitySchemaDefinition());

            base.OnModelCreating(modelBuilder);
            #region Seed

            #endregion Seed
        }
    }
}
