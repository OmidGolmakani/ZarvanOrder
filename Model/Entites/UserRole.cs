using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZarvanOrder.Model.Entites
{
    public class UserRole : IdentityUserRole<long>
    {
    }
}
