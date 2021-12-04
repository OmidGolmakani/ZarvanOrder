using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using ZarvanOrder.Data.DbContext;
using ZarvanOrder.Model.Entites;

namespace ZarvanOrder.Data.DbContext
{
    public class UserStores : UserStore<User,
                                        Role,
                                        AppDbContext, 
                                        long, 
                                        UserClaim,
                                        UserRole, 
                                        UserLogin, 
                                        UserToken, 
                                        RoleClaim>
    {
        public UserStores(AppDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
        {
        }
    }
}
