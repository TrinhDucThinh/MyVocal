using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyVocal.Model.Models
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string FullName { set; get; }
        [MaxLength(600)]
        public string Description { set; get; }

        public DateTime? CreateDate{set;get;}

        [MaxLength(300)]
        public string ImageAvatar { set; get; }

        public int? WordRememeber { set; get; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
